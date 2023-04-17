using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ModuloCaixa
{
    internal class CadastroCaixa
    {
        public static RepositorioCaixas rep = new RepositorioCaixas();

        public void RemoverCaixa()
        {
            int id;

            Console.Write("Digite o ID da caixa que você deseja Remover: ");
            id = Convert.ToInt32(Console.ReadLine());

            rep.Remover(id);

            Console.WriteLine("Caixa Removida!");
            Console.ReadKey();
            Console.Clear();
        }

        public void EditarCaixa()
        {
            string corNova, etiquetaNova;
            int id, idNovo;
            bool x = false;

            Console.Write("Digite o ID da caixa que você deseja Editar: ");
            id = Convert.ToInt32(Console.ReadLine());

            foreach (Caixa cx in rep.Visualizador())
            {
                if (cx.id == id)
                {
                    x = true;
                    Console.Write("Digite o Novo ID da caixa: ");
                    idNovo = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Digite a Nova Cor da caixa: ");
                    corNova = Console.ReadLine();

                    Console.Write("Digite a Nova Etiqueta da caixa: ");
                    etiquetaNova = Console.ReadLine();

                    Caixa caixa = new Caixa(corNova, idNovo, etiquetaNova);

                    rep.Editor(id, caixa);
                }
            }

            Console.WriteLine();

            if (x == false)
            {
                Console.WriteLine("Não há caixa com esse ID");
            }

            Console.WriteLine("Caixa Editada!");
            Console.ReadKey();
            Console.Clear();
        }

        public void VisualizarCaixa()
        {
            Console.WriteLine("Dados das Caixas");
            foreach(Caixa cx in rep.Visualizador())
            {
                Console.WriteLine($"ID: {cx.id}\n" +
                    $"Cor: {cx.cor}\n" +
                    $"Etiqueta: {cx.etiqueta}");
                Console.WriteLine();
            }
            Console.ReadKey();
            Console.Clear();

        }

        public void InserirCaixa()
        {
            string cor, etiqueta;
            int id;

            Console.Write("Digite o ID da caixa: ");
            id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite a Cor da caixa: ");
            cor = Console.ReadLine();

            Console.Write("Digite a Etiqueta da caixa: ");
            etiqueta = Console.ReadLine();

            Caixa caixa = new Caixa(cor, id, etiqueta);

            rep.Inserir(caixa);

            Console.WriteLine();
            Console.WriteLine("Caixa Inserida!");
            Console.ReadKey();
            Console.Clear();

        }

        public void EscolhaDaOpcao(char opcao)
        {
            switch (opcao)
            {
                case '1': InserirCaixa();
                    break;

                case '2': VisualizarCaixa();
                    break;

                case '3': EditarCaixa();
                    break;

                case '4': RemoverCaixa();
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
                Console.WriteLine("----- Gerenciamento de Caixas -----");
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
