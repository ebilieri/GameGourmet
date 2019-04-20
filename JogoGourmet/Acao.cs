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
        //private readonly InteracaoPorWindowsForm _interacaoComUsuario;
        PratoService _pratoService;

        //public PratoService Prata_Usuario
        //{
        //    get { return _pratoService; }
        //}

        //public InteracaoPorWindowsForm INTERACAO_COM_USUARIO
        //{
        //    get
        //    {
        //        return _interacaoComUsuario;
        //    }
        //}

        public Acao(string descricao, PratoService pratoService)
        {
            _descricao = descricao;
            _pratoService = pratoService;
        }

        
        public abstract Acao Perguntar(Acao acao);

        

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
