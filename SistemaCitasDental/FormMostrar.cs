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

            dgvCitas.AutoGenerateColumns = false;
            dgvCitas.Columns.Clear();

            dgvCitas.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "ID",
                DataPropertyName = "Id"
            });
            dgvCitas.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Paciente",
                DataPropertyName = "NombrePaciente"
            });
            dgvCitas.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Fecha",
                DataPropertyName = "Fecha"
            });
            dgvCitas.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Hora",
                DataPropertyName = "Hora"
            });
            dgvCitas.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Duración (min)",
                DataPropertyName = "DuracionMinutos"
            });
            dgvCitas.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Dentista",
                DataPropertyName = "NombreDentista"
            });
            dgvCitas.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Motivo",
                DataPropertyName = "Motivo"
            });
            dgvCitas.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Días Restantes",
                DataPropertyName = "DiasRestantes"
            });
            dgvCitas.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Horas Restantes",
                DataPropertyName = "HorasRestantes"
            });
            dgvCitas.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Estado",
                DataPropertyName = "Estado"
            });
        }
       

        private void FormMostrar_Load(object sender, EventArgs e)
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
    }
}
