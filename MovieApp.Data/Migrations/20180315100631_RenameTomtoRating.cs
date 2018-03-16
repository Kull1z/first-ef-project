using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MovieApp.Data.Migrations
{
    public partial class RenameTomtoRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TomatoRatings_Movies_MovieId",
                table: "TomatoRatings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TomatoRatings",
                table: "TomatoRatings");

            migrationBuilder.RenameTable(
                name: "TomatoRatings",
                newName: "TomatoRating");

            migrationBuilder.RenameIndex(
                name: "IX_TomatoRatings_MovieId",
                table: "TomatoRating",
                newName: "IX_TomatoRating_MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TomatoRating",
                table: "TomatoRating",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TomatoRating_Movies_MovieId",
                table: "TomatoRating",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TomatoRating_Movies_MovieId",
                table: "TomatoRating");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TomatoRating",
                table: "TomatoRating");

            migrationBuilder.RenameTable(
                name: "TomatoRating",
                newName: "TomatoRatings");

            migrationBuilder.RenameIndex(
                name: "IX_TomatoRating_MovieId",
                table: "TomatoRatings",
                newName: "IX_TomatoRatings_MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TomatoRatings",
                table: "TomatoRatings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TomatoRatings_Movies_MovieId",
                table: "TomatoRatings",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
