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
            MostrarCitas();
        }

        private void MostrarCitas()
        {
            dgvCitas.AutoGenerateColumns = true;
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
    }
}

