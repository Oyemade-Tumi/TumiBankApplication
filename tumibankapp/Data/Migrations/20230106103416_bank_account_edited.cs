using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tumibankapp.Data.Migrations
{
    public partial class bank_account_edited : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AccountPhoneNumber",
                table: "BankAccounts",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "AccountLastName",
                table: "BankAccounts",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "AccountFirstName",
                table: "BankAccounts",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "AccountEmailAddress",
                table: "BankAccounts",
                newName: "EmailAddress");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "BankAccounts",
                newName: "AccountPhoneNumber");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "BankAccounts",
                newName: "AccountLastName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "BankAccounts",
                newName: "AccountFirstName");

            migrationBuilder.RenameColumn(
                name: "EmailAddress",
                table: "BankAccounts",
                newName: "AccountEmailAddress");
        }
    }
}
