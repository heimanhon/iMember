using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Http;
using Microsoft.WindowsAzure.Mobile.Service;
using csdataserviceService.DataObjects;
using csdataserviceService.Models;

namespace csdataserviceService
{
    public static class WebApiConfig
    {
        public static void Register()
        {
            // Use this class to set configuration options for your mobile service
            ConfigOptions options = new ConfigOptions();

            // Use this class to set WebAPI configuration options
            HttpConfiguration config = ServiceConfig.Initialize(new ConfigBuilder(options));

            // To display errors in the browser during development, uncomment the following
            // line. Comment it out again when you deploy your service for production use.
            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
            
            Database.SetInitializer(new csdataserviceInitializer());
            //var migrator = new DbMigrator(new Configuration());
            //migrator.Update();
        }
    }

    // or use ClearDatabaseSchemaAlways if you want to seed every time.
    public class csdataserviceInitializer : ClearDatabaseSchemaIfModelChanges<csdataserviceContext>
    {
        protected override void Seed(csdataserviceContext context)
        {
            List<Member> memberList = new List<Member>
            {
                new Member { Id = Guid.NewGuid().ToString(), UserName = "DanielYuen", Store = "Langham", MemberId = "66420436", MemberName = "Daniel", MemberExpiry = new DateTime(2016,01,01) },               
                new Member { Id = Guid.NewGuid().ToString(), UserName = "Magstar", Store = "IT", MemberId = "90982385", MemberName = "Maggie", MemberExpiry = new DateTime(2016,04,01) },               
            };

            foreach (Member member in memberList)
            {
                context.Set<Member>().Add(member);
            }


            //List<TodoItem> todoItems = new List<TodoItem>
            //{
            //    new TodoItem { Id = Guid.NewGuid().ToString(), Text = "First item", Complete = false },
            //    new TodoItem { Id = Guid.NewGuid().ToString(), Text = "Second item", Complete = false },
            //    new TodoItem { Id = Guid.NewGuid().ToString(), Text = "hello world!", Complete = false },
            //    new TodoItem { Id = Guid.NewGuid().ToString(), Text = "hello daniel haha", Complete = false },
            //};

            //foreach (TodoItem todoItem in todoItems)
            //{
            //    context.Set<TodoItem>().Add(todoItem);
            //}

            base.Seed(context);
        }
    }
}

