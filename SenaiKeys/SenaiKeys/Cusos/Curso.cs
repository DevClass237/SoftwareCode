using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenaiKeys.Cusos
{
    class Curso
    {
        public string NomeCurso { get; private set; }
        public int NumeroTurma { get; private set; }
        public int IdDocente { get; private set; }
        public int IdSala { get; private set; }

        public Curso(string nomeCurso, int numeroTurma, int idDocente, int idSala)
        {
            NomeCurso = nomeCurso;
            NumeroTurma = numeroTurma;
            IdDocente = idDocente;
            IdSala = idSala;
        }
    }
}
