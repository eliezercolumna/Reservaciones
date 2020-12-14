using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestor_de_citas
{
    public partial class Form1 : Form
    {
        DAO.visitanteDAO objeto = new DAO.visitanteDAO();

        private int id;

        public Form1()
        {
            InitializeComponent();
            consultar();
            btn_eliminar.Enabled = false;
            btn_actualizar.Enabled = false;
        }


        private void btn_ingresar_Click(object sender, EventArgs e)
        {
            objeto.Insertar(txt_nombre.Text, txt_apellido.Text, txt_documento.Text, cmb_documento.Text, txt_telefono.Text, cmb_telefono.Text, cmb_persona.Text, cmb_fecha.Text);

            consultar();
        }
        public void consultar()
        {
            dgv_visitante.DataSource = objeto.Consultar();
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            objeto.Eliminar(id);
            consultar();
        }

        private void dgv_visitante_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ObtenerId();
            ObtenerDatos();
            this.btn_eliminar.Enabled = false;
            this.btn_actualizar.Enabled = true;
        }

        private void dgv_visitante_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ObtenerId();
            this.btn_eliminar.Enabled = true;
            this.btn_actualizar.Enabled = false;
        }


        private void ObtenerId()
        {
            bool convert = Int32.TryParse(dgv_visitante.CurrentRow.Cells[0].Value.ToString(), out id);
            if (convert == false)
            {
                    MessageBox.Show("No se encuentra disponible");
            }
        }
        private void ObtenerDatos()
        {
            ObtenerId();
            txt_nombre.Text = dgv_visitante.CurrentRow.Cells[1].Value.ToString();
            txt_apellido.Text = dgv_visitante.CurrentRow.Cells[2].Value.ToString();
            txt_documento.Text = dgv_visitante.CurrentRow.Cells[3].Value.ToString();
            cmb_documento.Text = dgv_visitante.CurrentRow.Cells[4].Value.ToString();
            txt_telefono.Text = dgv_visitante.CurrentRow.Cells[5].Value.ToString();
            cmb_telefono.Text = dgv_visitante.CurrentRow.Cells[6].Value.ToString();
            txt_persona.Text = dgv_visitante.CurrentRow.Cells[7].Value.ToString();
            cmb_persona.Text = dgv_visitante.CurrentRow.Cells[8].Value.ToString();
            txt_fecha.Text = dgv_visitante.CurrentRow.Cells[9].Value.ToString();
            cmb_fecha.Text = dgv_visitante.CurrentRow.Cells[10].Value.ToString();



        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            ObtenerId();
            objeto.Actualizar(id, txt_nombre.Text, txt_apellido.Text, txt_documento.Text, cmb_documento.Text, txt_telefono.Text, cmb_telefono.Text, txt_persona.Text, txt_fecha.Text,cmb_fecha.Text );
            consultar();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dgv_visitante_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txt_persona_Click(object sender, EventArgs e)
        {

        }

        private void Fecha_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txt_fecha_Click(object sender, EventArgs e)
        {

        }
    }
}
