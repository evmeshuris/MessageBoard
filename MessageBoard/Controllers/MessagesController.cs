using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MessageBoard.Models;
using System.Linq;
using System;

namespace MessageBoard.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class MessagesController : ControllerBase
  {
    private readonly MessageBoardContext _db;
    public MessagesController(MessageBoardContext db)
    {
      _db = db;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Message>>> Get(string group, string author, DateTime date)
    {
      var query = _db.Messages.AsQueryable();
      if(group != null)
      {
        query = query.Where(e => e.Group == group);
      }
      if(author != null)
      {
        query = query.Where(e => e.Author == author);
      }
      if(date != null)
      {
        query = query.Where(e => e.Date >= date);
      }
      return await query.ToListAsync();
    }
    [HttpPost]
    public async Task<ActionResult<Message>> Post( Message message)
    {
      _db.Messages.Add(message);
      await _db.SaveChangesAsync();
      return CreatedAtAction("Post",new {id =message.MessageId},message);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Message>> GetMessage(int id)
    {
      var message= await _db.Messages.FindAsync(id);
      return message;

    }
  }
}