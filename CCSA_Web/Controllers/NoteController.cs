using CCSA_Web.Domain.Models;
using CCSA_Web.DTO;
using CCSA_Web.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace CCSA_Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NoteController : ControllerBase
    {
        public INoteService _noteDb { get; }
        public NoteController(INoteService noteDb)
        {
            _noteDb = noteDb;
        }

        [HttpGet]
        public IActionResult FetchNote()
        {
            return Ok(_noteDb.FetchNote());
        }


        [HttpGet("note-group")]
        public IActionResult FetchNoteByGroup(Guid userId, Group groupName)
        {
            return Ok(_noteDb.FetchNoteByGroup(userId, groupName));
        }


        [HttpGet("by-id/{id}")]
        public IActionResult FetchNoteById(Guid id)
        {
            return Ok(_noteDb.FetchNoteById(id));
        }


        [HttpGet("by-user/{id}")]
        public IActionResult FetchNoteByUser(Guid userId)
        {
            return Ok(_noteDb.FetchNoteByUser(userId));
        }

        [HttpPost]
        public IActionResult CreateNote([FromBody] NoteDTO noteDTO)
        {
            _noteDb.CreateNote(noteDTO.UserId, noteDTO.Title, noteDTO.Content, noteDTO.GroupName);
            return Ok("Created Successfully");
        }

        [HttpPut]
        public IActionResult UpdateNote(Guid id, [FromBody] NoteDTO note)
        {
            _noteDb.UpdateNote(id, note.Content, note.Title, note.GroupName);
            return Ok("Updated Successfully");
        }


        [HttpPut("update-content")]
        public IActionResult UpdateNote(Guid id, string content)
        {
            _noteDb.UpdateNote(id, content);
            return Ok("Updated Successfully");
        }


        [HttpPut("update-title")]
        public IActionResult UpdateNoteTitle(Guid id, string title)
        {
            _noteDb.UpdateNoteTitle(id, title);
            return Ok("Updated Successfully");
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteNote(Guid id)
        {
            _noteDb.DeleteNote(id);
            return Ok("Deleted Successfully");
        }

        
        [HttpDelete("multiple")]
        public IActionResult DeleteNote([FromBody]List<Guid> id)
        {
            _noteDb.DeleteNote(id);
            return Ok("Deleted Successfully");
        }
      
    }
}
