using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SoloduhaMVC.Models.Content
{
    public class ContentDbInitializer: CreateDatabaseIfNotExists<ContentDbContext>
    {
        protected override void Seed(ContentDbContext context)
        {
            Content c = new Content { Information = "<h1>Hello!</h1>", Pagename = "main" };

            context.Contents.Add(c);
            context.SaveChanges();

            base.Seed(context);
        }
    }
}