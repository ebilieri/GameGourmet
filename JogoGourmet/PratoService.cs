using System.Windows.Forms;

namespace JogoGourmet
{
    public class PratoService : IPratoService
    {
        public BasePrato Aprender(BasePrato pratoAntigo)
        {
            string nomePrato = Aprender("Qual prato você pensou?", "Desisto");
            string caracteristica = Aprender($"{nomePrato} é _______ mas {pratoAntigo.Descricao} não.", "Complete");

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

        public PerguntaPrato AdicionarNovoPrato(BasePrato pratoAntigo, string nomePrato, string caracteristica)
        {
            Prato novoPrato = new Prato(this, nomePrato);
            return new PerguntaPrato(novoPrato, pratoAntigo, caracteristica, this);
        }

        public bool Perguntar(string pergunta)
        {
            return DialogResult.Yes == ObterResposta(pergunta);
        }

        public bool Perguntar(string pergunta, string caracteristica)
        {
            return Perguntar(pergunta + caracteristica);
        }        
       
        public DialogResult ObterResposta(string pergunta)
        {
            return MessageBox.Show($"{ pergunta}?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public void Encerrar()
        {
            MessageBox.Show("Acertei de novo!", "Jogo Gourmet", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }        
    }
}