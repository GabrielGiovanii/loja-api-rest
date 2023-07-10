using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Veiculo
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Marca é obrigatória.")]
        [StringLength(50, ErrorMessage = "Marca não pode ser maior que 50 caracteres.")]
        public string Marca { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "Nome não pode ser maior que 100 caracteres.")]
        public string Nome { get; set; }

        /*[Required(ErrorMessage = "Ano do modelo é obrigatório.")]*/
        [Range(1, 2147483647, ErrorMessage = "Ano do modelo está fora do range permitido: 1 a 2.147.483.647")]
        public int AnoModelo { get; set; }

        /*[Required(ErrorMessage = "Data de fabricação é obrigatório.")]*/
        public DateTime DataFabricacao { get; set; }

        /*[Required(ErrorMessage = "Valor é obrigatório.")]*/
        [Range(0.01, 999999.99, ErrorMessage = "Valor está fora do range permitido: 0.01 a 999999.99")]
        public double Valor { get; set; }

        [StringLength(500, ErrorMessage = "Opcional não pode ser maior que 500 caracteres.")]
        public string Opcional { get; set; }

        public Veiculo()
        {
            Id = 0;
            Marca = "";
            Nome = "";
            AnoModelo = 0;
            DataFabricacao = new DateTime(1, 1, 1);
            Valor = 0;
            Opcional = null;
        }
    }
}
