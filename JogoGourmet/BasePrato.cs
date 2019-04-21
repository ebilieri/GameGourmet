namespace JogoGourmet
{
    public abstract class BasePrato
    {
        public string Descricao { get; }

        public BasePrato(string descricao)
        {
            Descricao = descricao;
        }

        public abstract BasePrato Perguntar();
    }
}
