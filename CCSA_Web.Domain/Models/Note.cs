namespace CCSA_Web.Domain.Models
{
    public class Note
    {
        public Note()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public User User { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Group GroupName { get; set; }
        public DateTime CreatedDate { get; set; }=DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
    }
}
