namespace JogoGourmet
{
    public class Prato : Acao
    {
        private const string _PERGUNTA = "O prato que você pensou é ";
        private PratoService _pratoService;
        private Acao _armazenaPrato;

        public Prato(PratoService pratoService, Aprende aprende, string descricao)
            : base(descricao)
        {
            _pratoService = pratoService;
            _armazenaPrato = aprende;
        }

        public override Acao Perguntar(Acao habilidade)
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
                return _armazenaPrato.Perguntar(this);
            }
        }
    }
}
