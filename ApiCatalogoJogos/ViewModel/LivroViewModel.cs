using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoLivros.ViewModel
{
    public class LivroViewModel
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Produtora { get; set; }
        public string Escritora { get; set; }
        public double Preco { get; set; }
    }
}
