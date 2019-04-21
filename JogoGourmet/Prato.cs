namespace JogoGourmet
{
    public class Prato : BasePrato
    {
        private const string _PERGUNTA = "O prato que você pensou é ";
        private IPratoService _pratoService;

        public Prato(IPratoService pratoService, string descricao)
            : base(descricao)
        {
            _pratoService = pratoService;
        }

        public override BasePrato Perguntar()
        {
            // Perguntar prato
            if (_pratoService.Perguntar(_PERGUNTA, Descricao))
            {
                // Encerrar jogo ao acertar
                _pratoService.Encerrar();
                return this;
            }
            else
            {
                // armazenar o prato informado, Aprender Prato
                return _pratoService.Aprender(this);
            }
        }
    }
}
