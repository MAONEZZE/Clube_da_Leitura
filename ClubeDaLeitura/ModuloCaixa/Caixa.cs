using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ModuloCaixa
{
    internal class Caixa
    {
        public string cor;
        public int id;
        public string etiqueta;

        public Caixa(string cor, int id, string etiqueta)
        {
            this.cor = cor;
            this.id = id;
            this.etiqueta = etiqueta;
        }
    }
}
