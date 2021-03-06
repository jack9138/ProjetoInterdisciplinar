﻿using System;
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
    public partial class MenuUser : Form
    {
        public int Id_usr = 0;
        public MenuUser()
        {
            InitializeComponent();
        }

        /*Botão para Pesquisar valor*/
        private void btnPesqPreco_Click(object sender, EventArgs e)
        {
            TelaPesquisa tela = new TelaPesquisa();
            tela.Show();
            Hide();
        }

        /*Botão para Avaliar Posto*/
        private void btnAvaliar_Click(object sender, EventArgs e)
        {
            TelaAvaliar avaliar = new TelaAvaliar();
            avaliar.Show();
            Hide();
        }

        /*Botão para atualizar cadastro do usuário*/
        private void btnAtuCad_Click(object sender, EventArgs e)
        {
            AtuCadUser at = new AtuCadUser();
            at.Id_usr = Id_usr;
            at.Show();
            Hide();
        }

        /*Botão para sair(Fechar Programa)*/
        private void btnSair_Click(object sender, EventArgs e)
        {
            TelaInicial tela = new TelaInicial();
            tela.Show();
            Hide();
        }

       
    }
}
