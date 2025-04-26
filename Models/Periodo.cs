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
