﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ifuel
{
    public partial class CadPosto : Form
    {
        public int cadLogin = 0;
        public CadPosto()
        {
            InitializeComponent();
        }

        /*Colocar forma para chamar os tres métodos de SetCadastro, GetCasdatro*/
        private void CadPosto_Load(object sender, EventArgs e)
        {
            selctComb1.Text = "Gasolina";
            selctComb2.Text = "Etanol";
            selctComb3.Text = "Diesel";
        }
        /*Link para o termo de uso*/
        private void linkTermo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string mensage = ("Termo de acordo\n "
                            + "Ao utilizar o IFUEL, concordo que meus dados serão utilizados para pesquisas e avaliações dos cliente.\n"
                            + "Afirmo que como Posto, sera de total responsabilidade minha realizar a manutenção do valor referente aos combustíveis.\n"
                            + "Da parte do software fica afirmado a manutenção e prevenções em relação a futuros problemas.\n" 
                            + "Para realizar login, utilizar os 5 primeiros digitos do CNPJ como usuário e senha.");

            MessageBox.Show(mensage);
        }

        /*Botão para salvar os dados*/
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                string NomePosto = txtNomePosto.Text.ToString();
                string Cnpj = txtCnpj.Text.ToString();
                string Alvara = txtAlvara.Text.ToString();
                string Estado = txtUF.Text;
                string Cidade = txtCidade.Text;
                string Bairro = txtBairro.Text;
                int Cep = int.Parse(txtCep.Text);
                string Endereco = txtEndereco.Text;
                string NomeComb1 = selctComb1.Text;
                double ValorComb1 = double.Parse(txtValor1.Text);
                string NomeComb2 = selctComb2.Text;
                double ValorComb2 = double.Parse(txtValor2.Text);
                string NomeComb3 = selctComb3.Text;
                double ValorComb3 = double.Parse(txtValor3.Text);
                bool CheckTermo = checkAcordo.Checked;


                CadastroP cadastroP;
                cadastroP = new CadastroP(NomePosto, Cnpj, Alvara, Estado, Cidade, Bairro, Cep, Endereco, NomeComb1, NomeComb2, NomeComb3, ValorComb1, ValorComb2, ValorComb3, CheckTermo);
                cadastroP.setCadastroPosto();

                bool cadastroOk = cadastroP.Cadastrar;

                if (cadastroOk == true)
                {
                    MessageBox.Show("Cadastro realizado com sucesso !");
                }
                else if(cadastroOk == false)
                {
                    MessageBox.Show("Erro ao cadastrar!");
                }
                else
                {
                    MessageBox.Show(cadastroP.messageErro +"\nEntre em contato com o Administrador");
                }
            }
            /*Trata erros do Banco*/
            catch (MySqlException erro)
            {
                StringBuilder str = new StringBuilder();
                str.AppendLine(erro.Message);
                str.Append(erro.SqlState);
                str.AppendLine("\n");
                str.AppendLine(erro.StackTrace);
                MessageBox.Show(str.ToString());
            }

            /*Trata erro do Programa*/
            catch (IfuelException erro)
            {
                StringBuilder str = new StringBuilder();
                str.AppendLine(erro.Message);
                str.AppendLine("\n");
                str.AppendLine(erro.StackTrace);
                MessageBox.Show(str.ToString());
            }
        }

        public void btnVoltar_Click(object sender, EventArgs e)
        {


           
            
                LoginPosto login = new LoginPosto();
                login.Show();
                Hide();

      

        }

       
    }
}
