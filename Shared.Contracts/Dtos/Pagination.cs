namespace Shared.Contracts.Dtos;

public record Pagination(int Size, int Count, int Current)
{
    public int Size { get; set; } = Size;

    public int Count { get; set; } = Count;

    public int Current { get; set; } = Current;
}