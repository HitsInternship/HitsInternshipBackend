using Shared.Domain.Entites;

namespace SelectionModule.Domain.Entites;

public class VacancyResponseComment : Comment
{
    public VacancyResponseEntity VacancyResponse { get; set; }
}