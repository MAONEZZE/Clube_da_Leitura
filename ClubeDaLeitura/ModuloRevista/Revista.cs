using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeDaLeitura.ModuloCaixa;

namespace ClubeDaLeitura    .ModuloRevista
{
    internal class Revista
    {
        public string tipoColecao; 
        public int numEdicao; 
        public string anoRevista; 
        public Caixa caixaOndeEstaGuardada;
        public int id;

        public Revista(string tipoColecao, int numEdicao, string anoRevista, Caixa caixaOndeEstaGuardada, int id)
        {
            this.tipoColecao = tipoColecao;
            this.numEdicao = numEdicao;
            this.anoRevista = anoRevista;
            this.caixaOndeEstaGuardada = caixaOndeEstaGuardada;
            this.id = id;
        }
    }
}
