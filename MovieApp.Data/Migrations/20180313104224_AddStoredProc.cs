using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MovieApp.Data.Migrations
{
    public partial class AddStoredProc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"CREATE PROCEDURE FilterMovieByTitlePart
                @titlepart varchar(50)
                AS
                SELECT * FROM Movies WHERE Title LIKE '%'+@titlepart+'%'"); 
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE FilterMovieByTitlePart");
        }
    }
}
