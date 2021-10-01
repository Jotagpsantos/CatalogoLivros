using ApiCatalogoLivros.InputModel;
using ApiCatalogoLivros.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoLivros.Services
{
    public interface ILivroService
    {
       public Task<List<LivroViewModel>> Obter(int pagina, int quantidade);
        public Task<LivroViewModel> Obter(Guid id);
        public Task<LivroViewModel> Inserir(LivroInputModel livro);
        public Task Atualizar(Guid id, LivroInputModel livro);
        public Task Atualizar(Guid id, double preco);
        public Task Remover(Guid id);
    }
}
