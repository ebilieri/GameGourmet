using System;
using System.Windows.Forms;

namespace JogoGourmet
{
    public partial class Form1 : Form
    {
        private PratoFilho perguntar;
        private Prato pratoPadrao;
        private Prato pratoAlternativo;
        private IPratoService pratoService;

        public Form1()
        {
            InitializeComponent();
            pratoService = new PratoService();

            //Criar nó do prato sim para primeira execução do jogo
            pratoPadrao = new Prato(pratoService, "Lasanha");
            // Criar nó do prato não primeira execução do jogo
            pratoAlternativo = new Prato(pratoService, "Bolo de Chocolate");

            //Apresentar prato na primeira execução do jogo
            perguntar = new PratoFilho(pratoPadrao, pratoAlternativo, "massa", pratoService);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            perguntar.Perguntar();
        }
    }
}
