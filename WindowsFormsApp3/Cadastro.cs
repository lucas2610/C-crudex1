using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    public class Cadastro
    {
        Conexao conexao = new Conexao();
        SqlCommand cmd = new SqlCommand();
        public String mensagem="";
        public String teste = "";
        public String teste2 = "";

        public Cadastro(String nome, String telefone)
        {
            //Comando Sql para insert, update, delete.---SqlCommand
            cmd.CommandText = "insert into ex(nome,telefone) values(@nome,@telefone)";
            //Parâmetros 
           // this.teste = telefone;
            cmd.Parameters.AddWithValue("@nome",nome);
            cmd.Parameters.AddWithValue("@telefone", telefone);
            //Conectar com o bd---Conexao
            try
            {
                cmd.Connection = conexao.conectar();
                //Executar comando
                cmd.ExecuteNonQuery();
                
                //Desconectar
                conexao.desconectar();
                //Mostrar msg erro ou sucesso---variável
                this.mensagem = "Cadastrado com Sucesso";
            }
            catch (SqlException e)
            {
                this.mensagem = "Erro no cadastro";
            }
          
           
           
        }
    }
}
