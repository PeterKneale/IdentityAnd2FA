using FluentMigrator;

namespace Demo.Database.Migrations
{
    [Migration(1, "Add identity")]
    public class Migration1 : Migration
    {
        public override void Up()
        {
            Create.Table(DatabaseSchema.TableUser)
                .WithColumn(DatabaseSchema.ColumnId)
                    .AsGuid()
                    .PrimaryKey()
                    .NotNullable()

                // Email
                .WithColumn(DatabaseSchema.ColumnEmail)
                    .AsString(DatabaseSchema.ColumnEmailLength)
                    .NotNullable()
                .WithColumn(DatabaseSchema.ColumnEmailConfirmed)
                    .AsBoolean()
                    .NotNullable()
                    .WithDefaultValue(false)
                .WithColumn(DatabaseSchema.ColumnNormalizedEmail)
                    .AsString(DatabaseSchema.ColumnEmailLength)
                    .NotNullable()

                // UserName
                .WithColumn(DatabaseSchema.ColumnUserName)
                    .AsString(DatabaseSchema.ColumnUserNameLength)
                    .NotNullable()
                .WithColumn(DatabaseSchema.ColumnNormalizedUserName)
                    .AsString(DatabaseSchema.ColumnUserNameLength)
                    .NotNullable()

                // Phone
                .WithColumn(DatabaseSchema.ColumnPhoneNumber)
                    .AsString(DatabaseSchema.ColumnDefaultLength)
                    .Nullable()
                .WithColumn(DatabaseSchema.ColumnPhoneNumberConfirmed)
                    .AsBoolean()
                    .NotNullable()
                    .WithDefaultValue(false)
                .WithColumn(DatabaseSchema.ColumnTwoFactorEnabled)
                    .AsBoolean()
                    .NotNullable()
                    .WithDefaultValue(false)

                // Password
                .WithColumn(DatabaseSchema.ColumnPasswordHash)
                    .AsString(DatabaseSchema.ColumnDefaultLength)
                    .NotNullable()

                // Lockout
                .WithColumn(DatabaseSchema.ColumnAccessFailedCount)
                    .AsInt16()
                    .NotNullable()
                    .WithDefaultValue(0)
                .WithColumn(DatabaseSchema.ColumnLockoutEnabled)
                    .AsBoolean()
                    .NotNullable()
                    .WithDefaultValue(false)
                .WithColumn(DatabaseSchema.ColumnLockoutEnd)
                    .AsDateTimeOffset()
                    .Nullable()

                // Other
                .WithColumn(DatabaseSchema.ColumnConcurrencyStamp)
                    .AsString(DatabaseSchema.ColumnDefaultLength)
                    .Nullable()
                .WithColumn(DatabaseSchema.ColumnSecurityStamp)
                    .AsString(DatabaseSchema.ColumnDefaultLength)
                    .Nullable();

            Create.UniqueConstraint(DatabaseSchema.ConstrainUniqueEmail)
              .OnTable(DatabaseSchema.TableUser)
              .Columns(DatabaseSchema.ColumnEmail);

            Create.UniqueConstraint(DatabaseSchema.ConstrainUniqueUserName)
              .OnTable(DatabaseSchema.TableUser)
              .Columns(DatabaseSchema.ColumnUserName);
        }

        public override void Down()
        {
            Delete.Table(DatabaseSchema.TableUser);
        }

    }
}