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
        int countPratos = 0;

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
                Perguntar(ret, listaPadrao);
            }
            else
            {
                Perguntar(ret, listaAlternativa);
            }

            if (formDialog != null)
                formDialog.Dispose();
        }       

        private void Perguntar(DialogResult ret, List<Prato> listaPratos)
        {
            if (listaPratos.Count == 1)
            {
                PerguntarPrato(listaPratos[0], listaPratos);
            }
            else
            {
                int i = 1;
                for (i = 1; i < listaPratos.Count; i++)
                {

                    if (listaPratos.Count == i + 1 && listaPratos.Count > 2)
                    {
                        ret = PerguntarPrato($"O prato que você pensou é {listaPratos[0].NomePrato}?", "Confirm");
                        if (ret == DialogResult.Yes)
                        {
                            Acertou();
                            break;
                        }
                    }
                    else
                        ret = PerguntarPrato($"O prato que você pensou é {listaPratos[i].Caracteristica}?", "Confirm");

                    if (ret == DialogResult.Yes)
                    {
                        //($"O prato que você pensou é {listaPratos[i].Caracteristica}?", "Confirm");
                        PerguntarPrato(listaPratos[i], listaPratos);
                        break;
                    }
                    else
                    {
                        if (i == listaPratos.Count - 1)
                        {
                            Desistir("Desisto", "Qual prato você pensou ?", listaPratos[0], listaPratos);
                            break;
                        }
                    }
                }
            }
        }


        private bool PerguntarPrato(Prato prato, List<Prato> listaPratos)
        {
            bool acertei = false;
            var ret = PerguntarPrato($"O prato que você pensou é {prato.NomePrato}?", "Confirm");

            if (ret == DialogResult.Yes)
            {
                Acertou();

                acertei = true;
            }
            else
            {
                if (listaPratos.Count > 0 && listaPratos.Count > countPratos + 1)
                {
                    countPratos++;
                    acertei = PerguntarPrato(listaPratos[0], listaPratos);
                }

                if (!acertei)
                {
                    Desistir("Desisto", "Qual prato você pensou ?", prato, listaPratos);
                    acertei = true;
                }
            }

            return acertei;
        }

        private DialogResult PerguntarPrato(string mensagem, string caption)
        {
            return MessageBox.Show(mensagem, caption,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private void Desistir(string caption, string textoLabel, Prato prato, List<Prato> listaPratos)
        {
            formDialog = new Form2();
            formDialog.Text = caption;
            formDialog.lblTexto.Text = textoLabel;

            var ret = formDialog.ShowDialog(this);

            var novoPrato = new Prato();
            if (string.IsNullOrWhiteSpace(formDialog.txtResult.Text))
                novoPrato.NomePrato = "null";
            else
                novoPrato.NomePrato = formDialog.txtResult.Text;

            formDialog.txtResult.Text = string.Empty;
            textoLabel = $" {novoPrato.NomePrato} é ________ mas {prato.NomePrato} não.";


            // Completar dados do prato
            formDialog.Text = caption;
            formDialog.lblTexto.Text = textoLabel;

            ret = formDialog.ShowDialog(this);

            if (ret == DialogResult.OK)
            {
                textoRetorno = formDialog.txtResult.Text;

                novoPrato.Caracteristica = textoRetorno;

                listaPratos.Add(novoPrato);

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
