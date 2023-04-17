using ClubeDaLeitura.ModuloAmigo;
using ClubeDaLeitura.ModuloCaixa;
using ClubeDaLeitura.ModuloRevista;
using ClubeDaLeitura.ModuloEmprestimo;

namespace ClubeDaLeitura
{
    internal class Program
    {
        static void EscolherGerenciamento(char opcao)
        {
            CadastroCaixa cadCX = new CadastroCaixa();
            CadastroAmigo cadAMG = new CadastroAmigo();
            CadastroRevista cadREV = new CadastroRevista();
            CadastroEmprestimo cadEmp = new CadastroEmprestimo();

            switch (opcao)
            {
                case '1':
                    cadREV.ApresentarMenuCadastro();
                    break;

                case '2':
                    cadCX.ApresentarMenuCadastro();
                    break;

                case '3':
                    cadEmp.ApresentarMenuCadastro();
                    break;

                case '4':
                    cadAMG.ApresentarMenuCadastro();
                    break;
            }
        }

        static void MenuPrincipal()
        {
            char opcao;
            do
            {
                Console.WriteLine("         Menu Principal");
                Console.WriteLine("Gerenciamento do Clube da Leitura");
                Console.WriteLine();
                Console.WriteLine("1 - Gerenciamento das Revistas");
                Console.WriteLine("2 - Gerenciamento das Caixas");
                Console.WriteLine("3 - Gerenciamento dos Emprestimos");
                Console.WriteLine("4 - Gerenciamento dos Amigos");
                Console.WriteLine("S - Sair");
                Console.WriteLine();
                Console.Write("Opção: ");
                opcao = Convert.ToChar(Console.ReadLine());
                Console.WriteLine();
                Console.Clear();

                if (opcao != 's' && opcao != 'S' && opcao == '1' || opcao == '2' || opcao == '3' || opcao == '4')
                {
                    EscolherGerenciamento(opcao);
                }

            } while (opcao != 's' && opcao != 'S');

            Console.WriteLine("Fechando o Gerenciador...");
        }

        static void Main(string[] args)
        {
            MenuPrincipal();

            Console.ReadKey();
        }
    }
}