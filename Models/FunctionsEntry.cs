namespace FunctionDocs.Models
{
    public class FunctionEntry
    {
        public int Id { get; set; }
        public required string FunctionName { get; set; }
        public required string Description { get; set; }
        public required string CodeExample { get; set; }
       
    }
}