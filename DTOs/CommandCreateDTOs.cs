namespace BackEndAPIHost.DTOs
{
    public class CommandCreateDTO
    {
        // public int Id { get; set; } -- no need cuz database auto create this
        public string HowTo { get; set; }
        public string Line { get; set; }
        public string Platform { get; set; }
    }
}