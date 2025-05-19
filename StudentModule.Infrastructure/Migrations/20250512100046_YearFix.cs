using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentModule.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class YearFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // 1. Создаем временный столбец
            migrationBuilder.AddColumn<int>(
                name: "YearTemp",
                table: "Streams",
                nullable: false,
                defaultValue: 2023); // Укажите год по умолчанию

            // 2. Конвертируем данные из DateTime в int (извлекаем год)
            migrationBuilder.Sql(@"
            UPDATE ""Streams""
            SET ""YearTemp"" = EXTRACT(YEAR FROM ""Year"")");

            // 3. Удаляем старый столбец
            migrationBuilder.DropColumn(
                name: "Year",
                table: "Streams");

            // 4. Переименовываем временный столбец
            migrationBuilder.RenameColumn(
                name: "YearTemp",
                table: "Streams",
                newName: "Year");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Обратная миграция (аналогичная логика)
            migrationBuilder.AddColumn<DateTime>(
                name: "YearTemp",
                table: "Streams",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 1));

            migrationBuilder.Sql(@"
            UPDATE ""Streams""
            SET ""YearTemp"" = MAKE_DATE(""Year"", 1, 1)");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Streams");

            migrationBuilder.RenameColumn(
                name: "YearTemp",
                table: "Streams",
                newName: "Year");
        }
    }
}
