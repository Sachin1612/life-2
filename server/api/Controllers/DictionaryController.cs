

using data.mongo;
using Microsoft.AspNetCore.Mvc;
using models;

[ApiController]
[Route("api/[controller]")]
public class DictionaryController : ControllerBase
{
  public readonly IMongoRepository<Dict> _noteRepo;
  public DictionaryController(IMongoRepository<Dict> noteRepo)
  {
    _noteRepo = noteRepo;
  }

  
  [HttpGet]
  public IActionResult Get()
  {
    var input = _noteRepo.FilterBy(x => x.isActive == true);
    return Ok(input);
  }

  [HttpPost("add")]
  public async Task<IActionResult> Add([FromBody] Dict input)
  {
    input.isActive = true;
    await _noteRepo.InsertOneAsync(input);
    return Ok(input);
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

  // [HttpPut("update/{id}/title")]
  // public async Task<IActionResult> UpdateNoteTitle(string id, [FromBody] string title)
  // {
  //   try
  //   {
  //     var note = await _noteRepo.FindByIdAsync(id);
  //     if (note == null)
  //       return NotFound();

  //     note.Title = title;
  //     await _noteRepo.ReplaceOneAsync(note);
  //     return Ok(note);
  //   }
  //   catch (System.Exception ex)
  //   {
      
  //     throw ex;
  //   }
  // }

  // [HttpGet("notes")]
  // public IActionResult GetNotes()
  // {
  //   var notes = _noteRepo.FilterBy(x => x.isActive == true);
  //   return Ok(notes);
  // }
}