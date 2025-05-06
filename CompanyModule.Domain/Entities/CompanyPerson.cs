using Shared.Domain.Entites;

namespace CompanyModule.Domain.Entities
{
    public abstract class CompanyPerson : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Telegram { get; set; }
        public string Phone { get; set; }
        public Guid UserId { get; set; }
        public Company Company { get; set; }

        protected CompanyPerson() {}
    }

    public class Curator : CompanyPerson
    {
        public Curator() {}
    }

    public class CompanyRepresenter : CompanyPerson
    {
        public CompanyRepresenter() {}
    }
}
