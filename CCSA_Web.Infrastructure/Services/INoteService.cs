using CCSA_Web.Domain.Models;

namespace CCSA_Web.Infrastructure.Services
{
    public interface INoteService
    {
        //C-R-U-D
        void CreateNote(Note note);
        void CreateNote(Guid userId,string title, string content,Group groupName);
        void UpdateNote(Guid id,string content, string title,Group groupname);
        void UpdateNote(Guid id, string content);
        void UpdateNoteTitle(Guid id, string title);
        void DeleteNote(Guid id);
        void DeleteNote(List<Guid> ids);
        List<Note> FetchNote();
        List<Note> FetchNoteByUser(Guid id);
        Note FetchNoteById(Guid id);
        List<Note> FetchNoteByGroup(Guid userId, Group groupName);
    }

    
}
