using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Blog.Models;
using System.Text.RegularExpressions;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PagedList;
using Blog.Services;

namespace Blog.Controllers
{
    public class MessagesController : Controller
    {
      
        UserManager<ApplicationUser> userManager;

        IMessagesDbService messagesDbService = new MessagesDbService();

        public MessagesController()
        {
            userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>());
        }

        // GET: /Messages/
        public ActionResult Index(int? NumberOfPage)
        {
            int pageSize = 6;
            int pageNumber = (NumberOfPage ?? 1);
            var messages = messagesDbService.ExtractMessages().ToPagedList(pageNumber, pageSize);
            return View(messages);
        }

        // GET: /Messages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = messagesDbService.FindMessageById(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // GET: /Messages/Create
        [Authorize(Roles="admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Messages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Title,Text,PublishDate")] Message message)
        {
            Regex regex = new Regex("[A-Я]+[A-Я]+");
            if (regex.IsMatch(message.Title))
            {
                ModelState.AddModelError("", "Заголовок не должен начинаться с двух или более заглавных букв подряд или включать в себя латинские буквы.");
                return View(message);
            } 
            
            if (ModelState.IsValid)
            {
                message.User = userManager.FindByName(this.User.Identity.Name);
                messagesDbService.AddMessage(message);
                return RedirectToAction("Index");
            }

            return View(message);
        }

        // GET: /Messages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (!User.IsInRole("admin"))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = messagesDbService.FindMessageById(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // POST: /Messages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Title,Text,PublishDate")] Message message)
        {
            if (ModelState.IsValid)
            {
                messagesDbService.ModifyMessage(message);
                return RedirectToAction("Index");
            }
            return View(message);
        }

        // GET: /Messages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = messagesDbService.FindMessageById(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // POST: /Messages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            messagesDbService.RemoveMessage(id);
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}