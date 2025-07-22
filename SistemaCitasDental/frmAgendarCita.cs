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
    public partial class frmAgendarCita : Form
    {
        public Cita NuevaCita { get; private set; }
        private List<Cita> citasExistentes;

        public frmAgendarCita(List<Cita> citas)
        {
            InitializeComponent();
            citasExistentes = citas;

            GenerarIdAutomatico(); // Agrega esta línea aquí

            cboMotivo.Items.AddRange(new string[] { "Limpieza", "Extracción", "Revisión" });
            cboMotivo.SelectedIndex = 0;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
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
                MessageBox.Show("No puedes agendar una cita en el pasado.");
                return;
            }

            NuevaCita = new Cita
            {
                Id = int.Parse(txtId.Text.Trim()),
                NombrePaciente = txtPaciente.Text.Trim(),
                Fecha = fecha,
                Hora = hora,
                DuracionMinutos = (int)nudDuracion.Value,
                NombreDentista = txtDentista.Text.Trim(),
                Motivo = cboMotivo.SelectedItem.ToString()
            };

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void GenerarIdAutomatico()
        {
            int nuevoId = 1;

            if (citasExistentes.Any())
            {
                nuevoId = citasExistentes.Max(c => c.Id) + 1;
            }


            txtId.Text = nuevoId.ToString();
            txtId.ReadOnly = true;
        }

    }
}