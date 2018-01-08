namespace Demo.Database
{
    public class DatabaseSchema
    {
        public const string TableUser = "identity_user";

        public const string ColumnId = "Id";
        public const string ColumnAccessFailedCount = "AccessFailedCount";
        public const string ColumnConcurrencyStamp = "ConcurrencyStamp";
        public const string ColumnEmail = "Email";
        public const string ColumnEmailConfirmed = "EmailConfirmed";
        public const string ColumnLockoutEnabled = "LockoutEnabled";
        public const string ColumnLockoutEnd = "LockoutEnd";
        public const string ColumnNormalizedEmail = "NormalizedEmail";
        public const string ColumnNormalizedUserName = "NormalizedUserName";
        public const string ColumnPasswordHash = "PasswordHash";
        public const string ColumnPhoneNumber = "PhoneNumber";
        public const string ColumnPhoneNumberConfirmed = "PhoneNumberConfirmed";
        public const string ColumnSecurityStamp = "SecurityStamp";
        public const string ColumnTwoFactorEnabled = "TwoFactorEnabled";
        public const string ColumnUserName = "UserName";

        public const string ConstrainUniqueEmail = "Unique_User_Email";
        public const string ConstrainUniqueUserName = "Unique_User_UserName";

        public const int ColumnDefaultLength = 100;
        public const int ColumnUserNameLength = ColumnDefaultLength;
        public const int ColumnEmailLength = ColumnDefaultLength;
    }
}
