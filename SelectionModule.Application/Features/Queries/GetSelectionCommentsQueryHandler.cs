using MediatR;
using SelectionModule.Contracts.Queries;
using SelectionModule.Contracts.Repositories;
using Shared.Contracts.Dtos;
using Shared.Domain.Exceptions;
using UserModule.Contracts.Repositories;

namespace SelectionModule.Application.Features.Queries;

public class GetSelectionCommentsQueryHandler : IRequestHandler<GetSelectionCommentsQuery, List<CommentDto>>
{
    private readonly IUserRepository _userRepository;
    private readonly ISelectionRepository _selectionRepository;
    private readonly ISelectionCommentRepository _selectionCommentRepository;

    public GetSelectionCommentsQueryHandler(IUserRepository userRepository, ISelectionRepository selectionRepository,
        ISelectionCommentRepository selectionCommentRepository)
    {
        _userRepository = userRepository;
        _selectionRepository = selectionRepository;
        _selectionCommentRepository = selectionCommentRepository;
    }

    public async Task<List<CommentDto>> Handle(GetSelectionCommentsQuery request, CancellationToken cancellationToken)
    {
        if (!await _selectionRepository.CheckIfExistsAsync(request.SelectionId))
            throw new NotFound("Selection not found");


        var selection = await _selectionRepository.GetByIdAsync(request.SelectionId);

        if (selection.Candidate.UserId != request.UserId && !request.Roles.Contains("DeanMember"))
            throw new Forbidden("You do not have access to leave comment");

        var comments = selection.Comments;

        var result = new List<CommentDto>();

        foreach (var comment in comments)
        {
            var user = await _userRepository.GetByIdAsync(comment.UserId);

            result.Add(new CommentDto
            {
                Id = comment.Id,
                IsDeleted = comment.IsDeleted,
                Content = comment.Content,
                Author = new CommentUserDto
                {
                    Id = user.Id,
                    Name = user.Name,
                    Surname = user.Surname
                }
            });
        }
        
        return result;
    }
}