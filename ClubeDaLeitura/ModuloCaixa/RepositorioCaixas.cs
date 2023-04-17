using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ModuloCaixa
{
    internal class RepositorioCaixas
    {
        private ArrayList listaCaixas = new ArrayList();

        public void Inserir(Caixa caixa)
        {
            listaCaixas.Add(caixa);
        }

        public ArrayList Visualizador()
        {
            return listaCaixas;
        }


        public void Editor(int id, Caixa novaCaixa)
        {
            foreach (Caixa cx in listaCaixas)
            {
                if (cx.id == id)
                {
                    cx.cor = novaCaixa.cor;
                    cx.id = novaCaixa.id;
                    cx.etiqueta = novaCaixa.etiqueta;
                }
            }
        }

        public void Remover(int id)
        {
            foreach(Caixa cx in  listaCaixas)
            {
                if(cx.id == id)
                {
                    listaCaixas.Remove(cx);
                    break;
                }
            }
        }

    }
}
