using kcs.Blog.Abstraction.Command;
using kcs.Blog.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace kcs.Blog.Api.Controllers
{
    [Route("api/articles")]
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize]
    public class ArticleCommandsController : Controller
    {
        private readonly IMediator mediator;


        public ArticleCommandsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<ActionResult<Article>> Create([FromBody] CreateArticleCommand request)
        {
            var article = await mediator.Send(request);

            return Ok();
        }

        [HttpPost("update")]
        public async Task<ActionResult<Article>> Update([FromBody] UpdateArticleCommand request)
        {
            var article = await mediator.Send(request);

            return Ok();
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteArticleCommand request)
        {
            await mediator.Send(request);
            return Ok();
        }
    }
}
