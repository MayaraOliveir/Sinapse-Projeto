using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sinapse.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaTrocasConhecimento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoginsUsuario_Usuarios_UserId",
                table: "LoginsUsuario");

            migrationBuilder.DropForeignKey(
                name: "FK_Publicacoes_Comunidades_CommunityId",
                table: "Publicacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_ReivindicacoesFuncao_Funcoes_RoleId",
                table: "ReivindicacoesFuncao");

            migrationBuilder.DropForeignKey(
                name: "FK_ReivindicacoesUsuario_Usuarios_UserId",
                table: "ReivindicacoesUsuario");

            migrationBuilder.DropForeignKey(
                name: "FK_TokensUsuario_Usuarios_UserId",
                table: "TokensUsuario");

            migrationBuilder.DropIndex(
                name: "IX_TrocasConhecimento_RequesterId",
                table: "TrocasConhecimento");

            migrationBuilder.DropIndex(
                name: "IX_Curtidas_PostId_UserId",
                table: "Curtidas");

            migrationBuilder.DropIndex(
                name: "IX_Conexoes_RequesterId_AddresseeId",
                table: "Conexoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TokensUsuario",
                table: "TokensUsuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReivindicacoesUsuario",
                table: "ReivindicacoesUsuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReivindicacoesFuncao",
                table: "ReivindicacoesFuncao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoginsUsuario",
                table: "LoginsUsuario");

            migrationBuilder.DropColumn(
                name: "RelatedId",
                table: "Notificacoes");

            migrationBuilder.RenameTable(
                name: "TokensUsuario",
                newName: "UsuariosTokens");

            migrationBuilder.RenameTable(
                name: "ReivindicacoesUsuario",
                newName: "UsuariosReivindicacoes");

            migrationBuilder.RenameTable(
                name: "ReivindicacoesFuncao",
                newName: "FuncoesReivindicacoes");

            migrationBuilder.RenameTable(
                name: "LoginsUsuario",
                newName: "UsuariosLogins");

            migrationBuilder.RenameColumn(
                name: "MessageId",
                table: "MensagensDiretas",
                newName: "DirectMessageId");

            migrationBuilder.RenameIndex(
                name: "IX_ReivindicacoesUsuario_UserId",
                table: "UsuariosReivindicacoes",
                newName: "IX_UsuariosReivindicacoes_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ReivindicacoesFuncao_RoleId",
                table: "FuncoesReivindicacoes",
                newName: "IX_FuncoesReivindicacoes_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_LoginsUsuario_UserId",
                table: "UsuariosLogins",
                newName: "IX_UsuariosLogins_UserId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Usuarios",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<string>(
                name: "ProfilePhotoUrl",
                table: "Usuarios",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Usuarios",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "TrocasConhecimento",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "TrocasConhecimento",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddColumn<DateTime>(
                name: "CompletedAt",
                table: "TrocasConhecimento",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DesiredSkill",
                table: "TrocasConhecimento",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OfferedSkill",
                table: "TrocasConhecimento",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Publicacoes",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Publicacoes",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Notificacoes",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReadAt",
                table: "Notificacoes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "MensagensDiretas",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReadAt",
                table: "MensagensDiretas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Conexoes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Comentarios",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsuariosTokens",
                table: "UsuariosTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsuariosReivindicacoes",
                table: "UsuariosReivindicacoes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FuncoesReivindicacoes",
                table: "FuncoesReivindicacoes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsuariosLogins",
                table: "UsuariosLogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.CreateIndex(
                name: "IX_TrocasConhecimento_RequesterId_AddresseeId",
                table: "TrocasConhecimento",
                columns: new[] { "RequesterId", "AddresseeId" });

            migrationBuilder.CreateIndex(
                name: "IX_Curtidas_PostId",
                table: "Curtidas",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Conexoes_RequesterId",
                table: "Conexoes",
                column: "RequesterId");

            migrationBuilder.AddForeignKey(
                name: "FK_FuncoesReivindicacoes_Funcoes_RoleId",
                table: "FuncoesReivindicacoes",
                column: "RoleId",
                principalTable: "Funcoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Publicacoes_Comunidades_CommunityId",
                table: "Publicacoes",
                column: "CommunityId",
                principalTable: "Comunidades",
                principalColumn: "CommunityId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuariosLogins_Usuarios_UserId",
                table: "UsuariosLogins",
                column: "UserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuariosReivindicacoes_Usuarios_UserId",
                table: "UsuariosReivindicacoes",
                column: "UserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuariosTokens_Usuarios_UserId",
                table: "UsuariosTokens",
                column: "UserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FuncoesReivindicacoes_Funcoes_RoleId",
                table: "FuncoesReivindicacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Publicacoes_Comunidades_CommunityId",
                table: "Publicacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuariosLogins_Usuarios_UserId",
                table: "UsuariosLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuariosReivindicacoes_Usuarios_UserId",
                table: "UsuariosReivindicacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuariosTokens_Usuarios_UserId",
                table: "UsuariosTokens");

            migrationBuilder.DropIndex(
                name: "IX_TrocasConhecimento_RequesterId_AddresseeId",
                table: "TrocasConhecimento");

            migrationBuilder.DropIndex(
                name: "IX_Curtidas_PostId",
                table: "Curtidas");

            migrationBuilder.DropIndex(
                name: "IX_Conexoes_RequesterId",
                table: "Conexoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsuariosTokens",
                table: "UsuariosTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsuariosReivindicacoes",
                table: "UsuariosReivindicacoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsuariosLogins",
                table: "UsuariosLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FuncoesReivindicacoes",
                table: "FuncoesReivindicacoes");

            migrationBuilder.DropColumn(
                name: "CompletedAt",
                table: "TrocasConhecimento");

            migrationBuilder.DropColumn(
                name: "DesiredSkill",
                table: "TrocasConhecimento");

            migrationBuilder.DropColumn(
                name: "OfferedSkill",
                table: "TrocasConhecimento");

            migrationBuilder.DropColumn(
                name: "Link",
                table: "Notificacoes");

            migrationBuilder.DropColumn(
                name: "ReadAt",
                table: "Notificacoes");

            migrationBuilder.DropColumn(
                name: "ReadAt",
                table: "MensagensDiretas");

            migrationBuilder.RenameTable(
                name: "UsuariosTokens",
                newName: "TokensUsuario");

            migrationBuilder.RenameTable(
                name: "UsuariosReivindicacoes",
                newName: "ReivindicacoesUsuario");

            migrationBuilder.RenameTable(
                name: "UsuariosLogins",
                newName: "LoginsUsuario");

            migrationBuilder.RenameTable(
                name: "FuncoesReivindicacoes",
                newName: "ReivindicacoesFuncao");

            migrationBuilder.RenameColumn(
                name: "DirectMessageId",
                table: "MensagensDiretas",
                newName: "MessageId");

            migrationBuilder.RenameIndex(
                name: "IX_UsuariosReivindicacoes_UserId",
                table: "ReivindicacoesUsuario",
                newName: "IX_ReivindicacoesUsuario_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UsuariosLogins_UserId",
                table: "LoginsUsuario",
                newName: "IX_LoginsUsuario_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_FuncoesReivindicacoes_RoleId",
                table: "ReivindicacoesFuncao",
                newName: "IX_ReivindicacoesFuncao_RoleId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Usuarios",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "ProfilePhotoUrl",
                table: "Usuarios",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Usuarios",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "TrocasConhecimento",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "TrocasConhecimento",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Publicacoes",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Publicacoes",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "RelatedId",
                table: "Notificacoes",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "MensagensDiretas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Conexoes",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Comentarios",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TokensUsuario",
                table: "TokensUsuario",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReivindicacoesUsuario",
                table: "ReivindicacoesUsuario",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoginsUsuario",
                table: "LoginsUsuario",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReivindicacoesFuncao",
                table: "ReivindicacoesFuncao",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TrocasConhecimento_RequesterId",
                table: "TrocasConhecimento",
                column: "RequesterId");

            migrationBuilder.CreateIndex(
                name: "IX_Curtidas_PostId_UserId",
                table: "Curtidas",
                columns: new[] { "PostId", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Conexoes_RequesterId_AddresseeId",
                table: "Conexoes",
                columns: new[] { "RequesterId", "AddresseeId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LoginsUsuario_Usuarios_UserId",
                table: "LoginsUsuario",
                column: "UserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Publicacoes_Comunidades_CommunityId",
                table: "Publicacoes",
                column: "CommunityId",
                principalTable: "Comunidades",
                principalColumn: "CommunityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReivindicacoesFuncao_Funcoes_RoleId",
                table: "ReivindicacoesFuncao",
                column: "RoleId",
                principalTable: "Funcoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReivindicacoesUsuario_Usuarios_UserId",
                table: "ReivindicacoesUsuario",
                column: "UserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TokensUsuario_Usuarios_UserId",
                table: "TokensUsuario",
                column: "UserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
