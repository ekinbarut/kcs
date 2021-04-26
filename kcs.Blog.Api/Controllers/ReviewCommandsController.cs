using kcs.Blog.Abstraction.Command;
using kcs.Blog.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kcs.Blog.Api.Controllers
{

    [Route("api/reviews")]
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize]
    public class ReviewCommandsController : Controller
    {
        private readonly IMediator mediator;


        public ReviewCommandsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("add")]
        public async Task<ActionResult<Review>> Create([FromBody] AddReviewCommand request)
        {
            var article = await mediator.Send(request);

            return Ok();
        }

        [HttpPost("update")]
        public async Task<ActionResult<Review>> Update([FromBody] UpdateReviewCommand request)
        {
            var article = await mediator.Send(request);

            return Ok();
        }

        [HttpPost("remove")]
        public async Task<IActionResult> Delete([FromBody] RemoveReviewCommand request)
        {
            await mediator.Send(request);
            return Ok();
        }
    }
}
