using ApiCatalogoLivros.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoLivros.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        private static Dictionary<Guid, Livro> livros = new Dictionary<Guid, Livro>()
        {
            {Guid.Parse("0ca314a5-9282-45d8-92c3-2985f2a9fd04"), new Livro{ Id = Guid.Parse("0ca314a5-9282-45d8-92c3-2985f2a9fd04"), Titulo = "Harry POtter e a Pedra Filosofal", Produtora = "Bloomsbury",Escritora = "J. K. Rowling", Preco = 100} },
            {Guid.Parse("5e99c84a-108b-4dfa-ab7e-d8c55957a7ec"), new Livro{ Id = Guid.Parse("5e99c84a-108b-4dfa-ab7e-d8c55957a7ec"), Titulo = "Dom Quixote, Miguel De Cervantes (1612)", Produtora = "Raven", Escritora = "Miguel Cervantes", Preco = 60} },
            {Guid.Parse("da033439-f352-4539-879f-515759312d53"), new Livro{ Id = Guid.Parse("da033439-f352-4539-879f-515759312d53"), Titulo = "Um Conto de Duas Cidades, Charles Dickens (1859)", Produtora = "Principis",Escritora = "Charles Dickens", Preco = 90} },
            {Guid.Parse("92576bd2-388e-4f5d-96c1-8bfda6c5a268"), new Livro{ Id = Guid.Parse("92576bd2-388e-4f5d-96c1-8bfda6c5a268"), Titulo = "O Senhor dos Anéis, J. R. R. Tolkien (1954)", Produtora = "HarperCollins", Escritora = "J.R.R. Tolkien", Preco = 80} },
            {Guid.Parse("eb909ced-1862-4789-8641-1bba36c23db3"), new Livro{ Id = Guid.Parse("eb909ced-1862-4789-8641-1bba36c23db3"), Titulo = "O Pequeno Príncipe", Produtora = "Lafonte", Escritora = "Antoine de Saint-Exupéry", Preco = 80} },
            {Guid.Parse("c3c9b5da-6a45-4de1-b28b-491cbf83b589"), new Livro{ Id = Guid.Parse("c3c9b5da-6a45-4de1-b28b-491cbf83b589"), Titulo = "O Código de Vinci, Dan Brown (2003)", Produtora = "Arqueiro",Escritora = "Dan Brown", Preco = 120} }
        };

        public Task<List<Livro>> Obter(int pagina, int quantidade)
        {
            return Task.FromResult(livros.Values.Skip((pagina - 1) * quantidade).Take(quantidade).ToList());
        }

        public Task<Livro> Obter(Guid id)
        {
            if (!livros.ContainsKey(id))
                return Task.FromResult<Livro>(null);

            return Task.FromResult(livros[id]);
        }

        public Task<List<Livro>> Obter(string titulo, string produtora, string escritora)
        {
            return Task.FromResult(livros.Values.Where(livro => livro.Titulo.Equals(titulo) && livro.Produtora.Equals(produtora) && livro.Escritora.Equals(escritora)).ToList());
        }

        public Task<List<Livro>> ObterSemLambda(string nome, string produtora, string escritora)
        {
            var retorno = new List<Livro>();

            foreach (var livro in livros.Values)
            {
                if (livro.Titulo.Equals(nome) && livro.Produtora.Equals(produtora) && livro.Escritora.Equals(escritora))
                    retorno.Add(livro);
            }

            return Task.FromResult(retorno);
        }

        public Task Inserir(Livro livro)
        {
            livros.Add(livro.Id, livro);
            return Task.CompletedTask;
        }

        public Task Atualizar(Livro livro)
        {
            livros[livro.Id] = livro;
            return Task.CompletedTask;
        }

        public Task Remover(Guid id)
        {
            livros.Remove(id);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            //Fechar conexão com o banco
        }
    }
}
