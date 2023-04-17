using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeDaLeitura.ModuloCaixa;

namespace ClubeDaLeitura.ModuloRevista
{
    internal class RepositorioRevista
    {
        private ArrayList listaRevista = new ArrayList();

        public void Inserir(Revista revista)
        {
            listaRevista.Add(revista);
        }

        public string ProcurarCaixaVisualizacao(Caixa caixa)
        {
            foreach(Caixa cx in CadastroCaixa.rep.Visualizador())
            {
                if (caixa.id == cx.id) { 

                    return $"\n\tEtiqueta: {cx.etiqueta}\n\tCor: {cx.cor}\n\tID: {cx.id}";
                }
            }

            return null;
            
        }

        public ArrayList Visualizador()
        {
            return listaRevista;
        }


        public void Editor(int id, Revista novaRevista)
        {
            foreach (Revista rev in listaRevista)
            {
                if (rev.id == id)
                {
                    rev.tipoColecao = novaRevista.tipoColecao;
                    rev.id = novaRevista.id;
                    rev.caixaOndeEstaGuardada = novaRevista.caixaOndeEstaGuardada;
                    rev.anoRevista = novaRevista.anoRevista;
                    rev.numEdicao = novaRevista.numEdicao;
                }
            }
        }

        public void Remover(int id)
        {
            foreach (Revista rev in listaRevista)
            {
                if (rev.id == id)
                {
                    listaRevista.Remove(rev);
                    break;
                }
            }
        }
    }
}
