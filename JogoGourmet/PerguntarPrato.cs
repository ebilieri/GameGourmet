namespace JogoGourmet
{
    public class PerguntarPrato : BasePrato
    {
        private const string _PERGUNTA = "O prato que você pensou é ";
        private BasePrato _respostaSim;
        private BasePrato _respostaNao;
        private PratoService _pratoService;

        public PerguntarPrato(BasePrato respostaSim, BasePrato respostaNao, string caracteristica, PratoService pratoService)
            : base(caracteristica)
        {
            _respostaSim = respostaSim;
            _respostaNao = respostaNao;
            _pratoService = pratoService;
        }

        public override BasePrato Perguntar(BasePrato acao)
        {
            //Mostra a pergunta com a habilidade para tentar advinhar o prato
            //em caso qualquer das resposta, é aqui que acontece a mágia do jogo
            //ao atribuir o retorno o método Executar para _respostaSim e _respostaNao
            //o código substitui o nó de prato por um nó de habilidade, fazendo com
            //que o nó de prato se torne a resposta não do prato pensado.
            if (_pratoService.MostraPergunta(_PERGUNTA, Descricao))
                _respostaSim = _respostaSim.Perguntar(null);
            else
                _respostaNao = _respostaNao.Perguntar(null);

            return this;
        }

        

        
    }
}
