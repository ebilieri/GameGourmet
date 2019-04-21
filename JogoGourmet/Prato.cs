namespace JogoGourmet
{
    public class Prato : BasePrato
    {
        private const string _PERGUNTA = "O prato que você pensou é ";
        private IPratoService _pratoService;
        
        public Prato(IPratoService pratoService, string nomePrato)
            : base(nomePrato)
        {
            _pratoService = pratoService;            
        }

        public override BasePrato Perguntar()
        {
            // Perguntar prato
            if (_pratoService.Perguntar(_PERGUNTA, Descricao))
            {
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
