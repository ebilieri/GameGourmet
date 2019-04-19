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
        private Form2 _formDialog;
        private Form1 _formOwner;
        private string textoRetorno;
        private int countPratos = 0;


        //public PratoService(Form2 formDialog, Form1 formOwner)
        //{
        //    _formDialog = formDialog;
        //    _formOwner = formOwner;
        //}

        //public void Perguntar(DialogResult ret, List<Prato> listaPratos)
        //{
        //    if (listaPratos.Count == 1)
        //    {
        //        PerguntarPrato(listaPratos[0], listaPratos);
        //    }
        //    else
        //    {
        //        int i = 1;
        //        for (i = 1; i < listaPratos.Count; i++)
        //        {

        //            if (listaPratos.Count == i + 1 && listaPratos.Count > 2)
        //            {
        //                ret = PerguntarPrato($"O prato que você pensou é {listaPratos[0].NomePrato}?", "Confirm");
        //                if (ret == DialogResult.Yes)
        //                {
        //                    Acertou();
        //                    break;
        //                }
        //            }
        //            else
        //                ret = PerguntarPrato($"O prato que você pensou é {listaPratos[i].Caracteristica}?", "Confirm");

        //            if (ret == DialogResult.Yes)
        //            {
        //                //($"O prato que você pensou é {listaPratos[i].Caracteristica}?", "Confirm");
        //                PerguntarPrato(listaPratos[i], listaPratos);
        //                break;
        //            }
        //            else
        //            {
        //                if (i == listaPratos.Count - 1)
        //                {
        //                    Desistir("Desisto", "Qual prato você pensou ?", listaPratos[0], listaPratos);
        //                    break;
        //                }
        //            }
        //        }
        //    }
        //}

        //public bool PerguntarPrato(Prato prato, List<Prato> listaPratos)
        //{
        //    bool acertei = false;
        //    var ret = PerguntarPrato($"O prato que você pensou é {prato.NomePrato}?", "Confirm");

        //    if (ret == DialogResult.Yes)
        //    {
        //        Acertou();

        //        acertei = true;
        //    }
        //    else
        //    {
        //        if (listaPratos.Count > 0 && listaPratos.Count > countPratos + 1)
        //        {
        //            countPratos++;
        //            acertei = PerguntarPrato(listaPratos[0], listaPratos);
        //        }

        //        if (!acertei)
        //        {
        //            Desistir("Desisto", "Qual prato você pensou ?", prato, listaPratos);
        //            acertei = true;
        //        }
        //    }

        //    return acertei;
        //}

        //public DialogResult PerguntarPrato(string mensagem, string caption)
        //{
        //    return MessageBox.Show(mensagem, caption,
        //        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        //}

        //private void Desistir(string caption, string textoLabel, Prato prato, List<Prato> listaPratos)
        //{
        //    _formDialog = new Form2();
        //    _formDialog.Text = caption;
        //    _formDialog.lblTexto.Text = textoLabel;

        //    var ret = _formDialog.ShowDialog(_formOwner);

        //    var novoPrato = new Prato();
        //    if (string.IsNullOrWhiteSpace(_formDialog.txtResult.Text))
        //        novoPrato.NomePrato = "null";
        //    else
        //        novoPrato.NomePrato = _formDialog.txtResult.Text;

        //    _formDialog.txtResult.Text = string.Empty;
        //    textoLabel = $" {novoPrato.NomePrato} é ________ mas {prato.NomePrato} não.";


        //    // Completar dados do prato
        //    _formDialog.Text = caption;
        //    _formDialog.lblTexto.Text = textoLabel;

        //    ret = _formDialog.ShowDialog(_formOwner);

        //    if (ret == DialogResult.OK)
        //    {
        //        textoRetorno = _formDialog.txtResult.Text;

        //        novoPrato.Caracteristica = textoRetorno;

        //        listaPratos.Add(novoPrato);

        //    }
        //    else
        //    {
        //        textoRetorno = null;
        //    }

        //    _formDialog.Dispose();
        //}
        public string aprender(string textoPergunta, string textoCaption)
        {
            Form2 form2 = new Form2();
            form2.Text = textoCaption;
            form2.lblTexto.Text = textoPergunta;

            form2.ShowDialog();

            //string retorno = form2.txtResult.Text
            return form2.txtResult.Text;
        }

        public void Acertou()
        {
            MessageBox.Show("Acertei de novo!", "Jogo Gourmet",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
    }
}
