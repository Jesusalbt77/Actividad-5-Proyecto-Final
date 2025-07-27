using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing; // AÑADIDO para usar Point
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

            // Establecer centrado manual
            this.StartPosition = FormStartPosition.Manual;
            this.Load += frmAgendarCita_Load;

            GenerarIdAutomatico();

            cboMotivo.DropDownStyle = ComboBoxStyle.DropDownList; // No permitir escritura
            cboMotivo.Items.AddRange(new string[] { "Limpieza", "Extracción", "Revisión" });
            cboMotivo.SelectedIndex = 0;

            // Asignar validaciones
            txtPaciente.KeyPress += SoloLetras_KeyPress;
            txtDentista.KeyPress += SoloLetras_KeyPress;
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

        private void frmAgendarCita_Load(object sender, EventArgs e)
        {
            // Centrar dentro del formulario MDI padre
            if (this.MdiParent != null)
            {
                int x = (this.MdiParent.ClientSize.Width - this.Width) / 2;
                int y = (this.MdiParent.ClientSize.Height - this.Height) / 2;
                this.Location = new Point(Math.Max(0, x), Math.Max(0, y));
            }
        }

        // Solo permitir letras
        private void SoloLetras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten letras en este campo.");
            }
        }

        private void lblID_Click(object sender, EventArgs e)
        {

        }
    }
}
