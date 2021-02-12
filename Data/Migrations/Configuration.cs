namespace Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using Core;
    using Data;

    internal sealed class Configuration : DbMigrationsConfiguration<ToDoDotNet.Data.ToDoDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ToDoDotNet.Data.ToDoDbContext context)
        {
            var lorem = new Bogus.DataSets.Lorem();
            var dates = new Bogus.DataSets.Date();
            context.ToDos.AddOrUpdate(x => x.Id,
                new ToDo() { Title = lorem.Word(), Body = lorem.Sentences(), CreationDate = dates.Soon() },
                new ToDo() { Title = lorem.Word(), Body = lorem.Sentences(), CreationDate = dates.Soon() },
                new ToDo() { Title = lorem.Word(), Body = lorem.Sentences(), CreationDate = dates.Soon() },
                new ToDo() { Title = lorem.Word(), Body = lorem.Sentences(), CreationDate = dates.Soon() },
                new ToDo() { Title = lorem.Word(), Body = lorem.Sentences(), CreationDate = dates.Soon() }
        );
        }
    }
}
