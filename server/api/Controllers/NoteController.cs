

using data.mongo;
using Microsoft.AspNetCore.Mvc;
using models;

[ApiController]
[Route("api/[controller]")]
public class NoteController : ControllerBase
{
  public readonly IMongoRepository<Note> _noteRepo;
  public NoteController(IMongoRepository<Note> noteRepo)
  {
    _noteRepo = noteRepo;
  }

  [HttpPost("add/note")]
  public async Task<IActionResult> AddNote([FromBody] Note input)
  {
    input.isActive = true;
    await _noteRepo.InsertOneAsync(input);
    return Ok(input);
  }

  [HttpPut("update/{id}/title")]
  public async Task<IActionResult> UpdateNoteTitle(string id, [FromBody] string title)
  {
    try
    {
      var note = await _noteRepo.FindByIdAsync(id);
      if (note == null)
        return NotFound();

      note.Title = title;
      await _noteRepo.ReplaceOneAsync(note);
      return Ok(note);
    }
    catch (System.Exception ex)
    {
      
      throw ex;
    }
  }


  [HttpPut("update/{id}/description")]
  public async Task<IActionResult> UpdateNoteDescription(string id, [FromBody] string description)
  {
    try
    {
      var note = await _noteRepo.FindByIdAsync(id);
      if (note == null)
        return NotFound();

      note.Description = description;
      await _noteRepo.ReplaceOneAsync(note);
      return Ok(note);
    }
    catch (System.Exception ex)
    {
      
      throw ex;
    }
  }

  [HttpDelete("{id}/delete")]
  public async Task<IActionResult> Delete(string id)
  {
    var dict = await _noteRepo.FindByIdAsync(id);
    if (dict == null)
      return NotFound(id);

    await _noteRepo.DeleteByIdAsync(id);
    return Ok(id);
  }


  [HttpGet("notes")]
  public IActionResult GetNotes()
  {
    var notes = _noteRepo.FilterBy(x => x.isActive == true);
    return Ok(notes);
  }
}