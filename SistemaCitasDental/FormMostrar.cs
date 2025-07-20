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
        private List<Cita> citas;
        public FormMostrar(List<Cita> listaCitas)
        {
            InitializeComponent();
            this.citas = listaCitas;        
        }
       

        private void FormMostrar_Load(object sender, EventArgs e)
        {
            RefrescarGrid();

        }

        private void RefrescarGrid()
        {
            dgvCitas.DataSource = null;
            dgvCitas.DataSource = citas.Select(c => new
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

        private void button1_Click(object sender, EventArgs e)
        {
            frmAgendarCita formAgendar = new frmAgendarCita(citas);  // Le paso la lista actual

            var resultado = formAgendar.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                citas.Add(formAgendar.NuevaCita);
                // Actualizar el grid con la nueva cita
                RefrescarGrid();
            }
        }
    }
}
