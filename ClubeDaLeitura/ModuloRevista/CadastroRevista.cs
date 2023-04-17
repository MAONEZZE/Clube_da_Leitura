using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeDaLeitura.ModuloCaixa;

namespace ClubeDaLeitura.ModuloRevista
{
    internal class CadastroRevista
    {
        public static RepositorioRevista rep = new RepositorioRevista();

        public void RemoverRevista()
        {
            int id;

            Console.Write("Digite o ID da Revista que você deseja Remover: ");
            id = Convert.ToInt32(Console.ReadLine());

            rep.Remover(id);

            Console.Write("Revista Removida com sucesso!");
            Console.ReadKey();
            Console.Clear();
        }

        public Caixa AlterarCaixaDaRevista()
        {
            int id;

            Console.Write("Digite o ID da Caixa que você deseja Colocar a Revista: ");
            id = Convert.ToInt32(Console.ReadLine());

            foreach (Caixa cx in CadastroCaixa.rep.Visualizador())
            {
                if (cx.id == id)
                {
                    return cx;
                }
            }

            return null;
        }

        public void EditarRevista()
        {
            char opcaoCaixa;
            string novoTipoColecao, novoAnoRevista;
            int id, novoID, novoNumEdicao;
            bool verificador = false;
            Caixa novaCaixaDaRevista = null;

            Console.Write("Digite o ID da Revista que você deseja Editar: ");
            id = Convert.ToInt32(Console.ReadLine());

            foreach (Revista rev in rep.Visualizador())
            {
                if (rev.id == id)
                {
                    verificador = true;

                    Console.Write("Digite o novo ID da Revista: ");
                    novoID = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Digite o novo Tipo de Coleção da Revista: ");
                    novoTipoColecao = Console.ReadLine();

                    Console.Write("Digite o novo Ano da Revista: ");
                    novoAnoRevista = Console.ReadLine();

                    Console.Write("Digite o novo Número de Edição da Revista: ");
                    novoNumEdicao = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Deseja muda-la de caixa? (S/N)");
                    opcaoCaixa = Convert.ToChar(Console.ReadLine());

                    if(opcaoCaixa == 's' || opcaoCaixa == 'S')
                    {
                        novaCaixaDaRevista = AlterarCaixaDaRevista();

                        if (novaCaixaDaRevista == null)
                        {
                            novaCaixaDaRevista = rev.caixaOndeEstaGuardada;
                            Console.WriteLine("O ID da caixa informada não foi encontrada. A revista ficará na mesma caixa!");
                        }
                        else
                        {
                            Console.WriteLine("Revista alterada com sucesso!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Revista alterada com sucesso, porém permanece na mesma caixa!");
                    }

                    Revista revista = new Revista(novoTipoColecao, novoNumEdicao, novoAnoRevista, novaCaixaDaRevista, novoID);
                    rep.Editor(id, revista);
                    break;
                }
            }

            if (verificador == false)
            {
                Console.WriteLine("Nenhuma revista com esse ID encontrada!");
            }
            Console.ReadKey();
            Console.Clear();
        }

        public void VisualizarRevista()
        {
            Console.WriteLine("Dados das Revistas");
            foreach (Revista rev in rep.Visualizador())
            {
                Console.WriteLine($"ID: {rev.id}\n" +
                    $"Tipo da Coleção: {rev.tipoColecao}\n" +
                    $"Número da Edição: {rev.numEdicao}\n" +
                    $"Ano: {rev.anoRevista}\n" +
                    $"Caixa que está Guardada: {rep.ProcurarCaixaVisualizacao(rev.caixaOndeEstaGuardada)}");
                Console.WriteLine();
            }
            Console.ReadKey();
            Console.Clear();

        }

        public Caixa ProcurarCaixaDaRevista(int idCaixa)
        { 
            foreach (Caixa cx in CadastroCaixa.rep.Visualizador())
            {
                if (cx.id == idCaixa)
                {
                    return cx;
                }
            }

            return null;

        }

        public void InserirRevista()
        {
            if (CadastroCaixa.rep.Visualizador().Count == 0)
            {
                Console.WriteLine("Não há nenhuma caixa, portanto não ha como inserir uma revista!");
            }
            else
            {
                string tipoColecao, anoRevista;
                int numEdicao, id, idCaixa;
                Caixa caixaOndeEstaGuardada;

                Console.Write("Digite o ID da Caixa que a Revista está guardada: ");
                idCaixa = Convert.ToInt32(Console.ReadLine());

                caixaOndeEstaGuardada = ProcurarCaixaDaRevista(idCaixa);

                if (caixaOndeEstaGuardada == null)
                {
                    Console.WriteLine("Não foi possível encontrar a caixa!, Digite um ID de caixa válido");
                }
                else
                {
                    Console.Write("Digite o Tipo da Coleção da Revista: ");
                    tipoColecao = Console.ReadLine();

                    Console.Write("Digite o Número da Edição da Revista: ");
                    numEdicao = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Digite o ID da Revista: ");
                    id = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Digite o ano da Revista: ");
                    anoRevista = Console.ReadLine();

                    Revista revista = new Revista(tipoColecao, numEdicao, anoRevista, caixaOndeEstaGuardada, id);

                    rep.Inserir(revista);

                    Console.WriteLine();
                    Console.WriteLine("Revista Inserida!");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

        }

        public void EscolhaDaOpcao(char opcao)
        {
            switch (opcao)
            {
                case '1':
                    InserirRevista();
                    break;

                case '2':
                    VisualizarRevista();
                    break;

                case '3':
                    EditarRevista();
                    break;

                case '4':
                    RemoverRevista();
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
                Console.WriteLine("----- Gerenciamento de Revista ----");
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
