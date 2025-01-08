using Dapper;
using Projeto06.Entities;
using System;
using System.Data.SqlClient;

namespace Projeto06.repositories
{
    internal class ClienteRepositores
    {
        public void Inserir(Cliente cliente)
        {
            //escrevendo o comando SQL que será executado no banco de dados
            var query = @"
 INSERT INTO CLIENTE(ID, NOME, CPF, DATANASCIMENTO)
 VALUES(@Id, @Nome, @Cpf, @DataNascimento)
 ";
            //abrindo conexão com o banco de dados
            using (var connection = new SqlConnection("  Integrated Security = True; ConnectTimeout = 30; Encrypt = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False"))

 {
                //executando o comando INSERT no banco de dados
                connection.Execute(query, cliente);
            }
        }
    }
}

