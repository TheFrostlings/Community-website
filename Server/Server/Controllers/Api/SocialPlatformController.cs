using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Server.Models;
using System.Linq;
using Server.Models.Database;

namespace Server.Controllers.Api
{
	[Route("api/[controller]")]
	public class SocialPlatformController : Controller
	{
		private readonly DatabaseContext _context;

		public SocialPlatformController(DatabaseContext context)
		{
			_context = context;
		}

		[HttpGet]
		public IEnumerable<SocialPlatform> GetAll()
		{
			return _context.SocialPlatforms.ToList();
		}

		[HttpGet("{id}", Name = "GetSocialPlatformById")]
		public IActionResult GetById(long id)
		{
			var item = _context.SocialPlatforms.FirstOrDefault(t => t.Id == id);

			if( item == null )
				return NotFound();

			return new ObjectResult(item);
		}

		[HttpPost]
		public IActionResult Create([FromBody] SocialPlatform item)
		{
			if( item == null )
			{
				return BadRequest();
			}

			_context.SocialPlatforms.Add(item);
			_context.SaveChanges();

			return CreatedAtRoute("GetSocialPlatformById", new {id = item.Id}, item);
		}

		[HttpPut("{id}")]
		public IActionResult Update(long id, [FromBody] SocialPlatform item)
		{
			if( item == null || item.Id != id )
			{
				return BadRequest();
			}

			SocialPlatform platform = _context.SocialPlatforms.FirstOrDefault(t => t.Id == id);

			if( platform == null )
			{
				return NotFound();
			}

			platform.Name  = item.Name;
			platform.Image = item.Image;
			platform.Icon  = item.Icon;

			_context.SocialPlatforms.Update(platform);
			_context.SaveChanges();
			return new NoContentResult();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(long id)
		{
			var item = _context.SocialPlatforms.FirstOrDefault(t => t.Id == id);

			if( item == null )
			{
				return NotFound();
			}

			_context.SocialPlatforms.Remove(item);
			_context.SaveChanges();
			return new NoContentResult();
		}
	}
}
