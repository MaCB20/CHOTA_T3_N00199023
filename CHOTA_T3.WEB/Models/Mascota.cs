namespace CHOTA_T3.WEB.Models
{
    public class Mascota
    {
        public int Id { get; set; }
        public int IdDueño { get; set; }
        public Dueño dueño { get; set; }
        public string NombreMascota  { get; set; }
        public DateTime FechaNacimientoMascota { get; set; }
        public string Sexo { get; set; }
        public string Especie { get; set; }
        public string Raza { get; set; }
        public string Tamaño { get; set; }
        public string DatosParticulares { get; set; }
    }
}
