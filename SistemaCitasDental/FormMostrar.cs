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
    public partial class FormMostrar : Form
    {
        private List<Cita> listaCitas;

        public FormMostrar(List<Cita> citas)
        {
            InitializeComponent();
            this.listaCitas = citas;

            // Establecer posición manual
            this.StartPosition = FormStartPosition.Manual;
            this.Load += FormMostrar_Load;
        }

        private void FormMostrar_Load(object sender, EventArgs e)
        {
            // Centrar dentro del formulario MDI padre
            if (this.MdiParent != null)
            {
                int x = (this.MdiParent.ClientSize.Width - this.Width) / 2;
                int y = (this.MdiParent.ClientSize.Height - this.Height) / 2;
                this.Location = new Point(Math.Max(0, x), Math.Max(0, y));
            }

            RefrescarGrid();
        }

        private void RefrescarGrid()
        {
            dgvCitas.AutoGenerateColumns = true;
            dgvCitas.DataSource = null;

            dgvCitas.DataSource = listaCitas.Select(c => new
            {
                c.Id,
                c.NombrePaciente,
                Fecha = c.Fecha.ToShortDateString(),
                Hora = c.Hora.ToString(@"hh\:mm"),
                c.DuracionMinutos,
                c.NombreDentista,
                c.Motivo,
                DiasRestantes = c.TiempoRestante.Days,
                HorasRestantes = c.TiempoRestante.Hours,
                Estado = c.Estado
            }).ToList();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgendarCita formAgendar = new frmAgendarCita(listaCitas);

            if (formAgendar.ShowDialog() == DialogResult.OK)
            {
                listaCitas.Add(formAgendar.NuevaCita);
                RefrescarGrid();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvCitas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una cita para editar.");
                return;
            }

            int idSeleccionado = Convert.ToInt32(dgvCitas.SelectedRows[0].Cells["Id"].Value);
            Cita citaSeleccionada = listaCitas.FirstOrDefault(c => c.Id == idSeleccionado);

            if (citaSeleccionada == null)
            {
                MessageBox.Show("No se ha asignado una cita válida para editar.");
                return;
            }

            Actualizar formActualizar = new Actualizar(listaCitas);
            if (formActualizar.ShowDialog() == DialogResult.OK)
            {
                RefrescarGrid();
            }
        }
    }
}
