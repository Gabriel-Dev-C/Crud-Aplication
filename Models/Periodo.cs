using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;

namespace AplicativoAcademico.Models
{
    public class Periodo
    {
        [PrimaryKey, AutoIncrement]
        public int Codigo { get; set; }

        [NotNull]
        public string Nome { get; set; }
    }
}
