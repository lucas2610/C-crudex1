using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void btnCadastrar_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void buttonCadastrar_Click(object sender, EventArgs e)
        {
            Cadastro cadastro = new Cadastro(textBoxNome.Text, textBoxTelefone.Text);
            MessageBox.Show(textBoxTelefone.Text);
            MessageBox.Show(textBoxNome.Text);
            MessageBox.Show(cadastro.mensagem);
           
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Conexao conexao = new Conexao();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from ex where Id=@Id ";
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = txtId.Text;
            try
            {
                cmd.Connection = conexao.conectar();
                //Executar comando
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    txtId.Text = Convert.ToString(dr["Id"]);
                    textBoxNome.Text = Convert.ToString(dr["Nome"]);
                    textBoxTelefone.Text = Convert.ToString(dr["Telefone"]);
                }
               
                //Desconectar
                conexao.desconectar();
                
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);            
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Conexao conexao = new Conexao();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "delete  from ex where Id=@Id ";
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = txtId.Text;
            try
            {
                cmd.Connection = conexao.conectar();
                //Executar comando
               cmd.ExecuteNonQuery();
              
                //Desconectar
                conexao.desconectar();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Conexao conexao = new Conexao();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update ex set Nome=@Nome, Telefone=@Telefone where Id=@Id ";
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = txtId.Text;
            cmd.Parameters.Add("@Nome",SqlDbType.Text).Value=textBoxNome.Text;
            cmd.Parameters.Add("@Telefone", SqlDbType.Text).Value = textBoxTelefone.Text;
            try
            {

                cmd.Connection = conexao.conectar();
                //Executar comando
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sucesso!");
                //Desconectar
                conexao.desconectar();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
