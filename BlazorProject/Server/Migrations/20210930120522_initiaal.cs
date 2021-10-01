using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorProject.Server.Migrations
{
    public partial class initiaal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountId);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    ProfileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Alias = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Postal = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.ProfileId);
                    table.ForeignKey(
                        name: "FK_Profiles_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sender = table.Column<int>(type: "int", nullable: false),
                    Receiver = table.Column<int>(type: "int", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_Messages_Profiles_SenderId",
                        column: x => x.Sender,
                        principalTable: "Profiles",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_Profiles_ReceiverId",
                        column: x => x.Receiver,
                        principalTable: "Profiles",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "CreateDate", "Email", "Password", "Phone" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 9, 30, 14, 5, 20, 940, DateTimeKind.Local).AddTicks(5477), "Eva@pragimtech.com", "1234", 12233456 },
                    { 2, new DateTime(2021, 9, 30, 14, 5, 20, 945, DateTimeKind.Local).AddTicks(4170), "Adam@pragimtech.com", "1234", 12233456 }
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "ProfileId", "AccountId", "Alias", "BirthDate", "Gender", "PhotoPath", "Postal" },
                values: new object[] { 1, 1, "Eva", new DateTime(1970, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "esegesg", 2300 });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "ProfileId", "AccountId", "Alias", "BirthDate", "Gender", "PhotoPath", "Postal" },
                values: new object[] { 2, 2, "Adam", new DateTime(1980, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "esegesg", 2300 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "MessageId", "MessageText", "Receiver", "Sender", "TimeStamp" },
                values: new object[,]
                {
                    { 1, "Hej med dig, hvad laver du her?", 2, 1, new DateTime(1999, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Det samme som dig?", 1, 2, new DateTime(1999, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });


            migrationBuilder.CreateIndex(
                name: "IX_Messages_MessageId",
                table: "Messages",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_AccountId",
                table: "Profiles",
                column: "AccountId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
