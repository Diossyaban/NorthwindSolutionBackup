using Microsoft.EntityFrameworkCore.Migrations;

namespace Northwind.Persistence.Migrations.Northwind
{
    public partial class AddRoleToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7521e825-1614-449d-8678-a59397efb921", "a12b3c3f-6d06-498c-afb8-2bebb9267804", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6a10317f-194e-49f2-ba46-652e141b8467", "af9213f8-f3ac-4243-afd0-bed7dce3a1f4", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a10317f-194e-49f2-ba46-652e141b8467");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7521e825-1614-449d-8678-a59397efb921");
        }
    }
}
