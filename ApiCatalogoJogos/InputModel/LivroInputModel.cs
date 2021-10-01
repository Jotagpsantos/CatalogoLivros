using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoLivros.InputModel
{
    public class LivroInputModel
    {
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O Titulo do livro de conter  entre 3 e 100 caraceteres")]
        public string Titulo { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "O Nome da produtora do livro de conter  entre 1 e 100 caraceteres")]
        public string Produtora { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "O Nome da escritora do livro de conter  entre 1 e 100 caraceteres")]
        public string Escritora { get; set; }
        [Required]
        [Range(1, 1000, ErrorMessage = "O preço do livro deve ser no minimo 1 real e no maximo 1000 reais")]
        public double Preco  { get; set; }

    }
}
