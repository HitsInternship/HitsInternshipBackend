using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SelectionModule.Contracts.Commands.SelectionComment;
using SelectionModule.Contracts.Queries;
using Shared.Contracts.Dtos;
using UserModule.Persistence;

namespace SelectionModule.Controllers.Controllers;

[Authorize]
[ApiController]
[Route("api/selections")]
public class SelectionCommentController : ControllerBase
{
    private readonly IMediator _mediator;

    public SelectionCommentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost, Route("{selectionId}/comments")]
    public async Task<IActionResult> CreateComment(Guid selectionId, [FromBody] string comment)
    {
        return Ok(await _mediator.Send(
            new CreateSelectionCommentCommand(selectionId, User.GetUserId(), comment, User.GetRoles())));
    }

    [HttpDelete, Route("{selectionId}/comments/{commentId}")]
    public async Task<IActionResult> DeleteComment(Guid selectionId, Guid commentId)
    {
        return Ok(await _mediator.Send(new DeleteSelectionCommentCommand(selectionId, commentId, User.GetUserId())));
    }

    [HttpGet, Route("{selectionId}/comments")]
    [ProducesResponseType(typeof(List<CommentDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetComments(Guid selectionId)
    {
        return Ok(await _mediator.Send(new GetSelectionCommentsQuery(selectionId, User.GetUserId(), User.GetRoles())));
    }

    [HttpPut, Route("{selectionId}/comments/{commentId}")]
    public async Task<IActionResult> UpdateComment(Guid selectionId, Guid commentId, [FromBody] string comment)
    {
        return Ok(await _mediator.Send(
            new UpdateSelectionCommentCommand(selectionId, commentId, User.GetUserId(), comment)));
    }
}