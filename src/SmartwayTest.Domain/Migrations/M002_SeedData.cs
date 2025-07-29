using FluentMigrator;

namespace SmartwayTest.Domain.Migrations;

[Migration(version: 2)]
public class M002_SeedData : Migration
{
    public override void Up()
    {
        Insert.IntoTable("companies")
            .Row(new { name = "Smartway" })
            .Row(new { name = "ZenCode" });

        Insert.IntoTable("departments")
            .Row(new { name = "IT", phone = "+7 (900) 123-33-11", company_id = 1 })
            .Row(new { name = "HR", phone = "+7 (999) 888-77-12", company_id = 2 })
            .Row(new { name = "Support", phone = "+7 (900) 100-32-43", company_id = 1 });

        Insert.IntoTable("passports")
            .Row(new { type = "7482", number = "123674" })
            .Row(new { type = "5356", number = "399184" })
            .Row(new { type = "5478", number = "539528" })
            .Row(new { type = "3424", number = "173950" });
        
        Insert.IntoTable("employees")
            .Row(new { name = "Александр", surname = "Иванов", phone = "+7 (900) 123-45-61", passport_id = 1, company_id = 1, department_id = 1 })
            .Row(new { name = "Мария", surname = "Смирнова", phone = "+7 (900) 234-56-72", passport_id = 2, company_id = 2, department_id = 2 })
            .Row(new { name = "Екатерина", surname = "Попова", phone = "+7 (900) 456-78-94", passport_id = 4, company_id = 2, department_id = 2 })
            .Row(new { name = "Дмитрий", surname = "Кузнецов", phone = "+7 (900) 345-67-83", passport_id = 3, company_id = 1, department_id = 3 });
    }

    public override void Down()
    {
        Delete.FromTable("employees").AllRows();
        Delete.FromTable("departments").AllRows();
        Delete.FromTable("passports").AllRows();
        Delete.FromTable("companies").AllRows();
    }
}
