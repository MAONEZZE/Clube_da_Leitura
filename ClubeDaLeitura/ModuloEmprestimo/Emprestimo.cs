using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeDaLeitura.ModuloAmigo;
using ClubeDaLeitura.ModuloRevista;

namespace ClubeDaLeitura.ModuloEmprestimo
{
    internal class Emprestimo
    {
        public Amigo amigoPegouRevista;
        public Revista revistaEmprestada;
        public string dataDoEmprestimo;
        public string dataDeDevolucao;
        public int id;

        public Emprestimo(Amigo amigoPegouRevista, Revista revistaEmprestada, string dataDoEmprestimo, string dataDeDevolucao, int id)
        {
            this.amigoPegouRevista = amigoPegouRevista;
            this.revistaEmprestada = revistaEmprestada;
            this.dataDoEmprestimo = dataDoEmprestimo;
            this.dataDeDevolucao = dataDeDevolucao;
            this.id = id;
        }
    }
}
