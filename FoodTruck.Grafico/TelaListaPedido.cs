﻿using Foodtruck.Negocio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Foodtruck.Grafico
{
    public partial class TelaListaPedido : Form
    {
        public TelaListaPedido()
        {
            InitializeComponent();
        }

        private bool VerificarSelecao()
        {
            if (dgListaPedidos.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Selecione uma linha");
                return false;
            }
            return true;
        }

        private void CarregarPedidos()
        {
            dgListaPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgListaPedidos.MultiSelect = false;
            dgListaPedidos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgListaPedidos.AutoGenerateColumns = false;
            List<Pedido> pedidos = Program.Gerenciador.TodosOsPedidos();
            dgListaPedidos.DataSource = pedidos;
        }

        private void btRemover_Click(object sender, EventArgs e)
        {
            if (VerificarSelecao())
            {
                DialogResult resultado = MessageBox.Show("Tem certeza?", "Quer remover?", MessageBoxButtons.OKCancel);
                if (resultado == DialogResult.OK)
                {
                    Pedido pedidoSelecionado = (Pedido)dgListaPedidos.SelectedRows[0].DataBoundItem;
                    var validacao = Program.Gerenciador.RemoverPedido(pedidoSelecionado);
                    if (validacao.Valido)
                    {
                        MessageBox.Show("Pedido removido com sucesso!");
                    }
                    else
                    {
                        MessageBox.Show("Ocorreu um problema ao remover o lanche.");
                    }
                    CarregarPedidos();
                }
            }
        }

        

        private void dgListaPedidos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TelaListaPedido_Shown(object sender, EventArgs e)
        {

        }

        private void TelaListaPedido_Load(object sender, EventArgs e)
        {
            CarregarPedidos();
        }
    }
}
