using System.Collections.Generic;

namespace JogoGourmet
{
    public class Prato
    {
        public Prato()
        {
            Pratos = new List<Prato>();                 
        }

        public string Nome { get; set; }        

        public List<Prato> Pratos { get; set; }
    }
}
