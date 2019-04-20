using System.Windows.Forms;

namespace JogoGourmet
{
    public class PratoService
    {
        public BasePrato Aprender(BasePrato pratoAntigo)
        {
            string nomePrato = Aprender("Qual prato você pensou?", "Desisto");
            string caracteristica = Aprender($"{nomePrato} é _______ mas {pratoAntigo.NomePrato} não.", "Complete");

            return AdicionarNovoPrato(pratoAntigo, nomePrato, caracteristica);
        }

        public string Aprender(string textoPergunta, string textoCaption)
        {
            Form2 form2 = new Form2();
            form2.Text = textoCaption;
            form2.lblTexto.Text = textoPergunta;

            form2.ShowDialog();

            return form2.txtResult.Text;
        }

        private PerguntarPrato AdicionarNovoPrato(BasePrato pratoAntigo, string nomePrato, string caracteristica)
        {
            Prato novoPrato = new Prato(this, nomePrato);
            return new PerguntarPrato(novoPrato, pratoAntigo, caracteristica, this);
        }

        public bool MostraPergunta(string pergunta, string caracteristica)
        {
            return Interagir(pergunta + caracteristica);
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
            MessageBox.Show("Acertei de novo!", "Jogo Gourmet", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
    }
}
