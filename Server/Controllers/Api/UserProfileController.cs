using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Server.Models;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Server.Models.Database;

namespace Server.Controllers.Api
{
	[Route("api/[controller]")]
	public class UserProfileController : Controller
	{
		private readonly DatabaseContext _context;

		public UserProfileController(DatabaseContext context)
		{
			_context = context;
		}

		[HttpGet]
		public IEnumerable<UserProfile> GetAll()
		{
			return _context.UserProfiles.ToList();
		}

		[HttpGet("{id}", Name = "GetUserProfileById")]
		public IActionResult GetById(long id)
		{
			var item = _context.UserProfiles.FirstOrDefault(t => t.Id == id);

			if( item == null )
			{
				return NotFound();
			}

			return new ObjectResult(item);
		}

		[HttpPost]
		public IActionResult Create([FromBody] UserProfile item)
		{
			if( item == null )
			{
				return BadRequest();
			}

			_context.UserProfiles.Add(item);
			_context.SaveChanges();

			return CreatedAtRoute("GetUserProfileById", new {id = item.Id}, item);
		}

		[HttpPut("{id}")]
		public IActionResult Update(long id, [FromBody] UserProfile item)
		{
			if( item == null || item.Id != id )
			{
				return BadRequest();
			}

			UserProfile profile = _context.UserProfiles.FirstOrDefault(t => t.Id == id);

			if( profile == null )
			{
				return NotFound();
			}

			profile.Username = item.Username;
			profile.Url      = item.Url;

			_context.UserProfiles.Update(profile);
			_context.SaveChanges();
			return new NoContentResult();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(long id)
		{
			var item = _context.UserProfiles.FirstOrDefault(t => t.Id == id);

			if( item == null )
			{
				return NotFound();
			}

			_context.UserProfiles.Remove(item);
			_context.SaveChanges();
			return new NoContentResult();
		}
	}
}
