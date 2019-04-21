using System;
using System.Windows.Forms;

namespace JogoGourmet
{
    public partial class Form1 : Form
    {        
        private PerguntaPrato perguntar;
        private Prato pratoPadrao;
        private Prato pratoAlternativo;
        private IPratoService pratoService;

        public Form1()
        {
            InitializeComponent();   
             pratoService = new PratoService();
            
            //Cria prato para primeira execução do jogo
             pratoPadrao = new Prato(pratoService, "Lasanha");
             pratoAlternativo = new Prato(pratoService, "Bolo de Chocolate");

            //Apresenta prato na primeira execução do jogo
            perguntar = new PerguntaPrato(pratoPadrao, pratoAlternativo, "massa", pratoService);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {            
            perguntar.Perguntar();            
        }        
    }
}
