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

        private readonly string _descricao;
        private readonly InteracaoPorWindowsForm _interacaoComUsuario;

        public InteracaoPorWindowsForm INTERACAO_COM_USUARIO
        {
            get
            {
                return _interacaoComUsuario;
            }
        }

        public Acao(string descricao, InteracaoPorWindowsForm interacaoComUsuario)
        {
            _descricao = descricao;
            _interacaoComUsuario = interacaoComUsuario;
        }

        
        public abstract Acao Executar(Acao acao);

        public bool MostraPergunta(string pergunta, string carac)
        {
            return INTERACAO_COM_USUARIO.interagir(pergunta + carac);
        }

        public bool IsPerguntaValida(DialogResult pergunta)
        {
            return pergunta == DialogResult.Yes;
        }

        public string Descricao
        {
            get { return _descricao; }
        }
    }

}
