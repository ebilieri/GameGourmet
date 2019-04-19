using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoGourmet
{
   public class Aprende : Acao
    {
        private InteracaoPorWindowsForm interacaoComUsuario;
        private PratoService _pratoService;

        public Aprende(InteracaoPorWindowsForm interacaoComUsuario, PratoService pratoService)
            : base("", interacaoComUsuario)
        {
            // TODO: Complete member initialization
            this.interacaoComUsuario = interacaoComUsuario;
            _pratoService = pratoService;
        }

        public override Acao Executar(Acao pratoAntigo)
        {
            string prato = this.INTERACAO_COM_USUARIO.aprender("Qual prato você pensou?", "Desisto");
            string habilidade = this.INTERACAO_COM_USUARIO.aprender($"{prato} é _______ mas {pratoAntigo.Descricao} não.", "Complete");

            return criaNovaHabilidadeComAnimais(pratoAntigo, prato, habilidade);
        }

        private PerguntarPrato criaNovaHabilidadeComAnimais(Acao pratoAntigo, string prato, string habilidade)
        {
            //Prato novoAnimal = new Prato(new AfirmaVitoria(this.INTERACAO_COM_USUARIO), this, prato, this.INTERACAO_COM_USUARIO);
            Prato novoAnimal = new Prato(new PratoService(), this, prato, this.INTERACAO_COM_USUARIO);
            return new PerguntarPrato(novoAnimal, pratoAntigo, habilidade, this.INTERACAO_COM_USUARIO);
        }
    }
}
