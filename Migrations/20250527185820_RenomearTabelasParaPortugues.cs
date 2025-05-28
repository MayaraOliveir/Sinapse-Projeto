using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sinapse.Migrations
{
    /// <inheritdoc />
    public partial class RenomearTabelasParaPortugues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_PostId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Communities_AspNetUsers_CreatedByUserId",
                table: "Communities");

            migrationBuilder.DropForeignKey(
                name: "FK_Connections_AspNetUsers_AddresseeId",
                table: "Connections");

            migrationBuilder.DropForeignKey(
                name: "FK_Connections_AspNetUsers_RequesterId",
                table: "Connections");

            migrationBuilder.DropForeignKey(
                name: "FK_DirectMessages_AspNetUsers_ReceiverId",
                table: "DirectMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_DirectMessages_AspNetUsers_SenderId",
                table: "DirectMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_AspNetUsers_UserId",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Posts_PostId",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_AspNetUsers_UserId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_UserId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Communities_CommunityId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillSwaps_AspNetUsers_AddresseeId",
                table: "SkillSwaps");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillSwaps_AspNetUsers_RequesterId",
                table: "SkillSwaps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SkillSwaps",
                table: "SkillSwaps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Posts",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notifications",
                table: "Notifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Likes",
                table: "Likes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DirectMessages",
                table: "DirectMessages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Connections",
                table: "Connections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Communities",
                table: "Communities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims");

            migrationBuilder.RenameTable(
                name: "SkillSwaps",
                newName: "TrocasConhecimento");

            migrationBuilder.RenameTable(
                name: "Posts",
                newName: "Publicacoes");

            migrationBuilder.RenameTable(
                name: "Notifications",
                newName: "Notificacoes");

            migrationBuilder.RenameTable(
                name: "Likes",
                newName: "Curtidas");

            migrationBuilder.RenameTable(
                name: "DirectMessages",
                newName: "MensagensDiretas");

            migrationBuilder.RenameTable(
                name: "Connections",
                newName: "Conexoes");

            migrationBuilder.RenameTable(
                name: "Communities",
                newName: "Comunidades");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "Comentarios");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                newName: "TokensUsuario");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "Usuarios");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "UsuariosFuncoes");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                newName: "LoginsUsuario");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                newName: "ReivindicacoesUsuario");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                newName: "Funcoes");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                newName: "ReivindicacoesFuncao");

            migrationBuilder.RenameIndex(
                name: "IX_SkillSwaps_RequesterId",
                table: "TrocasConhecimento",
                newName: "IX_TrocasConhecimento_RequesterId");

            migrationBuilder.RenameIndex(
                name: "IX_SkillSwaps_AddresseeId",
                table: "TrocasConhecimento",
                newName: "IX_TrocasConhecimento_AddresseeId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_UserId",
                table: "Publicacoes",
                newName: "IX_Publicacoes_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_CreatedAt",
                table: "Publicacoes",
                newName: "IX_Publicacoes_CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_CommunityId",
                table: "Publicacoes",
                newName: "IX_Publicacoes_CommunityId");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_UserId",
                table: "Notificacoes",
                newName: "IX_Notificacoes_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Likes_UserId",
                table: "Curtidas",
                newName: "IX_Curtidas_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Likes_PostId_UserId",
                table: "Curtidas",
                newName: "IX_Curtidas_PostId_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_DirectMessages_SenderId_ReceiverId",
                table: "MensagensDiretas",
                newName: "IX_MensagensDiretas_SenderId_ReceiverId");

            migrationBuilder.RenameIndex(
                name: "IX_DirectMessages_ReceiverId",
                table: "MensagensDiretas",
                newName: "IX_MensagensDiretas_ReceiverId");

            migrationBuilder.RenameIndex(
                name: "IX_Connections_RequesterId_AddresseeId",
                table: "Conexoes",
                newName: "IX_Conexoes_RequesterId_AddresseeId");

            migrationBuilder.RenameIndex(
                name: "IX_Connections_AddresseeId",
                table: "Conexoes",
                newName: "IX_Conexoes_AddresseeId");

            migrationBuilder.RenameIndex(
                name: "IX_Communities_Hashtag",
                table: "Comunidades",
                newName: "IX_Comunidades_Hashtag");

            migrationBuilder.RenameIndex(
                name: "IX_Communities_CreatedByUserId",
                table: "Comunidades",
                newName: "IX_Comunidades_CreatedByUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_UserId",
                table: "Comentarios",
                newName: "IX_Comentarios_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_PostId",
                table: "Comentarios",
                newName: "IX_Comentarios_PostId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_Email",
                table: "Usuarios",
                newName: "IX_Usuarios_Email");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "UsuariosFuncoes",
                newName: "IX_UsuariosFuncoes_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "LoginsUsuario",
                newName: "IX_LoginsUsuario_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "ReivindicacoesUsuario",
                newName: "IX_ReivindicacoesUsuario_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "ReivindicacoesFuncao",
                newName: "IX_ReivindicacoesFuncao_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrocasConhecimento",
                table: "TrocasConhecimento",
                column: "SkillSwapId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Publicacoes",
                table: "Publicacoes",
                column: "PostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notificacoes",
                table: "Notificacoes",
                column: "NotificationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Curtidas",
                table: "Curtidas",
                column: "LikeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MensagensDiretas",
                table: "MensagensDiretas",
                column: "MessageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Conexoes",
                table: "Conexoes",
                column: "ConnectionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comunidades",
                table: "Comunidades",
                column: "CommunityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comentarios",
                table: "Comentarios",
                column: "CommentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TokensUsuario",
                table: "TokensUsuario",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsuariosFuncoes",
                table: "UsuariosFuncoes",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoginsUsuario",
                table: "LoginsUsuario",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReivindicacoesUsuario",
                table: "ReivindicacoesUsuario",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Funcoes",
                table: "Funcoes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReivindicacoesFuncao",
                table: "ReivindicacoesFuncao",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Publicacoes_PostId",
                table: "Comentarios",
                column: "PostId",
                principalTable: "Publicacoes",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Usuarios_UserId",
                table: "Comentarios",
                column: "UserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comunidades_Usuarios_CreatedByUserId",
                table: "Comunidades",
                column: "CreatedByUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Conexoes_Usuarios_AddresseeId",
                table: "Conexoes",
                column: "AddresseeId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Conexoes_Usuarios_RequesterId",
                table: "Conexoes",
                column: "RequesterId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Curtidas_Publicacoes_PostId",
                table: "Curtidas",
                column: "PostId",
                principalTable: "Publicacoes",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Curtidas_Usuarios_UserId",
                table: "Curtidas",
                column: "UserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoginsUsuario_Usuarios_UserId",
                table: "LoginsUsuario",
                column: "UserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MensagensDiretas_Usuarios_ReceiverId",
                table: "MensagensDiretas",
                column: "ReceiverId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MensagensDiretas_Usuarios_SenderId",
                table: "MensagensDiretas",
                column: "SenderId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notificacoes_Usuarios_UserId",
                table: "Notificacoes",
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
                name: "FK_Publicacoes_Usuarios_UserId",
                table: "Publicacoes",
                column: "UserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
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

            migrationBuilder.AddForeignKey(
                name: "FK_TrocasConhecimento_Usuarios_AddresseeId",
                table: "TrocasConhecimento",
                column: "AddresseeId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrocasConhecimento_Usuarios_RequesterId",
                table: "TrocasConhecimento",
                column: "RequesterId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuariosFuncoes_Funcoes_RoleId",
                table: "UsuariosFuncoes",
                column: "RoleId",
                principalTable: "Funcoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuariosFuncoes_Usuarios_UserId",
                table: "UsuariosFuncoes",
                column: "UserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Publicacoes_PostId",
                table: "Comentarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Usuarios_UserId",
                table: "Comentarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Comunidades_Usuarios_CreatedByUserId",
                table: "Comunidades");

            migrationBuilder.DropForeignKey(
                name: "FK_Conexoes_Usuarios_AddresseeId",
                table: "Conexoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Conexoes_Usuarios_RequesterId",
                table: "Conexoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Curtidas_Publicacoes_PostId",
                table: "Curtidas");

            migrationBuilder.DropForeignKey(
                name: "FK_Curtidas_Usuarios_UserId",
                table: "Curtidas");

            migrationBuilder.DropForeignKey(
                name: "FK_LoginsUsuario_Usuarios_UserId",
                table: "LoginsUsuario");

            migrationBuilder.DropForeignKey(
                name: "FK_MensagensDiretas_Usuarios_ReceiverId",
                table: "MensagensDiretas");

            migrationBuilder.DropForeignKey(
                name: "FK_MensagensDiretas_Usuarios_SenderId",
                table: "MensagensDiretas");

            migrationBuilder.DropForeignKey(
                name: "FK_Notificacoes_Usuarios_UserId",
                table: "Notificacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Publicacoes_Comunidades_CommunityId",
                table: "Publicacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Publicacoes_Usuarios_UserId",
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

            migrationBuilder.DropForeignKey(
                name: "FK_TrocasConhecimento_Usuarios_AddresseeId",
                table: "TrocasConhecimento");

            migrationBuilder.DropForeignKey(
                name: "FK_TrocasConhecimento_Usuarios_RequesterId",
                table: "TrocasConhecimento");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuariosFuncoes_Funcoes_RoleId",
                table: "UsuariosFuncoes");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuariosFuncoes_Usuarios_UserId",
                table: "UsuariosFuncoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsuariosFuncoes",
                table: "UsuariosFuncoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrocasConhecimento",
                table: "TrocasConhecimento");

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
                name: "PK_Publicacoes",
                table: "Publicacoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notificacoes",
                table: "Notificacoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MensagensDiretas",
                table: "MensagensDiretas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoginsUsuario",
                table: "LoginsUsuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Funcoes",
                table: "Funcoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Curtidas",
                table: "Curtidas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Conexoes",
                table: "Conexoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comunidades",
                table: "Comunidades");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comentarios",
                table: "Comentarios");

            migrationBuilder.RenameTable(
                name: "UsuariosFuncoes",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "TrocasConhecimento",
                newName: "SkillSwaps");

            migrationBuilder.RenameTable(
                name: "TokensUsuario",
                newName: "AspNetUserTokens");

            migrationBuilder.RenameTable(
                name: "ReivindicacoesUsuario",
                newName: "AspNetUserClaims");

            migrationBuilder.RenameTable(
                name: "ReivindicacoesFuncao",
                newName: "AspNetRoleClaims");

            migrationBuilder.RenameTable(
                name: "Publicacoes",
                newName: "Posts");

            migrationBuilder.RenameTable(
                name: "Notificacoes",
                newName: "Notifications");

            migrationBuilder.RenameTable(
                name: "MensagensDiretas",
                newName: "DirectMessages");

            migrationBuilder.RenameTable(
                name: "LoginsUsuario",
                newName: "AspNetUserLogins");

            migrationBuilder.RenameTable(
                name: "Funcoes",
                newName: "AspNetRoles");

            migrationBuilder.RenameTable(
                name: "Curtidas",
                newName: "Likes");

            migrationBuilder.RenameTable(
                name: "Conexoes",
                newName: "Connections");

            migrationBuilder.RenameTable(
                name: "Comunidades",
                newName: "Communities");

            migrationBuilder.RenameTable(
                name: "Comentarios",
                newName: "Comments");

            migrationBuilder.RenameIndex(
                name: "IX_UsuariosFuncoes_RoleId",
                table: "AspNetUserRoles",
                newName: "IX_AspNetUserRoles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Usuarios_Email",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_Email");

            migrationBuilder.RenameIndex(
                name: "IX_TrocasConhecimento_RequesterId",
                table: "SkillSwaps",
                newName: "IX_SkillSwaps_RequesterId");

            migrationBuilder.RenameIndex(
                name: "IX_TrocasConhecimento_AddresseeId",
                table: "SkillSwaps",
                newName: "IX_SkillSwaps_AddresseeId");

            migrationBuilder.RenameIndex(
                name: "IX_ReivindicacoesUsuario_UserId",
                table: "AspNetUserClaims",
                newName: "IX_AspNetUserClaims_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ReivindicacoesFuncao_RoleId",
                table: "AspNetRoleClaims",
                newName: "IX_AspNetRoleClaims_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Publicacoes_UserId",
                table: "Posts",
                newName: "IX_Posts_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Publicacoes_CreatedAt",
                table: "Posts",
                newName: "IX_Posts_CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_Publicacoes_CommunityId",
                table: "Posts",
                newName: "IX_Posts_CommunityId");

            migrationBuilder.RenameIndex(
                name: "IX_Notificacoes_UserId",
                table: "Notifications",
                newName: "IX_Notifications_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_MensagensDiretas_SenderId_ReceiverId",
                table: "DirectMessages",
                newName: "IX_DirectMessages_SenderId_ReceiverId");

            migrationBuilder.RenameIndex(
                name: "IX_MensagensDiretas_ReceiverId",
                table: "DirectMessages",
                newName: "IX_DirectMessages_ReceiverId");

            migrationBuilder.RenameIndex(
                name: "IX_LoginsUsuario_UserId",
                table: "AspNetUserLogins",
                newName: "IX_AspNetUserLogins_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Curtidas_UserId",
                table: "Likes",
                newName: "IX_Likes_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Curtidas_PostId_UserId",
                table: "Likes",
                newName: "IX_Likes_PostId_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Conexoes_RequesterId_AddresseeId",
                table: "Connections",
                newName: "IX_Connections_RequesterId_AddresseeId");

            migrationBuilder.RenameIndex(
                name: "IX_Conexoes_AddresseeId",
                table: "Connections",
                newName: "IX_Connections_AddresseeId");

            migrationBuilder.RenameIndex(
                name: "IX_Comunidades_Hashtag",
                table: "Communities",
                newName: "IX_Communities_Hashtag");

            migrationBuilder.RenameIndex(
                name: "IX_Comunidades_CreatedByUserId",
                table: "Communities",
                newName: "IX_Communities_CreatedByUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Comentarios_UserId",
                table: "Comments",
                newName: "IX_Comments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Comentarios_PostId",
                table: "Comments",
                newName: "IX_Comments_PostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SkillSwaps",
                table: "SkillSwaps",
                column: "SkillSwapId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Posts",
                table: "Posts",
                column: "PostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notifications",
                table: "Notifications",
                column: "NotificationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DirectMessages",
                table: "DirectMessages",
                column: "MessageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Likes",
                table: "Likes",
                column: "LikeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Connections",
                table: "Connections",
                column: "ConnectionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Communities",
                table: "Communities",
                column: "CommunityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "CommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_PostId",
                table: "Comments",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Communities_AspNetUsers_CreatedByUserId",
                table: "Communities",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Connections_AspNetUsers_AddresseeId",
                table: "Connections",
                column: "AddresseeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Connections_AspNetUsers_RequesterId",
                table: "Connections",
                column: "RequesterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DirectMessages_AspNetUsers_ReceiverId",
                table: "DirectMessages",
                column: "ReceiverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DirectMessages_AspNetUsers_SenderId",
                table: "DirectMessages",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_AspNetUsers_UserId",
                table: "Likes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Posts_PostId",
                table: "Likes",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_AspNetUsers_UserId",
                table: "Notifications",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_UserId",
                table: "Posts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Communities_CommunityId",
                table: "Posts",
                column: "CommunityId",
                principalTable: "Communities",
                principalColumn: "CommunityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillSwaps_AspNetUsers_AddresseeId",
                table: "SkillSwaps",
                column: "AddresseeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillSwaps_AspNetUsers_RequesterId",
                table: "SkillSwaps",
                column: "RequesterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
