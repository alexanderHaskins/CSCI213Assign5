namespace ModernSoftwareDevelopmentAssignment5.Models
{
    public class Song
    {
        public required int ID {get; set;}
        public required string Name { get; set;}
        public required int artistID { get; set; }
        public required decimal price { get; set; }

        
    }
}
