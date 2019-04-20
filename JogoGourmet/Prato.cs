namespace JogoGourmet
{
    public class Prato : BasePrato
    {
        private const string _PERGUNTA = "O prato que você pensou é ";
        private PratoService _pratoService;
        
        public Prato(PratoService pratoService, string nomePrato)
            : base(nomePrato)
        {
            _pratoService = pratoService;            
        }

        public override BasePrato Perguntar()
        {
            // Perguntar prato
            if (_pratoService.MostraPergunta(_PERGUNTA, Descricao))
            {
                _pratoService.Acertou();
                return this;
            }
            else
            {
                // armazenar o prato informado
                return _pratoService.Aprender(this);
            }
        }
    }
}
