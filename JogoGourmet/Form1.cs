using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JogoGourmet
{
    public partial class Form1 : Form
    {
        Form2 formDialog;
        List<Prato> listaAlternativa;
        List<Prato> listaPadrao;
        string textoRetorno;

        public Form1()
        {
            InitializeComponent();
            
            listaAlternativa = new List<Prato>();
            listaAlternativa.Add(new Prato { NomePrato = "Bolo de Chocolate" });

            listaPadrao = new List<Prato>();
            listaPadrao.Add(new Prato { NomePrato = "Lasanha" });
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var ret = PerguntarPrato("O prato que pensou é massa?", "Confirm");

            if (ret == DialogResult.Yes)
            {
                ret = PerguntarPrato("O Prato que você pensou é Lasanha?", "Confirm");

                //listapadrao

                if (ret == DialogResult.Yes)
                {
                    Acertou();
                }
            }
            else
            {
                if (listaAlternativa.Count == 1)
                {
                    ret = PerguntarPrato(0);
                }
                else
                {
                    int i = 1;
                    for (i = 1; i < listaAlternativa.Count; i++)
                    {
                        ret = PerguntarPrato($"O prato que você pensou é {listaAlternativa[i].Caracteristica}?", "Confirm");

                        if (ret == DialogResult.Yes)
                        {
                            PerguntarPrato(i);
                            break;
                        }
                    }

                    if (ret != DialogResult.Yes)
                    {
                        PerguntarPrato(0);
                    }
                }
            }

            if (formDialog != null)
                formDialog.Dispose();
        }

        private DialogResult PerguntarPrato(int indice)
        {
            var ret = PerguntarPrato($"O prato que você pensou é {listaAlternativa[indice].NomePrato}?", "Confirm");

            if (ret == DialogResult.Yes)
            {
                Acertou();
            }
            else
            {
                Desistir("Desisto", "Qual prato você pensou ?");
            }

            return ret;
        }

        private DialogResult PerguntarPrato(string mensagem, string caption)
        {
            return MessageBox.Show(mensagem, caption,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private void Desistir(string caption, string textoLabel)
        {
            formDialog = new Form2();
            formDialog.Text = caption;
            formDialog.lblTexto.Text = textoLabel;

            var ret = formDialog.ShowDialog(this);

            var prato = new Prato();
            if (string.IsNullOrWhiteSpace(formDialog.txtResult.Text))
                prato.NomePrato = "null";
            else
                prato.NomePrato = formDialog.txtResult.Text;

            formDialog.txtResult.Text = string.Empty;
            textoLabel = $" {prato.NomePrato} é ________ Mas Bolo de Chocolate não.";

            Completar("Complete", textoLabel, prato);

            //if (ret == DialogResult.OK)
            //{
            //    //var prato = new Prato();
            //    //prato.NomePrato = formDialog.txtResult.Text;
            //    //formDialog.txtResult.Text = string.Empty;
            //    //textoLabel = $" {prato.NomePrato} é ________ Mas Bolo de Chocolate não.";

            //    //var prato = new Prato { NomePrato = textoRetorno };

            //    Complete("Complete", textoLabel, prato);
            //    //  $" {textoRetorno} é ________ Mas Bolo de Chocolate não.", ret);                
            //}
            //else
            //{
            //    //textoRetorno = formDialog.txtResult.Text;
            //    //formDialog.txtResult.Text = string.Empty;
            //    //textoLabel = $" {textoRetorno} é ________ Mas Bolo de Chocolate não.";

            //    //var prato = new Prato { NomePrato = null };
            //    Complete("Compelete", textoLabel, prato);
            //    //Desisto("Desisto", "Qual prato você pensou?");
            //}

            formDialog.Dispose();
        }

        private void Completar(string caption, string textoLabel, Prato prato)
        {
            formDialog.Text = caption;
            formDialog.lblTexto.Text = textoLabel;

            var ret = formDialog.ShowDialog(this);

            if (ret == DialogResult.OK)
            {
                textoRetorno = formDialog.txtResult.Text;

                prato.Caracteristica = textoRetorno;

                listaAlternativa.Add(prato);

            }
            else
            {
                textoRetorno = null;
            }

            formDialog.Dispose();
        }

        private void Acertou()
        {
            MessageBox.Show("Acertei de novo!", "Jogo Gourmet",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
    }
}
