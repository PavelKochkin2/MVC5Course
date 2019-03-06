namespace VidlyReborn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Populate_Genre_Table : DbMigration
    {
        public override void Up()
        {
            Sql("insert into Genres (Name) values ('Action')");
            Sql("insert into Genres (Name) values ('Horror')");
            Sql("insert into Genres (Name) values ('Porn')");
            Sql("insert into Genres (Name) values ('Drama')");
            Sql("insert into Genres (Name) values ('Comedy')");
        }
        
        public override void Down()
        {
        }
    }
}
