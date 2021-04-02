using System;

namespace Dio.Musica
{
    class Program
    {
        static MusicaRepositorio repositorio = new MusicaRepositorio(); // Referencia repositorio Musicas
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X") // Leitura opção menu principal
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarMusica();
						break;
					case "2":
						InserirMusica();
						break;
					case "3":
						AtualizarMusica();
						break;
					case "4":
						ExcluirMusica();
						break;
					case "5":
						OuvirMusica();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado!!!.");
			Console.ReadLine();
        }
            
         private static void ListarMusica()// Listar Musica
		{
			Console.WriteLine("Listar Música");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma Música cadastrada.");
				return;
			}

			foreach (var serie in lista)
			{
                var excluido = serie.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}
            
         private static void InserirMusica() // Inseri Musica
		{
			Console.WriteLine("Inserir nova Música");

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=net-5.0
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=net-5.0
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da música: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano da música: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite o nome do cantor: ");
			string entradaDescricao = Console.ReadLine();

			Musica novaMusica = new Musica(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										cantor: entradaDescricao);

			repositorio.Insere(novaMusica);
		}
        
         private static void AtualizarMusica() // Atualiza Musica
		{
			Console.Write("Digite o id da Música: ");
			int indiceMusica = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=net-5.0
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=net-5.0
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Música: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Música: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Música: ");
			string entradaDescricao = Console.ReadLine();

			Musica atualizaMusica = new Musica(id: indiceMusica,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										cantor: entradaDescricao);

			repositorio.Atualiza(indiceMusica, atualizaMusica);
		}

            private static void ExcluirMusica() // Exclui Música
		{
			Console.Write("Digite o id da Música: ");
			int indiceMusica = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceMusica);
        
		}

          private static void OuvirMusica() // Mostra musica
		{
			Console.Write("Digite o id da Música: ");
			int indiceMusica = int.Parse(Console.ReadLine());

			var musica = repositorio.RetornaPorId(indiceMusica);

			Console.WriteLine(musica);
		}

     

         private static string ObterOpcaoUsuario() // Menu Principal
		{
			Console.WriteLine();
			Console.WriteLine("DIO Meu cadastro de Musicas!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar Músicas");
			Console.WriteLine("2- Inserir nova Música");
			Console.WriteLine("3- Atualizar Música");
			Console.WriteLine("4- Excluir Música");
			Console.WriteLine("5- Ouvir Música");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
        }
    }
}
