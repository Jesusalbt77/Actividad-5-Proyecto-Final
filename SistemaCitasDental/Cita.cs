using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCitasDental
{
    public class Cita
    {
        public string Id { get; set; }
        public string NombrePaciente { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public int DuracionMinutos { get; set; }
        public string NombreDentista { get; set; }
        public string Motivo { get; set; }

        // Calcula el tiempo restante hasta que inicie la cita
        public TimeSpan TiempoRestante
        {
            get
            {
                DateTime fechaHora = Fecha.Date + Hora;
                return fechaHora > DateTime.Now ? fechaHora - DateTime.Now : TimeSpan.Zero;
            }
        }

        // Determina el estado de la cita
        public string Estado
        {
            get
            {
                DateTime inicio = Fecha.Date + Hora;
                DateTime fin = inicio.AddMinutes(DuracionMinutos);
                DateTime ahora = DateTime.Now;

                if (ahora < inicio)
                    return "Vigente";
                else if (ahora >= inicio && ahora <= fin)
                    return "En proceso";
                else
                    return "Finalizado";
            }
        }
    }
}

