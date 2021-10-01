using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoLivros.Excepitions
{
    public class LivroNaoCadastradoException : Exception
    {

        public LivroNaoCadastradoException()
            :base("Este livro não esta cadastrado")
        { }
    }
}
