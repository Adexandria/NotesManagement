
using CCSA_Web.Domain.Models;

namespace CCSA_Web.Infrastructure.Services
{
    public class NoteService :INoteService
    {
        static List<Note> notes = new List<Note>();
        public void CreateNote(Note note)
        {
            notes.Add(note);
        }
        public void CreateNote(Guid userId, string title, string content, Group groupName)
        {
            User currentUser = UserService.users.FirstOrDefault(s => s.Id == userId);
            notes.Add(new Note
            {
                Title = title,
                Content = content,
                User = currentUser,
                GroupName = groupName
            });
        }
        public void DeleteNote(Guid id)
        {
            var note = notes.FirstOrDefault(x => x.Id == id);
            if (note != null)
            {
                notes.Remove(note);
            }
        }

        public void DeleteNote(List<Guid> ids)
        {
            foreach (var id in ids)
            {
                DeleteNote(id);
            }
        }

        public List<Note> FetchNote()
        {
            return notes;
        }

        public List<Note> FetchNoteByGroup(Guid userId, Group groupName)
        {
            var _notes = notes.Where(x => x.User.Id == userId && x.GroupName == groupName);
            return notes.ToList();
        }

        public Note FetchNoteById(Guid id)
        {
            var note = notes.FirstOrDefault(x => x.Id == id);
            return note;
        }

        public List<Note> FetchNoteByUser(Guid id)
        {
            var _notes = notes.Where(x => x.User.Id == id);
            return notes.ToList();
        }
        
        public void UpdateNote(Guid id, string content, string title, Group groupname)
        {
            var _note = notes.FirstOrDefault(x => x.Id == id);
            if (_note != null)
            {
                _note.Title = title;
                _note.Content = content;
                _note.GroupName = groupname;
            }
        }

        public void UpdateNote(Guid id, string content)
        {
            var _note = notes.FirstOrDefault(x => x.Id == id);
            if (_note != null)
            {
                _note.Content = content;
            }
        }

        public void UpdateNoteTitle(Guid id, string title)
        {
            var _note = notes.FirstOrDefault(x => x.Id == id);
            if (_note != null)
            {
                _note.Title = title;
            }
        }
    }

    
}
