using FluentMigrator;

namespace SmartwayTest.Domain.Migrations;

[Migration(version: 1)]
public class M001_Initial : Migration
{
    public override void Up()
    {
        Create.Table("companies")
            .WithColumn("id").AsInt32().PrimaryKey().Identity()
            .WithColumn("name").AsString().NotNullable();

        Create.Table("passports")
            .WithColumn("id").AsInt32().PrimaryKey().Identity()
            .WithColumn("type").AsString(4).NotNullable()
            .WithColumn("number").AsString(6).NotNullable();

        Create.Table("departments")
            .WithColumn("id").AsInt32().PrimaryKey().Identity()
            .WithColumn("name").AsString().NotNullable()
            .WithColumn("phone").AsString(18).NotNullable()
            .WithColumn("company_id").AsInt32().Nullable()
            .ForeignKey("fk_departments_company_id", "companies", "id");

        Create.Table("employees")
            .WithColumn("id").AsInt32().PrimaryKey().Identity()
            .WithColumn("name").AsString().NotNullable()
            .WithColumn("surname").AsString().NotNullable()
            .WithColumn("phone").AsString(18).NotNullable()
            .WithColumn("company_id").AsInt32().Nullable()
            .ForeignKey("fk_employees_company_id", "companies", "id")
            .WithColumn("passport_id").AsInt32().Nullable()
            .ForeignKey("fk_employees_passport_id", "passports", "id")
            .WithColumn("department_id").AsInt32().Nullable()
            .ForeignKey("fk_employees_department_id", "departments", "id");
    }
    public override void Down()
    {
        Delete.Table("employees");
        Delete.Table("departments");
        Delete.Table("passports");
        Delete.Table("companies");
    }
}
