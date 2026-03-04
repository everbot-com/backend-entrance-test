using System;
using System.Net;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Everbot.OnlineInterview.Migrations
{
    /// <inheritdoc />
    public partial class CreateTable_Samples : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "samples",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, comment: "主鍵"),
                    name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    date_time_with_out_time_zone = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    date_time_with_time_zone = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    sample_type = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    ip_address = table.Column<IPAddress>(type: "inet", nullable: true),
                    extra_properties = table.Column<string>(type: "text", nullable: false, comment: "擴充屬性"),
                    concurrency_stamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false, comment: "併發戳記"),
                    creation_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, comment: "建立時間"),
                    creator_id = table.Column<Guid>(type: "uuid", nullable: true, comment: "建立者 ID"),
                    last_modification_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, comment: "最後修改時間"),
                    last_modifier_id = table.Column<Guid>(type: "uuid", nullable: true, comment: "最後修改者 ID"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false, comment: "是否已刪除"),
                    deleter_id = table.Column<Guid>(type: "uuid", nullable: true, comment: "刪除者 ID"),
                    deletion_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, comment: "刪除時間")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_samples", x => x.id);
                    table.CheckConstraint("CK_samples_sample_type_Enum", "sample_type IN ('Type1', 'Type2')");
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "samples");
        }
    }
}
