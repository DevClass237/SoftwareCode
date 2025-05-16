using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenaiKeys.Salas
{
    class Sala
    {
        public int Chave { get; private set; }
        public bool Status { get; private set; }
        public string Laboratorio { get; private set; }
        public int IdDocente { get; private set; }
        public int IdCurso { get; private set; }

        public Sala(int chave, bool status, string laboratorio, int idDocente, int idCurso)
        {
            Chave = chave;
            Status = status;
            Laboratorio = laboratorio;
            IdDocente = idDocente;
            IdCurso = idCurso;
        }
    }
}
