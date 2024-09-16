using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InScreeningApi.Migrations
{
    /// <inheritdoc />
    public partial class secod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
         

            migrationBuilder.CreateTable(
           name: "Endereco",
           columns: table => new
           {
               EnderecoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                   .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
               Estado = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
               Municipio = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
               Logradouro = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
               Numero = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
               Complemento = table.Column<int>(type: "NVARCHAR2(200)", nullable: false),
               Cep = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
           },
           constraints: table =>
           {
               table.PrimaryKey("PK_Endereco", x => x.EnderecoId);
           });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
      
        }
    }
}
