using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blog.Models;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Text;
using Microsoft.AspNet.Identity.EntityFramework;


namespace Blog.DAL
{
    public class DbInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            //Создание пользователя Admin
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            ApplicationUser user = new ApplicationUser()
            {
                UserName = "Admin",
                Id = "Admin"
            };
            IdentityRole role = new IdentityRole("admin");

            userManager.Create(user, "password");
            roleManager.Create(role);
            userManager.AddToRole(user.Id, role.Name);

            //Сообщения и ответы
            List<Message> messages = new List<Message>(); //Создаем 10 сообщений
            for (int i=0; i<10; i++)
            {
                Message message = new Message()
                {
                    PublishDate = DateTime.Now,
                    Title = "Заголовок новости" + i,
                    Text = "Текст сообщения" + i
                };
                context.Messages.Add(message); //см. Models/IdentityModels.cs

                if (i>4&&i<12)
                {
                    Reply reply = new Reply()
                    {
                        Message = message,
                        Text = "Текст комментария" + i,
                        PublishDate = DateTime.Now
                    };
                    context.Replies.Add(reply);
                }
            }
            context.SaveChanges(); //сохранение всех изменений, произошедших за одну транзакцию
            //base.Seed(context);
        }
    }
}