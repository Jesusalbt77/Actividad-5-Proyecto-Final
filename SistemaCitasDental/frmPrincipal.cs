using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SistemaCitasDental
{
    public partial class frmPrincipal : Form
    {
        private List<Cita> listaCitas = new List<Cita>();

        // Propiedad pública por si necesitas exponer la lista (opcional)
        public List<Cita> ListaCitas
        {
            get { return listaCitas; }
        }

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void MostrarCitas()
        {
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

        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMostrar form = new FormMostrar(listaCitas);
            form.ShowDialog();
        }

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

        private void exportarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //  Se usa listaCitas directamente, no la clase frmPrincipal
            if (listaCitas.Count == 0)
            {
                MessageBox.Show("No hay citas para exportar.");
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Archivo CSV (*.csv)|*.csv",
                Title = "Guardar archivo CSV",
                FileName = "Citas_Consultorio.csv"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName, false, Encoding.UTF8))
                    {
                        // Encabezado
                        writer.WriteLine("ID,Paciente,Fecha,Hora,Duración,Dentista,Motivo,Tiempo Restante,Estado");

                        foreach (var cita in listaCitas)
                        {
                            string tiempoRestante = $"{cita.TiempoRestante.Hours:00}:{cita.TiempoRestante.Minutes:00}";

                            writer.WriteLine($"{cita.Id},{cita.NombrePaciente},{cita.Fecha:yyyy-MM-dd},{cita.Hora:hh\\:mm},{cita.DuracionMinutos},{cita.NombreDentista},{cita.Motivo},{tiempoRestante},{cita.Estado}");
                        }
                    }

                    MessageBox.Show("Citas exportadas correctamente.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al exportar: " + ex.Message);
                }
            }
        }
    }
}
