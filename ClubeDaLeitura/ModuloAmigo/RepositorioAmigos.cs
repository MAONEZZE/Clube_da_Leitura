using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeDaLeitura.ModuloCaixa;

namespace ClubeDaLeitura.ModuloAmigo
{
    internal class RepositorioAmigos
    {
        private ArrayList listaAmigos = new ArrayList();

        public void Inserir(Amigo amigo)
        {
            listaAmigos.Add(amigo);
        }

        public ArrayList Visualizador()
        {
            return listaAmigos;
        }

        public void Editor(int id, Amigo novoAmigo)
        {
            foreach (Amigo amg in listaAmigos)
            {
                if (amg.id == id)
                {
                    amg.nome = novoAmigo.nome;
                    amg.nomeDoResponsavel = novoAmigo.nomeDoResponsavel;
                    amg.id = novoAmigo.id;
                    amg.telefone = novoAmigo.telefone;
                    amg.endereco = novoAmigo.endereco;
                }
            }
        }

        public void Remover(int id)
        {
            foreach (Amigo amg in listaAmigos)
            {
                if (amg.id == id)
                {
                    listaAmigos.Remove(amg);
                    break;
                }
            }
        }
    }
}
