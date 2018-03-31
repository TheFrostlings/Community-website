using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Server.Models;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Server.Models.Database;

namespace Server.Controllers.Api
{
	[Route("api/[controller]")]
	public class DiscordUserController : Controller
	{
		private readonly DatabaseContext _context;

		public DiscordUserController(DatabaseContext context)
		{
			_context = context;
		}

		[HttpGet]
		public IEnumerable<DiscordUser> GetAll()
		{
			return _context.DiscordUsers.ToList();
		}

		[HttpGet("{id}", Name = "GetUserById")]
		public IActionResult GetById(long id)
		{
			var item = _context.DiscordUsers.FirstOrDefault(t => t.Id == id);

			if( item == null )
			{
				return NotFound();
			}

			return new ObjectResult(item);
		}

		[HttpPost]
		public IActionResult Create([FromBody] DiscordUser item)
		{
			if( item == null )
			{
				return BadRequest();
			}

			_context.DiscordUsers.Add(item);
			_context.SaveChanges();

			return CreatedAtRoute("GetUserById", new {id = item.Id}, item);
		}

		[HttpPut("{id}")]
		public IActionResult Update(long id, [FromBody] DiscordUser item)
		{
			if( item == null || item.Id != id )
			{
				return BadRequest();
			}

			DiscordUser user = _context.DiscordUsers.FirstOrDefault(t => t.Id == id);

			if( user == null )
			{
				return NotFound();
			}

			user.Username   = item.Username;
			user.DiscordTag = item.DiscordTag;
			user.Summary    = item.Summary;

			_context.DiscordUsers.Update(user);
			_context.SaveChanges();
			return new NoContentResult();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(long id)
		{
			var item = _context.DiscordUsers.FirstOrDefault(t => t.Id == id);

			if( item == null )
			{
				return NotFound();
			}

			_context.DiscordUsers.Remove(item);
			_context.SaveChanges();
			return new NoContentResult();
		}
	}
}
