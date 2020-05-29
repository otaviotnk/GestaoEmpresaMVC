using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoEmpresaMVC.Models
{
    public class Client
    {
        public int Id { get; set; }
        public int Cpf { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int SalesRecord { get; set; }

        //Propriedades de Endereco
        //Enderecço vem de outra classe pra utilizar a API? ou várias propriedades? Estado, Cidade, Rua....
        public int Cep { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public int Number { get; set; }
        public string Complement { get; set; }

    }
}
