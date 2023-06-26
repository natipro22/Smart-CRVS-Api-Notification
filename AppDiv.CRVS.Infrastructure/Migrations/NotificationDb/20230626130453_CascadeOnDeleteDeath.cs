using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppDiv.CRVS.Infrastructure.Migrations.NotificationDb
{
    public partial class CascadeOnDeleteDeath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeathRegistrars_DeathNotifications_DeathNotificationId",
                table: "DeathRegistrars");

            migrationBuilder.DropForeignKey(
                name: "FK_Deceased_DeathNotifications_DeathNotificationId",
                table: "Deceased");

            migrationBuilder.AlterColumn<Guid>(
                name: "DeathNotificationId",
                table: "Deceased",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "DeathNotificationId",
                table: "DeathRegistrars",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddForeignKey(
                name: "FK_DeathRegistrars_DeathNotifications_DeathNotificationId",
                table: "DeathRegistrars",
                column: "DeathNotificationId",
                principalTable: "DeathNotifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Deceased_DeathNotifications_DeathNotificationId",
                table: "Deceased",
                column: "DeathNotificationId",
                principalTable: "DeathNotifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeathRegistrars_DeathNotifications_DeathNotificationId",
                table: "DeathRegistrars");

            migrationBuilder.DropForeignKey(
                name: "FK_Deceased_DeathNotifications_DeathNotificationId",
                table: "Deceased");

            migrationBuilder.AlterColumn<Guid>(
                name: "DeathNotificationId",
                table: "Deceased",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "DeathNotificationId",
                table: "DeathRegistrars",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddForeignKey(
                name: "FK_DeathRegistrars_DeathNotifications_DeathNotificationId",
                table: "DeathRegistrars",
                column: "DeathNotificationId",
                principalTable: "DeathNotifications",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Deceased_DeathNotifications_DeathNotificationId",
                table: "Deceased",
                column: "DeathNotificationId",
                principalTable: "DeathNotifications",
                principalColumn: "Id");
        }
    }
}
