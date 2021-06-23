using Application.CQRS.Commands.OrganizationCommand;
using Application.CQRS.Queries.OrganizationQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private IMediator mediator;

        public OrganizationController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await mediator.Send(new GetAllOrganizationQuery()));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await mediator.Send(new GetOrganizationByIdQuery { Id = id }));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create(CreateOrganizationCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update(long id, UpdateOrganizationCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            return Ok(await mediator.Send(command));
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await mediator.Send(new DeleteOrganizationByIdCommand { Id = id }));
        }
    }
}
