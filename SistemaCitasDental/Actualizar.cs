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
        public Actualizar()
        {
            InitializeComponent();

           
        }
        public Cita citaAEditar { get; set; }

        private void Actualizar_Load(object sender, EventArgs e)
        {
            cboMotivo.Items.AddRange(new string[] { "Limpieza", "Extracción", "Revisión" });

            if (citaAEditar == null)
            {
                MessageBox.Show("No se ha asignado una cita para editar.");
                Close();
                return;
            }

            txtId.Text = citaAEditar.Id.ToString();
            txtId.ReadOnly = true;

            txtPaciente.Text = citaAEditar.NombrePaciente;
            txtDentista.Text = citaAEditar.NombreDentista;
            dtpFecha.Value = citaAEditar.Fecha;
            dtpHora.Value = dtpFecha.Value.Date + citaAEditar.Hora;
            nudDuracion.Value = citaAEditar.DuracionMinutos;
            cboMotivo.SelectedItem = citaAEditar.Motivo;
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

            DateTime fecha = dtpFecha.Value.Date;
            TimeSpan hora = dtpHora.Value.TimeOfDay;

            if ((fecha + hora) < DateTime.Now)
            {
                MessageBox.Show("No puedes actualizar una cita en el pasado.");
                return;
            }

            // Actualizar la cita directamente
            citaAEditar.NombrePaciente = txtPaciente.Text.Trim();
            citaAEditar.NombreDentista = txtDentista.Text.Trim();
            citaAEditar.Fecha = fecha;
            citaAEditar.Hora = hora;
            citaAEditar.DuracionMinutos = (int)nudDuracion.Value;
            citaAEditar.Motivo = cboMotivo.SelectedItem.ToString();

            MessageBox.Show("Cita actualizada correctamente.");
            DialogResult = DialogResult.OK;
            Close();
        
    }
    }
}
