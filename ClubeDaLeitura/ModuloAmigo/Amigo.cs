using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ModuloAmigo
{
    internal class Amigo
    {
        public string nome;
        public string nomeDoResponsavel;
        public string telefone; 
        public string endereco;
        public int id;

        public Amigo(string nome, string nomeDoResponsavel, string telefone, string endereco, int id)
        {
            this.nome = nome;
            this.nomeDoResponsavel = nomeDoResponsavel;
            this.telefone = telefone;
            this.endereco = endereco;
            this.id = id;
        }
    }
}
