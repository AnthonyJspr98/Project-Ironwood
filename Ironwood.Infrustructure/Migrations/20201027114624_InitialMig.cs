using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ironwood.Infrastructure.Migrations
{
    public partial class InitialMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UID = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 100, nullable: true),
                    MiddleName = table.Column<string>(maxLength: 100, nullable: true),
                    LastName = table.Column<string>(maxLength: 100, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "DATE", nullable: true),
                    Gender = table.Column<string>(maxLength: 30, nullable: true),
                    AccessRole = table.Column<byte>(nullable: false),
                    EmailAddress = table.Column<string>(maxLength: 320, nullable: false),
                    MobileNumber = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    Username = table.Column<string>(maxLength: 100, nullable: false),
                    Salt = table.Column<byte[]>(maxLength: 500, nullable: false),
                    Password = table.Column<byte[]>(maxLength: 500, nullable: false),
                    LastChangedPassword = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_ID",
                        column: x => x.ID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wallets",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    Address = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallets", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Wallets_Users_ID",
                        column: x => x.ID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoginHistories",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IP = table.Column<string>(maxLength: 20, nullable: true),
                    LoggedOn = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CountryCode = table.Column<string>(maxLength: 2, nullable: true),
                    RegionName = table.Column<string>(maxLength: 128, nullable: true),
                    CityName = table.Column<string>(maxLength: 128, nullable: true),
                    UserLoginID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginHistories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LoginHistories_UserLogins_UserLoginID",
                        column: x => x.UserLoginID,
                        principalTable: "UserLogins",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WalletTransactions",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UID = table.Column<Guid>(nullable: false),
                    TransactedOn = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<decimal>(type: "DECIMAL(20,8)", nullable: false),
                    Remarks = table.Column<string>(maxLength: 255, nullable: true),
                    WalletID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalletTransactions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WalletTransactions_Wallets_WalletID",
                        column: x => x.WalletID,
                        principalTable: "Wallets",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "AccessRole", "Address", "BirthDate", "City", "Country", "EmailAddress", "FirstName", "Gender", "LastName", "MiddleName", "MobileNumber", "UID" },
                values: new object[] { 1, (byte)1, null, null, null, null, "admin@auxiliaglobal.com", "Admin", null, "App", null, null, new Guid("174f3731-c23a-48ed-948c-eda9a8f6a05e") });

            migrationBuilder.InsertData(
                table: "UserLogins",
                columns: new[] { "ID", "Password", "Salt", "Username" },
                values: new object[] { 1, new byte[] { 0, 65, 68, 77, 73, 78, 45, 83, 65, 76, 84, 45, 49, 50, 51, 52, 33, 152, 156, 47, 115, 252, 177, 181, 237, 49, 172, 91, 121, 81, 188, 196, 100, 45, 157, 169, 124, 209, 176, 77, 87, 192, 4, 80, 245, 135, 176, 31, 123 }, new byte[] { 65, 68, 77, 73, 78, 45, 83, 65, 76, 84, 45, 49, 50, 51, 52, 33, 64, 35, 36 }, "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_LoginHistories_UserLoginID",
                table: "LoginHistories",
                column: "UserLoginID");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_Username",
                table: "UserLogins",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_EmailAddress",
                table: "Users",
                column: "EmailAddress",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UID",
                table: "Users",
                column: "UID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wallets_Address",
                table: "Wallets",
                column: "Address",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WalletTransactions_WalletID",
                table: "WalletTransactions",
                column: "WalletID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoginHistories");

            migrationBuilder.DropTable(
                name: "WalletTransactions");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "Wallets");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
