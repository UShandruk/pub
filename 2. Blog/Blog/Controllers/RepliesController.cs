using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Blog.Models;
using Blog.Services;

namespace Blog.Controllers
{
    public class RepliesController : Controller
    {
        private IRepliesDbService repliesDbService;

        // GET: /Replies/
        public ActionResult Index()
        {
            var replies = repliesDbService.ExtractReplies();
            return View(replies.ToList());
        }

        public RepliesController(IRepliesDbService repliesDbServiceParam)
        {
            repliesDbService = repliesDbServiceParam;
        }

        // GET: /Replies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reply reply = repliesDbService.FindReplyById(id);
            if (reply == null)
            {
                return HttpNotFound();
            }
            return View(reply);
        }

        // GET: /Replies/Create
        public ActionResult Create(int? id) //!!! Теперь Message.Id в переменной id. Дальше он пойдет во Views/Replies/Create !!!
        {
            ViewBag.MessageId = id;
            //ViewBag.MessageId = new SelectList(db.Messages, "Id", "Title");
            return View();
        }

        // POST: /Replies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Text,PublishDate,MessageId")] Reply reply, int MessId) //!!! Теперь Message.Id принимается в переменную MessId
        {
            if (ModelState.IsValid)
            {
                //TODO узнать нужно ли это, мб реплай уже приходит с мессагеид
                reply.MessageId = MessId;
                repliesDbService.AddReply(reply);
                return RedirectToAction("Index", "Messages");
            }
            //ViewBag.MessageId = MessId;
            //ViewBag.MessageId = new SelectList(db.Messages, "Id", "Title", reply.MessageId);
            return View(reply);
        }

        // GET: /Replies/Edit/5
        public ActionResult Edit(int? ReplyId)
        {
            if (ReplyId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reply reply = repliesDbService.FindReplyById(ReplyId);
            if (reply == null)
            {
                return HttpNotFound();
            }
            //ViewBag.MessageId = new SelectList(db.Messages, "Id", "Title", reply.MessageId);
            return View(reply);
        }

        // POST: /Replies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Text,PublishDate,MessageId")] Reply reply)
        {
            if (ModelState.IsValid)
            {                
                repliesDbService.ModifyReply(reply);
                return RedirectToAction("Index", "Messages");
            }
            //ViewBag.MessageId = new SelectList(db.Messages, "Id", "Title", reply.MessageId);
            return View(reply);
        }

        // GET: /Replies/Delete/5
        public ActionResult Delete(int? ReplyId)
        {
            //ViewBag.ReplyId = ReplyId;
            if (ReplyId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reply reply = repliesDbService.FindReplyById(ReplyId);
            if (reply == null)
            {
                return HttpNotFound();
            }
            return View(reply);
        }

        // POST: /Replies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int ReplyId) //2
        {
            Reply reply = repliesDbService.FindReplyById(ReplyId);
            return RedirectToAction("Index", "Messages");
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