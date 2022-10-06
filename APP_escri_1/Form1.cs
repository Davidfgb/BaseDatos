using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Capa_Entidad;
using Capa_Negocio;


namespace APP_escri_1
{
    public partial class Form1 : Form
    {

        ClassEntidad objent = new ClassEntidad();
        ClassNegocio objneg = new ClassNegocio();
        public Form1()
        {
            InitializeComponent();
        }

        void mantenimiento(String accion)
        {
            objent.codigo = txtCodigo.Text;
            objent.titulo = txtTitulo.Text;
            objent.autor = txtAutor.Text;
            objent.editorial = txtEditorial.Text;
            objent.precio = Convert.ToDouble(txtPrecio.Text);
            objent.cantidad = Convert.ToInt32(txtCantidad.Text);
            objent.accion = accion;
            String men = objneg.N_mantenimiento_libros(objent);
            MessageBox.Show(men, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void limpiar()
        {
            txtCodigo.Text = "";
            txtTitulo.Text = "";
            txtAutor.Text = "";
            txtEditorial.Text = "";
            txtPrecio.Text = "";
            txtCantidad.Text = "";
            txtBuscar.Text = "";
            dataGridView1.DataSource = objneg.N_listar_libros();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text != "")
            {
                objent.titulo = txtBuscar.Text;
                DataTable dt = new DataTable();
                dt = objneg.N_buscar_libros(objent);
                dataGridView1.DataSource = dt;
            }
            else
            {
                dataGridView1.DataSource = objneg.N_listar_libros();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = objneg.N_listar_libros();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void registrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "")
            {
                if (MessageBox.Show("¿Deseas registrar a " + txtTitulo.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    mantenimiento("1");
                    limpiar();
                }
            }
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "")
            {
                if (MessageBox.Show("¿Deseas modificar a " + txtTitulo.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    mantenimiento("2");
                    limpiar();
                }
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "")
            {
                if (MessageBox.Show("¿Deseas eliminar a " + txtTitulo.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    mantenimiento("3");
                    limpiar();
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dataGridView1.CurrentCell.RowIndex;

            txtCodigo.Text = dataGridView1[0, fila].Value.ToString();
            txtTitulo.Text = dataGridView1[1, fila].Value.ToString();
            txtAutor.Text = dataGridView1[2, fila].Value.ToString();
            txtEditorial.Text = dataGridView1[3, fila].Value.ToString();
            txtPrecio.Text = dataGridView1[4, fila].Value.ToString();
            txtCantidad.Text = dataGridView1[5, fila].Value.ToString();
        }
    }
}
