using ESShopDAL.Models;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ESShopDAL.Migrations
{
	public partial class Test : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<Order>("Test", "Order", defaultValue: string.Empty);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn("Test", "Order");
		}
	}
}