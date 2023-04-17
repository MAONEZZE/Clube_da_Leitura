using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeDaLeitura.ModuloCaixa;

namespace ClubeDaLeitura.ModuloAmigo
{
    internal class CadastroAmigo
    {
        public static RepositorioAmigos rep = new RepositorioAmigos();
        public void RemoverAmigo()
        {
            int id;

            Console.Write("Digite o ID do Amigo que você deseja Remover: ");
            id = Convert.ToInt32(Console.ReadLine());

            rep.Remover(id);

            Console.WriteLine("Amigo Removido!");
            Console.ReadKey();
            Console.Clear();
        }

        public void EditarAmigo()
        {
            string novoNome, novoNomeDoResponsavel, novoTelefone, novoEndereco;
            int id, novoID;
            bool x = false;

            Console.Write("Digite o ID do Amigo que você deseja Editar: ");
            id = Convert.ToInt32(Console.ReadLine());

            foreach (Amigo amg in rep.Visualizador())
            {
                if (amg.id == id)
                {
                    x = true;
                    Console.Write("Digite o nome do Amigo: ");
                    novoNome = Console.ReadLine();

                    Console.Write("Digite o nome do Responsável do Amigo: ");
                    novoNomeDoResponsavel = Console.ReadLine();

                    Console.Write("Digite o ID do Amigo: ");
                    novoID = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Digite o telefone do Amigo: ");
                    novoTelefone = Console.ReadLine();

                    Console.Write("Digite o endereço do Amigo: ");
                    novoEndereco = Console.ReadLine();

                    Amigo amigo = new Amigo(novoNome, novoNomeDoResponsavel, novoTelefone, novoEndereco, novoID);

                    rep.Editor(id, amigo);
                }
            }

            Console.WriteLine();

            if (x == false)
            {
                Console.WriteLine("Não há Amigo com esse ID");
            }

            Console.WriteLine("Amigo Editado!");
            Console.ReadKey();
            Console.Clear();
        }

        public void VisualizarAmigo()
        {
            Console.WriteLine("Dados dos Amigos");
            foreach (Amigo amg in rep.Visualizador())
            {
                Console.WriteLine($"ID: {amg.id}\n" +
                    $"Nome: {amg.nome}\n" +
                    $"Nome do Responsável: {amg.nomeDoResponsavel}\n" +
                    $"Telefone: {amg.telefone}\n" +
                    $"Endereço: {amg.endereco}");
                Console.WriteLine();
            }
            Console.ReadKey();
            Console.Clear();
        }

        public void InserirAmigo()
        {
            string nome, nomeDoResponsavel, telefone, endereco;
            int id;

            Console.Write("Digite o ID do Amigo: ");
            id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite o nome do Amigo: ");
            nome = Console.ReadLine();

            Console.Write("Digite o nome do Responsável do Amigo: ");
            nomeDoResponsavel = Console.ReadLine();

            Console.Write("Digite o telefone do Amigo: ");
            telefone = Console.ReadLine();

            Console.Write("Digite o endereço do Amigo: ");
            endereco = Console.ReadLine();

            Amigo amigo = new Amigo(nome, nomeDoResponsavel, telefone, endereco, id);

            rep.Inserir(amigo);

            Console.WriteLine();
            Console.WriteLine("Amigo Inserido!");
            Console.ReadKey();
            Console.Clear();

        }

        public void EscolhaDaOpcao(char opcao)
        {
            switch (opcao)
            {
                case '1':
                    InserirAmigo();
                    break;

                case '2':
                    VisualizarAmigo();
                    break;

                case '3':
                    EditarAmigo();
                    break;

                case '4':
                    RemoverAmigo();
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
                Console.WriteLine("----- Gerenciamento de Amigos -----");
                Console.WriteLine("-----------------------------------");
                Console.WriteLine();
                Console.WriteLine("1 - --------- Inserir -------------");
                Console.WriteLine("2 - --------- Visualizar ----------");
                Console.WriteLine("3 - --------- Editar --------------");
                Console.WriteLine("4 - --------- Remover -------------");
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
