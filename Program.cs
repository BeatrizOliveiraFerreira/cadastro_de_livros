using System;
using livros.Classes;

namespace livros
{
  class Program
  {
    static LivroRepositorio repositorio = new LivroRepositorio();
    private static int indiceLivro;

    static void Main(string[] args)
    {
      string opcaoUsuario = ObterOpcaoUsuario();

      while (opcaoUsuario.ToUpper() != "X")
      {
        switch (opcaoUsuario)
        {
          case "1":
            ListarLivros();
            break;
          case "2":
            InserirLivro();
            break;
          case "3":
            AtualizarLivro(
      repositorio);
            break;
          case "4":
            ExcluirLivro();
            break;
          case "5":
            VisualizarLivro();
            break;
          case "C":
            Console.Clear();
            break;
          default:
            throw new ArgumentOutOfRangeException();
        }
        opcaoUsuario = ObterOpcaoUsuario();
      }
      Console.WriteLine("Obrigado por utilizar nossos serviços. ");
      Console.ReadLine();
    }

    private static void ListarLivros()
    {
      Console.WriteLine("Listar livros");

      var lista = repositorio.Lista();

      if (lista.Count == 0)
      {
        Console.WriteLine("Nenhum livro cadastrado.");
        return;
      }
      foreach (var livro in lista)
      {
        var excluido = livro.retornaExcluido();

        Console.WriteLine("#ID {0}: - {1} - {2}", livro.retornaId(), (excluido ? "*Excluído*" : ""));

      }
    }

    private static void InserirLivro()
    {
      Console.WriteLine("Inserir novo título");

      foreach (int i in Enum.GetValues(typeof(Genero)))
      {
        Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
      }
      Console.WriteLine("Digite o gênero entre as opções acima: ");
      int entradaGenero = int.Parse(Console.ReadLine());

      Console.Write("Digite o título do Livro: ");
      string entradaTitulo = Console.ReadLine();

      Console.WriteLine("Digite o ano que foi escrito o livro: ");
      int entradaAno = int.Parse(Console.ReadLine());

      Console.WriteLine("Digite a descrição do livro: ");
      string entradaDescricao = Console.ReadLine();

      Livro novoLivro = new Livro(id: repositorio.ProximoId(),
                                      genero: (Genero)entradaGenero,
                                      titulo: entradaTitulo,
                                      ano: entradaAno,
                                      descricao: entradaDescricao);
      repositorio.Insere(novoLivro);
    }

    // Atualizar Livro

    private static void AtualizarLivro(LivroRepositorio repositorio)
    {
      Console.WriteLine("Inserir novo título");

      foreach (int i in Enum.GetValues(typeof(Genero)))
      {
        Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
      }
      Console.WriteLine("Digite o gênero entre as opções acima: ");
      int entradaGenero = int.Parse(Console.ReadLine());

      Console.Write("Digite o título do Livro: ");
      string entradaTitulo = Console.ReadLine();

      Console.WriteLine("Digite o ano que foi escrito o livro: ");
      int entradaAno = int.Parse(Console.ReadLine());

      Console.WriteLine("Digite a descrição do livro: ");
      string entradaDescricao = Console.ReadLine();

      Livro atualizaLivro = new Livro(id: indiceLivro,
                                      genero: (Genero)entradaGenero,
                                      titulo: entradaTitulo,
                                      ano: entradaAno,
                                      descricao: entradaDescricao);
      repositorio.Atualizar(indiceLivro, atualizaLivro);
    }

    private static void ExcluirLivro()
    {
      Console.Write("Tem certeza de que quer excluir o id do livro? ");
      int indiceLivro = int.Parse(Console.ReadLine());

      repositorio.Exclui(indiceLivro);
    }

    private static void VisualizarLivro()
    {
      Console.Write("Digite o id do livro: ");
      int indiceLivro = int.Parse(Console.ReadLine());

      var livro = repositorio.RetornaPorId(indiceLivro);

      Console.WriteLine(livro);
    }

    private static string ObterOpcaoUsuario()
    {
      Console.WriteLine();
      Console.WriteLine("Livros a seu dispor!!!");
      Console.WriteLine("Informe a opção desejada");

      Console.WriteLine("1- Listar livros");
      Console.WriteLine("2- Inserir novo livro");
      Console.WriteLine("3- Atualizar livro");
      Console.WriteLine("4- Excluir livro");
      Console.WriteLine("5- Visualizar livro");
      Console.WriteLine("C- Limpar tela");
      Console.WriteLine("X- Sair");
      Console.WriteLine();

      string opcaoUsuario = Console.ReadLine().ToUpper();
      Console.WriteLine();
      return opcaoUsuario;
    }
  }
}
