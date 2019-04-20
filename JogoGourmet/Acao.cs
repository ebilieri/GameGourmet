using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JogoGourmet
{
    public abstract class Acao
    {        
        public string Descricao { get; }

        public Acao(string descricao)
        {
            Descricao = descricao;           
        }
        
        public abstract Acao Perguntar(Acao acao);                      
    }
}
