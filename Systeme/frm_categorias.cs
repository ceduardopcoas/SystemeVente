﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using systeme.DAL;

namespace Systeme
{
    public partial class frm_categorias : Form
    {
        public frm_categorias()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frm_categorias_Load(object sender, EventArgs e)
        {
            this.categoriaBindingSource.DataSource = DataContextFactory.DataContext.Categoria;


        }

        private void btn_novo_Click(object sender, EventArgs e)
        {
            this.categoriaBindingSource.AddNew();
        }

        private void btn_cadastrar_Click(object sender, EventArgs e)
        {
            if (this.valida())
            {
                this.categoriaBindingSource.EndEdit();
                DataContextFactory.DataContext.SubmitChanges();
                MessageBox.Show("Categoria Inserida com sucesso!");
            }
            
        }

        private bool valida()
        {
            if(txt_categoria.Text.Trim() == string.Empty){
                MessageBox.Show("O campo de Categoria é obrigatório!");
                txt_categoria.Focus();
                return false;
            }
            return true;
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.categoriaBindingSource.CancelEdit();
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Tem certeza?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                if (this.CategoriaPossuiProduto(this.categoriaAtual))
                    MessageBox.Show("Voçe não pode excluir essa Categoria por que existe produto nessa categoria!");
                else
                {
                    this.categoriaBindingSource.RemoveCurrent();
                    DataContextFactory.DataContext.SubmitChanges();
                    MessageBox.Show("Categoria Excluida com sucesso!");
                }

            }

        }

        public Categoria categoriaAtual
        {
            get
            {
                return (Categoria)this.categoriaBindingSource.Current;
            }
        }

        private bool CategoriaPossuiProduto(Categoria categoria)
        {
            var produtos = DataContextFactory.DataContext.Produto.Where(x => x.CodigoCategoria == categoria.Codigo);
            if (produtos.Count() > 0)
                return true;
            else
                return false;
        }
    }
}
