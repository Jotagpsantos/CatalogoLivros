using ApiCatalogoLivros.Controllers.V1;
using ApiCatalogoLivros.Entities;
using ApiCatalogoLivros.Excepitions;
using ApiCatalogoLivros.InputModel;
using ApiCatalogoLivros.Repositories;
using ApiCatalogoLivros.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoLivros.Services
{
    public class LivroService : ILivroService
    {
        private readonly ILivroRepository _livroRepository;

        public LivroService(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public async Task<List<LivroViewModel>> Obter(int pagina, int quantidade)
        {
            var livros = await _livroRepository.Obter(pagina, quantidade);

            return livros.Select(livro => new LivroViewModel
            {
                Id = livro.Id,
                Titulo = livro.Titulo,
                Produtora = livro.Produtora,
                Escritora = livro.Escritora,
                Preco = livro.Preco
            })
                               .ToList();
        }

        public async Task<LivroViewModel> Obter(Guid id)
        {
            var livro = await _livroRepository.Obter(id);

            if (livro == null)
                return null;

            return new LivroViewModel
            {
                Id = livro.Id,
                Titulo = livro.Titulo,
                Produtora = livro.Produtora,
                Escritora = livro.Escritora,
                Preco = livro.Preco
            };
        }

        public async Task<LivroViewModel> Inserir(LivroInputModel livro)
        {
            var entidadeLivro = await _livroRepository.Obter(livro.Titulo, livro.Produtora, livro.Escritora);

            if (entidadeLivro.Count > 0)
                throw new LivroJaCadastradoException();

            var livroInsert = new Livro
            {
                Id = Guid.NewGuid(),
                Titulo = livro.Titulo,
                Produtora = livro.Produtora,
                Escritora = livro.Escritora,
                Preco = livro.Preco
            };

            await _livroRepository.Inserir(livroInsert);

            return new LivroViewModel
            {
                Id = livroInsert.Id,
                Titulo = livro.Titulo,
                Produtora = livro.Produtora,
                Escritora = livro.Escritora,
                Preco = livro.Preco
            };
        }

        public async Task Atualizar(Guid id, LivroInputModel livro)
        {
            var entidadeLivro = await _livroRepository.Obter(id);

            if (entidadeLivro == null)
                throw new LivroNaoCadastradoException();

            entidadeLivro.Titulo = livro.Titulo;
            entidadeLivro.Produtora = livro.Produtora;
            entidadeLivro.Escritora = livro.Escritora;
            entidadeLivro.Preco = livro.Preco;

            await _livroRepository.Atualizar(entidadeLivro);
        }

        public async Task Atualizar(Guid id, double preco)
        {
            var entidadeLivro = await _livroRepository.Obter(id);

            if (entidadeLivro == null)
                throw new LivroNaoCadastradoException();

            entidadeLivro.Preco = preco;

            await _livroRepository.Atualizar(entidadeLivro);
        }

        public async Task Remover(Guid id)
        {
            var livro = await _livroRepository.Obter(id);

            if (livro == null)
                throw new LivroNaoCadastradoException();

            await _livroRepository.Remover(id);
        }

        public void Dispose()
        {
            _livroRepository?.Dispose();
        }

       
    }
}

