﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ifuel;
using Microsoft.SqlServer;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Ifuel
{
    public partial class LoginUser : Form
    {

        public int logar = 1; //Variavel de controle
        public int Id_usr = 0;
        public LoginUser()
        {
            InitializeComponent();
        }

        /*Botão para fazer LoginUser*/
        private void btnLogar_Click(object sender, EventArgs e)
        {
            try
            {
                string Email = textUser.Text;
                string Senha = textSenha.Text;
                Login loginU = new Login();
                loginU.getLoginUser(Email, Senha);
                Id_usr = loginU.ConfLogin;
                if (loginU.Logar == true)
                {
                    MenuUser menuUser = new MenuUser();
                    menuUser.Id_usr = Id_usr;
                    menuUser.Show();
                    Hide();
                }
                else if (loginU.Logar == false)
                {
                    MessageBox.Show("Erro Login\nVerificar campos");
                }
                else
                {
                    MessageBox.Show(loginU.message);
                }
            }
            /*Trata erro do Programa*/
            catch (IfuelException erro)
            {
                StringBuilder str = new StringBuilder();
                str.AppendLine(erro.Message);
                str.AppendLine("\n");
                str.AppendLine(erro.StackTrace);
                str.ToString();
                MessageBox.Show(str.ToString());
            }

        }

        /*Botão para fazer Voltar a Tela Inicial*/
        private void btnVoltar_Click(object sender, EventArgs e)
        {

            TelaInicial telaInicial = new TelaInicial();
            telaInicial.Show();
            Hide();
        }

        /*Botão para fazer Cadastro*/
        private void btnCadastro_Click(object sender, EventArgs e)
        {

            CadUsuario cadastro = new CadUsuario();
            cadastro.Show();
            Hide();

        }

        private void linkPerdaSenha_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            logar = 2;
            TelaAtuSenha atuSenha = new TelaAtuSenha();
            atuSenha.Logar = logar;
            atuSenha.Show();
            Hide();
        }
    }
}
