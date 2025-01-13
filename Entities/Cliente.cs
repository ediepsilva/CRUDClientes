using System.Regex;
using System.Text.RegularExpressions;
using Regex = System.Regex.Regex;

namespace Projeto06.Entities
{
    public class Cliente
    {
        private Guid _id;
        private string _nome;
        private string _cpf;
        private DateTime _dataNascimento;

    
        public Cliente()
        {
            Id = Guid.NewGuid();
        }
	
        public Guid Id { get => _id; set => _id = value; }
        public string Nome { get => _nome;
            set
    {
                if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Nome do cliente é obrigatório.");
                var regex = new Regex("^[A-Za-zÀ-Üà-ü\\s]{8,100}$");
                if (!regex.IsMatch(value))
                throw new ArgumentException("Nome do cliente inválido. Informe de 8 a 100 caracteres.");
                _nome = value;
}
    }
         public string Cpf
        {
            get => _cpf;
            set
            {


                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException
                   ("CPF do cliente é obrigatório.");
                    //    var regex = new Regex("^[0-9]{11}$");
                    //}
                    //if (!regexIsMatch(value))
                    //{
                    //    throw new ArgumentException("CPF do cliente inválido. Informe exatamente 11 números.");

                    _cpf = value;
                }
            }
        }
        public DateTime DataNascimento
        {
            get => _dataNascimento;
            set
            {
                var dataAtual = DateTime.Now; //capturando a data atual
                var idade = dataAtual.Year - value.Year; //idade
                if (idade <= 18 && value > dataAtual.AddYears(-idade))
                    throw new ArgumentException("O cliente não pode ser menor de idade.");
           
                    _dataNascimento = value;
            }
        }
    }
}


