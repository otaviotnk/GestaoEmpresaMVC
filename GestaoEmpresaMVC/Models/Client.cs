using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoEmpresaMVC.Models
{
    public class Client
    {
        public int Id { get; set; }

        [DisplayName("CPF")]
        [Required(ErrorMessage = "Informe um CPF.")]
        public string Cpf { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "Informe um nome.")]
        public string Name { get; set; }

        [DisplayName("Data Nascimento")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime BirthDate { get; set; }

        [DisplayName("Sexo")]
        [Required(ErrorMessage = "Informe um sexo.")]
        public string Gender { get; set; }

        [DisplayName("Telefone")]
        [Required(ErrorMessage = "Informe um número de telefone.")]
        public string Phone { get; set; }
        
        [DisplayName("E-mail")]
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "DDDDD")]
        public string Email { get; set; }

        //Propriedades de Endereco
        //Enderecço vem de outra classe pra utilizar a API? ou várias propriedades? Estado, Cidade, Rua....
        [DisplayName("CEP")]
        [Required(ErrorMessage = "Informe um CEP.")]
        [MaxLength(9)]
        public string Cep { get; set; }

        [DisplayName("Estado")]
        [Required(ErrorMessage = "Informe um estado.")]
        public string State { get; set; }

        [DisplayName("Cidade")]
        [Required(ErrorMessage = "Informe uma cidade.")]
        public string City { get; set; }

        [DisplayName("Bairro")]
        [Required(ErrorMessage = "Informe um bairro.")]
        public string District { get; set; }

        [DisplayName("Logradouro")]
        [Required(ErrorMessage = "Informe um logradouro.")]
        public string Address { get; set; }

        [DisplayName("Número")]
        [Required(ErrorMessage = "Informe o número da residência.")]
        public int Number { get; set; }

        [DisplayName("Complemento")]
        public string Complement { get; set; }

    }
}
