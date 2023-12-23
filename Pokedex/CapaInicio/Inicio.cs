using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocios;

namespace CapaInicio
{
    public partial class Inicio : Form
    {
        CN_Pokemones objetoCN = new CN_Pokemones();
        private string idPokemon = null;
        private bool Editar = false;

        public Inicio()
        {
            InitializeComponent();
        }

        private void MostrarPokemones()
        {
            CN_Pokemones objetoCN = new CN_Pokemones();
            dataGridView1.DataSource = objetoCN.MostrarPokemon();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            MostrarPokemones();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //Insertar
            if (Editar == false)
            {
                try
                {
                    objetoCN.InsertarPokemon(txtNombre.Text, txtEspecie.Text, txtTipo.Text, txtHabilidad.Text, txtPeso.Text, txtAltura.Text, txtGrupo.Text, txtGeneracion.Text);
                    MessageBox.Show("Se ha insertado adecuadamente");
                    MostrarPokemones();
                    Limpiar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"No se ha realizado el registro por: {ex}");
                }
            }
            //editar
            if (Editar == true)
            {
                try
                {
                    objetoCN.EditarPokemon(txtNombre.Text, txtEspecie.Text, txtTipo.Text, txtHabilidad.Text, txtPeso.Text, txtAltura.Text, txtGrupo.Text, txtGeneracion.Text, idPokemon);
                    MessageBox.Show("Se ha editado adecuadamente");
                    MostrarPokemones();
                    Limpiar();
                    Editar = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"No se ha realizado el registro por: {ex}");
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                Editar = true;
                txtNombre.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                txtEspecie.Text = dataGridView1.CurrentRow.Cells["Especie"].Value.ToString();
                txtTipo.Text = dataGridView1.CurrentRow.Cells["Tipo"].Value.ToString();
                txtHabilidad.Text = dataGridView1.CurrentRow.Cells["Habilidad"].Value.ToString();
                txtPeso.Text = dataGridView1.CurrentRow.Cells["Peso"].Value.ToString();
                txtAltura.Text = dataGridView1.CurrentRow.Cells["Altura"].Value.ToString();
                txtGrupo.Text = dataGridView1.CurrentRow.Cells["Grupo"].Value.ToString();
                txtGeneracion.Text = dataGridView1.CurrentRow.Cells["Generacion"].Value.ToString();
                idPokemon = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione una fila");
            }
        }

        private void Limpiar()
        {
            txtNombre.Clear();
            txtEspecie.Clear();
            txtTipo.Clear();
            txtHabilidad.Clear();
            txtPeso.Clear();
            txtAltura.Clear();
            txtGrupo.Clear();
            txtGeneracion.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                idPokemon = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
                objetoCN.EliminarPokemon(idPokemon);
                MessageBox.Show("Se ha eliminado correctamente");
                MostrarPokemones();
            }
            else
            {
                MessageBox.Show("Seleccione una fila");
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("\tElaborado by: Montes Jaimes Danna Xiomara \n\tRivera Garcia Jonathan Ulises \n\tBarrientos Ruiz Luis Enrique" +
                "\n\n\t             Presione Aceptar para cerrar","Creditos", MessageBoxButtons.OK);
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

    }
}
