using System.ComponentModel.DataAnnotations;

namespace notes_api.DTO
{
    public class DTONote
    {

        public int Id { get; set; }

        [StringLength(32, MinimumLength = 4)]
        public string? Title { get; set; }

        [StringLength(256)]
        public string? Content { get; set; }

    }
}
