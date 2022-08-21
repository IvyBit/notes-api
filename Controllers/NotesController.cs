using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using notes_api.Data.Entities;
using notes_api.DTO;
using notes_api.Services.NotesProvider;

namespace notes_api.Controllers
{
    [Route("api/v1/[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly INotesProviderService _notesProvider;
        private readonly IMapper _mapper;
        public NotesController(INotesProviderService notesProvider, IMapper mapper)
        {
            _notesProvider = notesProvider;
            _mapper = mapper;
        }


        [HttpGet("{noteId:int}")]
        public async Task<DTONote> Get(int noteId)
        {
            return await Task.Run(async () => {
                var result = await _notesProvider.GetNoteAsync(noteId);
                return _mapper.Map<DTONote>(result);
            });
        }

        [HttpGet()]
        public async Task<IEnumerable<DTONote>> GetAll()
        {
            return await Task.Run(async () => {
                var result = await _notesProvider.GetNotesAsync();
                return _mapper.Map<IEnumerable<DTONote>>(result);
            });
        }

        [HttpPost]
        public async Task<DTONote> Post([FromBody] DTONote note)
        {
            return await Task.Run(async () => {
                var newNote = _mapper.Map<Note>(note);
                var result = await _notesProvider.AddNoteAsync(newNote);
                return _mapper.Map<DTONote>(result);
            });
        }

        [HttpPatch]
        public async Task<DTONote> Patch([FromBody] DTONote note)
        {
            return await Task.Run(async () => {
                var patchNote = _mapper.Map<Note>(note);
                var result = await _notesProvider.UpdateNoteAsync(patchNote);
                return _mapper.Map<DTONote>(result);
            });
        }

        [HttpDelete("{noteId:int}")]
        public async Task<DTONote> Delete(int noteId)
        {
            return await Task.Run(async () => {
                var result = await _notesProvider.DeleteNoteAsync(noteId);
                return _mapper.Map<DTONote>(result);
            });
        }
    }
}
