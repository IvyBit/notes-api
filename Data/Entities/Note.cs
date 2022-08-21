namespace notes_api.Data.Entities
{
    public class Note
    {
        public int Id { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }

    }
}
