using MediatR;
using Microsoft.AspNetCore.Mvc;
using OG.CRUD.VUE.Application.Common.DTOs;
using OG.CRUD.VUE.Application.Features.Person.Commands;
using OG.CRUD.VUE.Application.Features.Person.Queries;

namespace OG.CRUD.VUE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new GetPersonsQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            var result = await _mediator.Send(new GetSinglePersonQuery(id));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddPerson([FromBody] PersonDTO person)
        {
            var result = await _mediator.Send(new AddPersonCommand(person));
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePerson([FromBody] PersonDTO person)
        {
            var result = await _mediator.Send(new UpdatePersonCommand(person));
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var result = await _mediator.Send(new DeletePersonCommand(id));
            return Ok(result);
        }
    }
}
