using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaCitasDental
{
    public partial class Actualizar : Form
    {
        private Cita cita; // Esta es la cita que se va a actualizar

        public Actualizar(Cita citaSeleccionada)
        {
            InitializeComponent();
            this.cita = citaSeleccionada;
        }

        private void Actualizar_Load(object sender, EventArgs e)
        {
            // Mostrar datos actuales en los controles
            txtId.Text = cita.Id.ToString();
            txtId.ReadOnly = true;

            txtPaciente.Text = cita.NombrePaciente;
            dtpFecha.Value = cita.Fecha;
            dtpHora.Value = DateTime.Today.Add(cita.Hora);
            nudDuracion.Value = cita.DuracionMinutos;
            txtDentista.Text = cita.NombreDentista;

            cboMotivo.Items.Clear();
            cboMotivo.Items.AddRange(new string[] { "Limpieza", "Extracción", "Revisión" });
            cboMotivo.SelectedItem = cita.Motivo;
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            // Validaciones
            if (string.IsNullOrWhiteSpace(txtPaciente.Text) ||
                string.IsNullOrWhiteSpace(txtDentista.Text) ||
                cboMotivo.SelectedIndex == -1)
            {
                MessageBox.Show("Todos los campos son obligatorios.");
                return;
            }

            // Actualizar datos de la cita
            cita.NombrePaciente = txtPaciente.Text.Trim();
            cita.Fecha = dtpFecha.Value.Date;
            cita.Hora = dtpHora.Value.TimeOfDay;
            cita.DuracionMinutos = (int)nudDuracion.Value;
            cita.NombreDentista = txtDentista.Text.Trim();
            cita.Motivo = cboMotivo.SelectedItem.ToString();

            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}