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
        public string Cpf { get; set; }

        [DisplayName("Nome")]
        public string Name { get; set; }

        [DisplayName("Data Nascimento")]
        public DateTime BirthDate { get; set; }

        [DisplayName("Sexo")]
        public string Gender { get; set; }

        [DisplayName("Telefone")]
        public string Phone { get; set; }

        [DisplayName("E-mail")]
        public string Email { get; set; }

        //Propriedades de Endereco
        //Enderecço vem de outra classe pra utilizar a API? ou várias propriedades? Estado, Cidade, Rua....
        [DisplayName("CEP")]
        [MaxLength(9)]
        public string Cep { get; set; }

        [DisplayName("Estado")]
        public string State { get; set; }

        [DisplayName("Cidade")]
        public string City { get; set; }

        [DisplayName("Bairro")]
        public string District { get; set; }

        [DisplayName("Logradouro")]
        public string Address { get; set; }

        [DisplayName("Número")]
        public int Number { get; set; }

        [DisplayName("Complemento")]
        public string Complement { get; set; }

    }
}
