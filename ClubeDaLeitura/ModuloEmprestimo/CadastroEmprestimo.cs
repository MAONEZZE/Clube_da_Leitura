using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeDaLeitura.ModuloAmigo;
using ClubeDaLeitura.ModuloRevista;

namespace ClubeDaLeitura.ModuloEmprestimo
{
    internal class CadastroEmprestimo
    {
        RepositorioEmprestimo rep = new RepositorioEmprestimo();

        public void FecharEmprestimo()
        {
            int id;
            bool x = false;
            string dataDevolucao;

            Console.Write("Digite o ID do Emprestimo para facha-lo: ");
            id = Convert.ToInt32(Console.ReadLine());

            foreach(Emprestimo emp in rep.Visualizador())
            {
                if (emp.id == id)
                {
                    x = true;
                    Console.Write("Digite que a revista foi devolvida: ");
                    dataDevolucao = Console.ReadLine();

                    rep.FecharEmprestimo(emp, dataDevolucao);
                    break;
                }
            }

            if(x == false)
            {
                Console.WriteLine("Não ha nenhum Emprestimo com esse ID!");
            }

            Console.ReadKey();
            Console.Clear();
        }
        public void VisualizarEmprestimo()
        {
            Console.WriteLine("Dados dos Emprestimos");
            foreach (Emprestimo emp in rep.Visualizador())
            {
                Console.WriteLine($"ID: {emp.id}\n" +
                    $"Amigo:\n" +
                    $"{rep.ProcurarAmigoVisualizacao(emp.amigoPegouRevista)}" +
                    $"Revista:\n" +
                    $"{rep.ProcurarRevistaVisualizacao(emp.revistaEmprestada)}" +
                    $"Data do emprestimo: {emp.dataDoEmprestimo}\n" +
                    $"Data da Devolução: {emp.dataDeDevolucao}");
                Console.WriteLine();
            }
            Console.ReadKey();
            Console.Clear();
        }

        public Revista ProcurarREV(int id)
        {
            foreach (Revista rev in CadastroRevista.rep.Visualizador())
            {
                if(rev.id == id)
                {
                    return rev;
                }
            }

            return null;

        }

        public Amigo ProcurarAMG(int id)
        {
            foreach (Amigo amg in CadastroAmigo.rep.Visualizador())
            {
                if (amg.id == id)
                {
                    return amg;
                }
            }

            return null;
        }

        public bool VerificarEmprestimoUnitario(int idAmigo)
        {
            foreach(Emprestimo emp in rep.Visualizador())
            {
                if (emp.amigoPegouRevista.id == idAmigo && emp.dataDeDevolucao.Equals("Em Aberto"))
                {
                    return true;
                }
            }
            return false;
        }

        public void InserirEmprestimo()
        {
            Amigo amigoPegouRevista;
            Revista revistaEmprestada;
            string dataDoEmprestimo;
            int id, idAmigo, idRevista;

            Console.Write("Digite o ID do Emprestimo: ");
            id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite o ID do Amigo que pegou a revista: ");
            idAmigo = Convert.ToInt32(Console.ReadLine());
            if (VerificarEmprestimoUnitario(idAmigo))
            {
                Console.WriteLine("Esse seu amigo não pode mais Pegar emprestado, pois ja tem um emprestimo e está em aberto!");
            }
            else
            {
                amigoPegouRevista = ProcurarAMG(idAmigo);

                Console.Write("Digite o ID da Revista emprestada: ");
                idRevista = Convert.ToInt32(Console.ReadLine());
                revistaEmprestada = ProcurarREV(idRevista);

                Console.Write("Digite a data do Emprestimo: ");
                dataDoEmprestimo = Console.ReadLine();

                Emprestimo emp = new Emprestimo(amigoPegouRevista, revistaEmprestada, dataDoEmprestimo, "Em Aberto", id);
                rep.Inserir(emp);

                Console.WriteLine();
                Console.WriteLine("Emprestimo Inserido!");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public void EscolhaDaOpcao(char opcao)
        {
            switch (opcao)
            {
                case '1':
                    InserirEmprestimo();
                    break;

                case '2':
                    VisualizarEmprestimo();
                    break;

                case '3':
                    FecharEmprestimo();
                    break;
            }
        }

        public void ApresentarMenuCadastro()
        {
            char opcao;
            do
            {
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("---------- Menu Cadastro ----------");
                Console.WriteLine("--- Gerenciamento de Emprestimo ---");
                Console.WriteLine("-----------------------------------");
                Console.WriteLine();
                Console.WriteLine("1 - --------- Inserir -------------");
                Console.WriteLine("2 - --------- Visualizar ----------");
                Console.WriteLine("3 - --------- Fechar --------------");
                Console.WriteLine("S - ---------- Sair ---------------");
                Console.WriteLine();
                Console.Write("Opção: ");
                opcao = Convert.ToChar(Console.ReadLine());
                Console.Clear();

                if (opcao != 's' && opcao != 'S' && opcao == '1' || opcao == '2' || opcao == '3' || opcao == '4')
                {
                    EscolhaDaOpcao(opcao);
                }

            } while (opcao != 's' && opcao != 'S');
        }
    }
}
