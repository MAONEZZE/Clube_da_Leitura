using ClubeDaLeitura.ModuloRevista;
using ClubeDaLeitura.ModuloAmigo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ModuloEmprestimo
{
    internal class RepositorioEmprestimo
    {
        private ArrayList listaEmprestimo = new ArrayList();

        public void Inserir(Emprestimo emp)
        {
            listaEmprestimo.Add(emp);
        }

        public string ProcurarRevistaVisualizacao(Revista revista)
        {
            foreach (Revista rev in CadastroRevista.rep.Visualizador())
            {
                if (revista.id == rev.id)
                {
                    return $"\tID: {rev.id}\n\tTipo da Colecao: {rev.tipoColecao}\n\tNúmero da Edição: {rev.numEdicao}";
                }
            }

            return null;
        }

        public string ProcurarAmigoVisualizacao(Amigo amigo)
        {
            foreach (Amigo amg in CadastroAmigo.rep.Visualizador())
            {
                if (amigo.id == amg.id)
                {
                    return $"\tID: {amg.id}\n\tNome: {amg.nome}\n\tEndereço: {amg.endereco}\n\tTelefone: {amg.telefone}";
                }
            }

            return null;

        }

        public ArrayList Visualizador()
        {
            return listaEmprestimo;
        }

        public void FecharEmprestimo(Emprestimo emp, string dataDevolucao)
        {
            emp.dataDeDevolucao = dataDevolucao;
        }
    }
}
