using System;
using System.Windows.Forms;

namespace JogoGourmet
{
    public partial class Form1 : Form
    {
        //private Aprende aprende;
        private PerguntarPrato perguntar;

        Prato pratoPadrao;
        Prato pratoAlternativo;

        private PratoService pratoService;

        public Form1()
        {
            InitializeComponent();   
             pratoService = new PratoService();

            //Classe aprende, responsavel por fazer a criação da nova habilidade e do prato
           // aprende = new Aprende(pratoService);

            //preserva o prato da resposta sim em todos os laços
            //AfirmaVitoria afirmaVitoria = new AfirmaVitoria(interacaoComUsuario);


            //Cria prato para primeira execução do jogo
             pratoPadrao = new Prato(pratoService, "Lasanha");
             pratoAlternativo = new Prato(pratoService, "Bolo de Chocolate");

            //Cria habilidade para primeira execução do jogo
            perguntar = new PerguntarPrato(pratoPadrao, pratoAlternativo, "massa", pratoService);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {            
            perguntar.Perguntar(null);            
        }

        
    }
}
