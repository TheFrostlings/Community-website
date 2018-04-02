using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Server.Models;
using System.Linq;
using Server.Models.Database;

namespace Server.Controllers.Api
{
	[Route("api/[controller]")]
	public class PollController : Controller
	{
		private readonly DatabaseContext _context;

		public PollController(DatabaseContext context)
		{
			_context = context;
		}

		[HttpGet]
		public IEnumerable<PollQuestion> GetAll()
		{
			return _context.PollQuestions.ToList();
		}

		[HttpGet("{id}", Name = "GetPollQuestionById")]
		public IActionResult GetById(long id)
		{
			var item = _context.PollQuestions.FirstOrDefault(t => t.Id == id);

			if( item == null )
				return NotFound();

			return new ObjectResult(item);
		}

		[HttpPost]
		public IActionResult Create([FromBody] PollQuestion item)
		{
			if( item == null )
			{
				return BadRequest();
			}

			_context.PollQuestions.Add(item);
			_context.SaveChanges();

			return CreatedAtRoute("GetPollQuestionById", new {id = item.Id}, item);
		}

		[HttpPut("{id}")]
		public IActionResult Update(long id, [FromBody] PollQuestion item)
		{
			if( item == null || item.Id != id )
			{
				return BadRequest();
			}

			PollQuestion pollQuestion = _context.PollQuestions.FirstOrDefault(t => t.Id == id);

			if( pollQuestion == null )
			{
				return NotFound();
			}

			// pollQuestion.Username = item.Username;

			_context.PollQuestions.Update(pollQuestion);
			_context.SaveChanges();
			return new NoContentResult();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(long id)
		{
			var item = _context.PollQuestions.FirstOrDefault(t => t.Id == id);

			if( item == null )
			{
				return NotFound();
			}

			_context.PollQuestions.Remove(item);
			_context.SaveChanges();
			return new NoContentResult();
		}
	}
}
