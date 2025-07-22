using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace SistemaCitasDental
{
    public partial class frmPrincipal : Form
    {
        private List<Cita> listaCitas = new List<Cita>();

        public frmPrincipal()
        {
            InitializeComponent();
        }

        // Mostrar citas en el DataGridView
        private void MostrarCitas()
        {
            dgvCitas.DataSource = null;
            dgvCitas.AutoGenerateColumns = true;
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

        // Agendar cita
        private void agendarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAgendarCita ventana = new frmAgendarCita(listaCitas);
            if (ventana.ShowDialog() == DialogResult.OK)
            {
                listaCitas.Add(ventana.NuevaCita);
                MostrarCitas();
                MessageBox.Show("Cita registrada correctamente.");
            }
        }

        // Mostrar todas las citas en ventana aparte
        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMostrar form = new FormMostrar(listaCitas);
            form.ShowDialog();
        }

        // Exportar citas a CSV
        private void exportarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listaCitas.Count == 0)
            {
                MessageBox.Show("No hay citas para exportar.");
                return;
            }

            // Pedir el ID con InputBox
            string input = Microsoft.VisualBasic.Interaction.InputBox(
                "Ingrese el ID de la cita que desea exportar:",
                "Exportar Cita",
                "",
                -1, -1);

            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("No se ingresó ningún ID.");
                return;
            }

            if (!int.TryParse(input, out int idBuscado))
            {
                MessageBox.Show("ID inválido.");
                return;
            }

            // Buscar la cita específica
            var cita = listaCitas.FirstOrDefault(c => c.Id == idBuscado);

            if (cita == null)
            {
                MessageBox.Show("No se encontró una cita con ese ID.");
                return;
            }

            // Configurar diálogo para guardar
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Archivo CSV (*.csv)|*.csv",
                Title = "Guardar archivo CSV",
                FileName = $"Cita_{cita.Id}.csv"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName, false, Encoding.UTF8))
                    {
                        // Encabezados
                        writer.WriteLine("ID,Paciente,Fecha,Hora,Duración,Dentista,Motivo,Tiempo Restante,Estado");

                        // Formatear tiempo restante
                        string tiempoRestante = $"{cita.TiempoRestante.Hours:00}:{cita.TiempoRestante.Minutes:00}";

                        // Escribir datos de la cita
                        writer.WriteLine($"{cita.Id},{cita.NombrePaciente},{cita.Fecha:yyyy-MM-dd},{cita.Hora:hh\\:mm},{cita.DuracionMinutos},{cita.NombreDentista},{cita.Motivo},{tiempoRestante},{cita.Estado}");
                    }

                    MessageBox.Show("Cita exportada correctamente.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al exportar: " + ex.Message);
                }
            }
        }
        ///hasta aqui
        
        // Confirmar salida del sistema
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "¿Estás seguro de que deseas salir?",
                "Confirmar salida",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                this.Close();
            }
        }

        // ACTUALIZAR cita seleccionada
        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Actualizar frmActualizar = new Actualizar(listaCitas);
            if (frmActualizar.ShowDialog() == DialogResult.OK)
            {
                MostrarCitas(); // Refresca la vista después de actualizar
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox(
        "Ingrese el ID de la cita a eliminar:",
        "Eliminar Cita",
        "",
        -1, -1);

            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("No se ingresó ningún ID.");
                return;
            }

            if (!int.TryParse(input, out int idEliminar))
            {
                MessageBox.Show("ID no válido.");
                return;
            }

            var citaEliminar = listaCitas.FirstOrDefault(c => c.Id == idEliminar);

            if (citaEliminar == null)
            {
                MessageBox.Show("No se encontró ninguna cita con ese ID.");
                return;
            }

            DialogResult confirmacion = MessageBox.Show(
                $"¿Está seguro de eliminar la cita con ID {idEliminar}?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmacion == DialogResult.Yes)
            {
                listaCitas.Remove(citaEliminar);
                MessageBox.Show("Cita eliminada correctamente.");

                // Si tienes un DataGridView, actualízalo así:
                dgvCitas.DataSource = null;
                dgvCitas.DataSource = listaCitas;
            }
        }
    }
}

