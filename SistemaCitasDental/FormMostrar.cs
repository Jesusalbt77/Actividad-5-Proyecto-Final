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
        }

        private void FormMostrar_Load(object sender, EventArgs e)
        {
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

            // Obtener el ID de la fila seleccionada
            int idSeleccionado = Convert.ToInt32(dgvCitas.SelectedRows[0].Cells["Id"].Value);

            // Buscar la cita original en la lista
            Cita citaSeleccionada = listaCitas.FirstOrDefault(c => c.Id == idSeleccionado);

            if (citaSeleccionada == null)
            {
                MessageBox.Show("No se ha asignado una cita válida para editar.");
                return;
            }

            // Abrir formulario de actualización
            Actualizar formActualizar = new Actualizar(citaSeleccionada);
            if (formActualizar.ShowDialog() == DialogResult.OK)
            {
                RefrescarGrid(); // Refrescar la vista
            }
        }
    }
}
