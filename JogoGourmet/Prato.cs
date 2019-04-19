namespace JogoGourmet
{
    public class Prato :Acao
    {
        private const string _PERGUNTA = "O prato que você pensou foi ";
        private PratoService _pratoService;
        private Acao aprende;

        public Prato(PratoService pratoService, Aprende aprende, string descricao, InteracaoPorWindowsForm interacaoComUsuario)
            : base(descricao, interacaoComUsuario)
        {
            this._pratoService = pratoService;
            this.aprende = aprende;
        }

        public override Acao Executar(Acao habilidade)
        {
            //Mostra pergunta para tentar advinhar o prato, caso advinhe o jogo ganha.
            //Em caso de erro, o jogo pede para ser ensinado retornando assim o nó de
            //habilidade e prato aprendido
            if (MostraPergunta(_PERGUNTA, Descricao))
            {
                // return this.afirmaVitoria.Executar(this);
                _pratoService.Acertou();
                return this;
            }
            else
                return aprende.Executar(this);
        }
    }
}
