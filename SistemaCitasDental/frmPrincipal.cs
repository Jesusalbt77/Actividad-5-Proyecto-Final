using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SistemaCitasDental
{
    public partial class frmPrincipal : Form
    {
        private List<Cita> listaCitas = new List<Cita>();

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
    }
}



