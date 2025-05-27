namespace Shared.Contracts.Dtos;

public record CommentDto : BaseDto
{
    public string Content { get; init; }
    public CommentUserDto Author { get; init; }
}