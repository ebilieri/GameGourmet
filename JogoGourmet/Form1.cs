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
        

        public Form1()
        {
            InitializeComponent();
            formDialog = new Form2();
            listaAlternativa = new List<Prato>();
            listaAlternativa.Add(new Prato { NomePrato = "Bolo de Chocolate" });

            listaPadrao = new List<Prato>();
            listaPadrao.Add(new Prato { NomePrato = "Lasanha" });
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            PratoService pratoService = new PratoService(formDialog, this);
            var ret = pratoService.PerguntarPrato("O prato que pensou é massa?", "Confirm");

            if (ret == DialogResult.Yes)
            {
                pratoService.Perguntar(ret, listaPadrao);
            }
            else
            {
                pratoService.Perguntar(ret, listaAlternativa);
            }

            if (formDialog != null)
                formDialog.Dispose();
        }       

       
    }
}
