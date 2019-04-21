namespace JogoGourmet
{
    public class PratoFilho : BasePrato
    {
        private const string _PERGUNTA = "O prato que você pensou é ";
        private BasePrato _respostaSim;
        private BasePrato _respostaNao;
        private IPratoService _pratoService;

        public PratoFilho(BasePrato respostaSim, BasePrato respostaNao, string descricao, IPratoService pratoService)
            : base(descricao)
        {
            _respostaSim = respostaSim;
            _respostaNao = respostaNao;
            _pratoService = pratoService;
        }

        public override BasePrato Perguntar()
        {
            /*
             * Mostra a pergunta com a caracteristica para tentar advinhar o prato            
             * atribuir o retorno ao método Pergutar para _respostaSim e _respostaNao
             * o código substitui o nó de prato por um nó de caracteristica, fazendo com
             * que o nó de prato se torne a resposta não do prato pensado.
             */
            if (_pratoService.Perguntar(_PERGUNTA, Descricao))
                _respostaSim = _respostaSim.Perguntar();
            else
                _respostaNao = _respostaNao.Perguntar();

            return this;
        }

        

        
    }
}
