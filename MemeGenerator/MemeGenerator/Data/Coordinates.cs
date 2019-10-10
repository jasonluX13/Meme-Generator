namespace MemeGenerator.Data
{
    public class Coordinates
    {
        public int Id { get; set; }
        public double X { get; set; }
        public double Y { get; set; }

        public int TemplateId { get; set; }
        public Template Template { get; set; }
    }
}