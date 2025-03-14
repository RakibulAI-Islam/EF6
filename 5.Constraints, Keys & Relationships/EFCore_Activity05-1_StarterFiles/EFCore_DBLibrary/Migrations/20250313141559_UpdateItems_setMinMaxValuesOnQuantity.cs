using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore_DBLibrary.Migrations
{
    public partial class UpdateItems_setMinMaxValuesOnQuantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE Items SET Quantity = 0 WHERE Quantity < 0");
            migrationBuilder.Sql("UPDATE Items SET Quantity = 1000 WHERE Quantity > 1000");
            
            migrationBuilder.Sql(@"IF NOT EXISTS(SELECT * 
                FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
                WHERE CONSTRAINT_NAME='CK_Items_Quantity_Minimum')  
                BEGIN
                    ALTER TABLE [dbo].[Items] ADD CONSTRAINT CK_Items_Quantity_Minimum CHECK (Quantity >= 0)
                END

                IF NOT EXISTS(SELECT * 
                    FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
                    WHERE CONSTRAINT_NAME='CK_Items_Quantity_Maximum')  
                BEGIN
                    ALTER TABLE [dbo].[Items] ADD CONSTRAINT CK_Items_Quantity_Maximum CHECK (Quantity <= 1000)
                END");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"IF EXISTS(SELECT * 
                    FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
                    WHERE CONSTRAINT_NAME='CK_Items_Quantity_Minimum')  
                BEGIN
                    ALTER TABLE [dbo].[Items] DROP CONSTRAINT CK_Items_Quantity_Minimum
                END");

            migrationBuilder.Sql(@"IF NOT EXISTS(SELECT * 
                    FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
                    WHERE CONSTRAINT_NAME='CK_Items_Quantity_Maximum')  
                BEGIN
                    ALTER TABLE [dbo].[Items] DROP CONSTRAINT CK_Items_Quantity_Maximum
                END");

        }
    }
}
