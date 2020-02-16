using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NavyBattle.Dal.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BattleFields",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Width = table.Column<int>(nullable: false),
                    Height = table.Column<int>(nullable: false),
                    OwnerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BattleFields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BattleFields_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    State = table.Column<int>(nullable: false),
                    WinnerId = table.Column<int>(nullable: true),
                    TurnOfThePlayer = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Users_WinnerId",
                        column: x => x.WinnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BattleShips",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Length = table.Column<int>(nullable: false),
                    IsVertical = table.Column<bool>(nullable: false),
                    StartX = table.Column<int>(nullable: false),
                    StartY = table.Column<int>(nullable: false),
                    BattleFieldId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BattleShips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BattleShips_BattleFields_BattleFieldId",
                        column: x => x.BattleFieldId,
                        principalTable: "BattleFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GameBattleFields",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BattleFieldId = table.Column<int>(nullable: true),
                    GameId = table.Column<int>(nullable: true),
                    OwnerId = table.Column<int>(nullable: true),
                    IsWaiting = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameBattleFields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameBattleFields_BattleFields_BattleFieldId",
                        column: x => x.BattleFieldId,
                        principalTable: "BattleFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameBattleFields_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameBattleFields_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GameBattleShips",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GameBattlefieldId = table.Column<int>(nullable: true),
                    BattleShipId = table.Column<int>(nullable: true),
                    State = table.Column<int>(nullable: false),
                    DamagedPointsCnt = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameBattleShips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameBattleShips_BattleShips_BattleShipId",
                        column: x => x.BattleShipId,
                        principalTable: "BattleShips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameBattleShips_GameBattleFields_GameBattlefieldId",
                        column: x => x.GameBattlefieldId,
                        principalTable: "GameBattleFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Shots",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ShotX = table.Column<int>(nullable: false),
                    ShotY = table.Column<int>(nullable: false),
                    State = table.Column<int>(nullable: false),
                    PlayerId = table.Column<int>(nullable: true),
                    GameBattleFieldId = table.Column<int>(nullable: true),
                    GameId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shots_GameBattleFields_GameBattleFieldId",
                        column: x => x.GameBattleFieldId,
                        principalTable: "GameBattleFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BattleFields_OwnerId",
                table: "BattleFields",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleShips_BattleFieldId",
                table: "BattleShips",
                column: "BattleFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_GameBattleFields_BattleFieldId",
                table: "GameBattleFields",
                column: "BattleFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_GameBattleFields_GameId",
                table: "GameBattleFields",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GameBattleFields_OwnerId",
                table: "GameBattleFields",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_GameBattleShips_BattleShipId",
                table: "GameBattleShips",
                column: "BattleShipId");

            migrationBuilder.CreateIndex(
                name: "IX_GameBattleShips_GameBattlefieldId",
                table: "GameBattleShips",
                column: "GameBattlefieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_WinnerId",
                table: "Games",
                column: "WinnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Shots_GameBattleFieldId",
                table: "Shots",
                column: "GameBattleFieldId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameBattleShips");

            migrationBuilder.DropTable(
                name: "Shots");

            migrationBuilder.DropTable(
                name: "BattleShips");

            migrationBuilder.DropTable(
                name: "GameBattleFields");

            migrationBuilder.DropTable(
                name: "BattleFields");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
