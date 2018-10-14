using System;
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
            this.categoriaBindingSource.EndEdit();
            DataContextFactory.DataContext.SubmitChanges();
            MessageBox.Show("Categoria Inserida com sucesso!");
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.categoriaBindingSource.CancelEdit();
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            this.categoriaBindingSource.RemoveCurrent();
            DataContextFactory.DataContext.SubmitChanges();
            MessageBox.Show("Categoria Excluida com sucesso!");
        }

        private void txt_categoria_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
