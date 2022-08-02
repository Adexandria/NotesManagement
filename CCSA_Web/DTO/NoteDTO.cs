using CCSA_Web.Domain.Models;

namespace CCSA_Web.DTO
{
    public class NoteDTO
    {
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Group GroupName { get; set; }
    }
}
