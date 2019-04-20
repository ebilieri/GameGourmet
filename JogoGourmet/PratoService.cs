using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JogoGourmet
{
    public class PratoService
    {
        public BasePrato Aprender(BasePrato pratoAntigo)
        {
            string prato = Aprender("Qual prato você pensou?", "Desisto");
            string habilidade = Aprender($"{prato} é _______ mas {pratoAntigo.Descricao} não.", "Complete");

            return AdicionarNovoPrato(pratoAntigo, prato, habilidade);
        }

        public string Aprender(string textoPergunta, string textoCaption)
        {
            Form2 form2 = new Form2();
            form2.Text = textoCaption;
            form2.lblTexto.Text = textoPergunta;

            form2.ShowDialog();

            return form2.txtResult.Text;
        }
               
        private PerguntarPrato AdicionarNovoPrato(BasePrato pratoAntigo, string prato, string habilidade)
        {
            Prato novoAnimal = new Prato( this, prato);
            return new PerguntarPrato(novoAnimal, pratoAntigo, habilidade, this);
        }
        
        public bool MostraPergunta(string pergunta, string carac)
        {
            return Interagir(pergunta + carac);
        }

        public bool IsPerguntaValida(DialogResult pergunta)
        {
            return pergunta == DialogResult.Yes;
        }

        public bool Interagir(string pergunta)
        {
            return DialogResult.Yes == MostrarPergunta(pergunta);
        }

        public DialogResult MostrarPergunta(string pergunta)
        {
            return MessageBox.Show($"{ pergunta}?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        

        public void Acertou()
        {
            MessageBox.Show("Acertei de novo!", "Jogo Gourmet",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
    }
}
