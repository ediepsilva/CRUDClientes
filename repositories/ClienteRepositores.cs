using Dapper;
using Projeto06.Entities;
using Projeto06.Setings;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace Projeto06.repositories
{ 
    public class ClienteRepositores
    {
        public void Inserir(Cliente cliente)
        {
            //escrevendo o comando SQL que será executado no banco de dados
            var query = @"
             INSERT INTO CLIENTE(ID, NOME, CPF, DATANASCIMENTO)
             VALUES(@Id, @Nome, @Cpf, @DataNascimento)
             ";
            //abrindo conexão com o banco de dados
           


            
       

               
        }
        //executando o comando INSERT no banco de dados

        public void atualizar(Cliente cliente)
        {
            var query = @"
                UPDATE CLIENTE
                    NOME @NOME
                    CPF = @CPF
                    DATA NASCIMENTO = @DATANASCIMENTO
                WHERE 
                    ID = @ID";
            using (var connection = new SqlConnection(SqlSettings.GetConnectionString()))

                connection.Execute(query, cliente);
        }
           
        public void excluir(Cliente cliente)
        {
            var query = @"
            SELECT FROM CLIENTE
            WHERE ID = @id "

         using (var connection = new SqlConnection(SqlSettings.GetConnectionString()))

                connection.Execute(query, cliente);
        }
        public List <Cliente> ObterTodos()
        {
            var query = @"
                SELECT * FROM CLIENTE
                ORDER BY NOME"

            using (var connection = new SqlConnection(SqlSettings.GetConnectionString()))

                return connection.Query<Cliente>(query). ToList();
        }
        public Cliente? ObterPorId(Guid id)
        {
            var query =@"
                SELECT * FROM CLIENTE
                WHER @ID = id

                "
            using (var connection = new SqlConnection(SqlSettings.GetConnectionString()))

                return connection.Query<Cliente>(query, new { @Id = id }).FirstOrDefault();
        }
            
    }

}