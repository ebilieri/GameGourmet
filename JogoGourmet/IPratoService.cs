using System.Windows.Forms;

namespace JogoGourmet
{
    public interface IPratoService
    {
        BasePrato Aprender(BasePrato pratoAntigo);

        string Aprender(string textoPergunta, string textoCaption);

        PerguntaPrato AdicionarNovoPrato(BasePrato pratoAntigo, string nomePrato, string caracteristica);

        bool Perguntar(string pergunta);

        bool Perguntar(string pergunta, string caracteristica);        
       
        DialogResult ObterResposta(string pergunta);

        void Encerrar();        
    }
}
