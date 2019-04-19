namespace JogoGourmet
{
    public class PerguntarPrato : Acao
    {
        private const string _PERGUNTA = "O prato que você pensou é ";
        private Acao _respostaSim;
        private Acao _respostaNao;

        public PerguntarPrato(Acao respostaSim, Acao respostaNao, string caracteristica, InteracaoPorWindowsForm interacaoComUsuario)
            : base(caracteristica, interacaoComUsuario)
        {
            _respostaSim = respostaSim;
            _respostaNao = respostaNao;
        }

        public override Acao Executar(Acao acao)
        {
            //Mostra a pergunta com a habilidade para tentar advinhar o prato
            //em caso qualquer das resposta, é aqui que acontece a mágia do jogo
            //ao atribuir o retorno o método Executar para _respostaSim e _respostaNao
            //o código substitui o nó de prato por um nó de habilidade, fazendo com
            //que o nó de prato se torne a resposta não do prato pensado.
            if (MostraPergunta(_PERGUNTA, Descricao))
                _respostaSim = _respostaSim.Executar(null);
            else
                _respostaNao = _respostaNao.Executar(null);

            return this;
        }

        
    }
}
