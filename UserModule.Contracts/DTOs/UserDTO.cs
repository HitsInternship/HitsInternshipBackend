using UserModule.Domain.Entities;
using UserModule.Domain.Enums;

namespace UserModule.Contracts.DTOs
{
    /// <summary>
    /// DTO для представления информации о пользователе.
    /// </summary>
    public class UserDto
    {
        /// <summary>
        /// Уникальный идентификатор пользователя.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Имя пользователя.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Фамилия пользователя.
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Адрес электронной почты пользователя.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Список ролей пользователя.
        /// </summary>
        public List<RoleName> Roles { get; set; }

        /// <summary>
        /// Пустой конструктор для сериализации.
        /// </summary>
        public UserDto() { }

        /// <summary>
        /// Инициализация DTO из сущности пользователя.
        /// </summary>
        /// <param name="user">Сущность пользователя.</param>
        public UserDto(User user)
        {
            Id = user.Id;
            Name = user.Name;
            Surname = user.Surname;
            Email = user.Email;
            Roles = user.Roles.Select(role => role.RoleName).ToList();
        }
    }
}