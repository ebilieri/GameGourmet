namespace JogoGourmet
{
    public abstract class BasePrato
    {        
        public string NomePrato { get; }

        public BasePrato(string nomePrato)
        {
            NomePrato = nomePrato;           
        }
        
        public abstract BasePrato Perguntar();                      
    }
}
