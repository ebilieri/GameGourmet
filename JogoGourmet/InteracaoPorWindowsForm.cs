using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JogoGourmet
{
    public class InteracaoPorWindowsForm
    {
        public bool interagir(string pergunta)
        {
            return DialogResult.Yes == this.mostrarPergunta(pergunta);
        }

        //public void mostraVitoria()
        //{
        //    MessageBox.Show("Acertei de novo.", "Jogo Gourmet", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //}

        //public string aprender(string textoPergunta, string textoCaption)
        //{
        //    Form2 form2 = new Form2();
        //    form2.Text = textoCaption;
        //    form2.lblTexto.Text = textoPergunta;

        //    form2.ShowDialog();

        //    //string retorno = form2.txtResult.Text
        //    return  form2.txtResult.Text;
        //}

        public DialogResult mostrarPergunta(string pergunta)
        {
            return MessageBox.Show($"{ pergunta} ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
    }
}
