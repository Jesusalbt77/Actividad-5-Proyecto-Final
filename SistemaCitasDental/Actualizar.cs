using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace SistemaCitasDental
{
    public partial class Actualizar : Form
    {
        private List<Cita> listaCitas;
        private Cita cita;

        public Actualizar(List<Cita> citas)
        {
            InitializeComponent();
            listaCitas = citas;

            // Asociar eventos KeyPress para validación
            txtPaciente.KeyPress += SoloLetras_KeyPress;
            txtDentista.KeyPress += SoloLetras_KeyPress;
        }

        private void Actualizar_Load(object sender, EventArgs e)
        {
            // Mostrar InputBox para ingresar ID
            string input = Microsoft.VisualBasic.Interaction.InputBox(
                "Ingrese el ID de la cita a actualizar:",
                "Buscar Cita",
                "",
                -1, -1);

            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("No se ingresó ningún ID.");
                Close();
                return;
            }

            if (!int.TryParse(input, out int idBuscado))
            {
                MessageBox.Show("ID no válido.");
                Close();
                return;
            }

            // Buscar la cita en la lista
            cita = listaCitas.FirstOrDefault(c => c.Id == idBuscado);

            if (cita == null)
            {
                MessageBox.Show("No se encontró la cita con ese ID.");
                Close();
                return;
            }

            // Mostrar datos de la cita
            txtId.Text = cita.Id.ToString();
            txtId.ReadOnly = true;
            txtPaciente.Text = cita.NombrePaciente;
            dtpFecha.Value = cita.Fecha;
            dtpHora.Value = DateTime.Today.Add(cita.Hora);
            nudDuracion.Value = cita.DuracionMinutos;
            txtDentista.Text = cita.NombreDentista;

            cboMotivo.Items.AddRange(new string[] { "Limpieza", "Extracción", "Revisión" });
            cboMotivo.SelectedItem = cita.Motivo;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPaciente.Text) ||
                string.IsNullOrWhiteSpace(txtDentista.Text) ||
                cboMotivo.SelectedIndex == -1)
            {
                MessageBox.Show("Todos los campos son obligatorios.");
                return;
            }

            // Actualizar la cita
            cita.NombrePaciente = txtPaciente.Text.Trim();
            cita.Fecha = dtpFecha.Value.Date;
            cita.Hora = dtpHora.Value.TimeOfDay;
            cita.DuracionMinutos = (int)nudDuracion.Value;
            cita.NombreDentista = txtDentista.Text.Trim();
            cita.Motivo = cboMotivo.SelectedItem.ToString();

            MessageBox.Show("Cita actualizada correctamente.");
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        // Validación de letras con mensaje de advertencia
        private void SoloLetras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten letras en este campo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
        
    

