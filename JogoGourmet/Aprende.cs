using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoGourmet
{
   public class Aprende : Acao
    {        
        private PratoService _pratoService;

        public Aprende( PratoService pratoService)
            : base("")
        {            
            _pratoService = pratoService;
        }

        public override Acao Perguntar(Acao pratoAntigo)
        {
            string prato = _pratoService.aprender("Qual prato você pensou?", "Desisto");
            string habilidade = _pratoService.aprender($"{prato} é _______ mas {pratoAntigo.Descricao} não.", "Complete");

            return AdicionarNovoPrato(pratoAntigo, prato, habilidade);
        }

        private PerguntarPrato AdicionarNovoPrato(Acao pratoAntigo, string prato, string habilidade)
        {            
            Prato novoAnimal = new Prato(new PratoService(), this, prato);
            return new PerguntarPrato(novoAnimal, pratoAntigo, habilidade, _pratoService);
        }
    }
}
