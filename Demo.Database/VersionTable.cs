using FluentMigrator.VersionTableInfo;

namespace Demo.Database
{
    [VersionTableMetaData]
    public class VersionTable : DefaultVersionTableMetaData
    {
        public override string TableName => "version";
    }
}
