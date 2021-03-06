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
using MySql.Data.MySqlClient;

namespace Ifuel
{
    public partial class LoginPosto : Form
    {

        Login loginP = new Login();
        TelaVerAvalia av = new TelaVerAvalia();
        CadPosto cadPosto = new CadPosto();
        public int ID_POSTO; 
        public LoginPosto()
        {
            InitializeComponent();
        }


        private void btnLogar_Click(object sender, EventArgs e)
        {
            try
            {
                string User;
                string Senha;
                User = textUser.Text;
                Senha = textSenha.Text;
                loginP.getLoginPosto(User, Senha);

                ID_POSTO = loginP.ConfLogin;//Varivel utilizada na tela de Atualizar preço; 
                av.Id_posto = ID_POSTO;
                if (loginP.Logar == true)
                {
                    MenuPosto menuPosto = new MenuPosto();
                    menuPosto.Show();
                    menuPosto.Id_posto = ID_POSTO;
                    Hide();
                }
                else if (loginP.Logar == false)
                {
                    MessageBox.Show("Erro Login\nVerifique os campos");
                }
                else
                {
                    MessageBox.Show(loginP.message);
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
            }

            /*Trata erro do Programa*/
            catch (IfuelException erro)
            {
                StringBuilder str = new StringBuilder();
                str.AppendLine(erro.Message);
                str.AppendLine("\n");
                str.AppendLine(erro.StackTrace);
                str.ToString();
            }
           
        }

        /*Botão para fazer Cadastro*/
        private void btnCadastro_Click(object sender, EventArgs e)
        {
            /*Chama tela de cadastro*/
            
            cadPosto.Show();
            Hide();

        }

        /*Botão para fazer Voltar a Tela Inicial*/
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            TelaInicial telaInicial = new TelaInicial();
            telaInicial.Show();
            Hide();
        }

        private void linkPerdaSenha_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int logar = 1;
            TelaAtuSenha atuSenha = new TelaAtuSenha();
            atuSenha.Logar = logar;
            atuSenha.Show();
            Hide();
        }
    }
}