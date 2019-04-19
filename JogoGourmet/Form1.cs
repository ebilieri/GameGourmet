using System;
using System.Windows.Forms;

namespace JogoGourmet
{
    public partial class Form1 : Form
    {
        private PerguntarPrato habilidade;

        public Form1()
        {
            InitializeComponent();            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {            
            habilidade.Executar(habilidade);            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Instancia classe para apresentação das mensagens em tela
            InteracaoPorWindowsForm interacaoComUsuario = new InteracaoPorWindowsForm();

            //Classe aprende, responsavel por fazer a criação da nova habilidade e do prato
            Aprende aprende = new Aprende(interacaoComUsuario);

            //preserva o prato da resposta sim em todos os laços
            //AfirmaVitoria afirmaVitoria = new AfirmaVitoria(interacaoComUsuario);
            PratoService pratoService = new PratoService();

            //Cria prato para primeira execução do jogo
            Prato pratoPadrao = new Prato(pratoService, aprende, "Lasanha", interacaoComUsuario);
            Prato pratoAlternativo = new Prato(pratoService, aprende, "Bolo de Chocolate", interacaoComUsuario);

            //Cria habilidade para primeira execução do jogo
            habilidade = new PerguntarPrato(pratoPadrao, pratoAlternativo, "massa", interacaoComUsuario);
        }
    }
}
