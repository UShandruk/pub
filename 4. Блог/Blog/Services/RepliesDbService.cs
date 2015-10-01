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

namespace Blog.Services
{
    public class RepliesDbService
    {
        private ApplicationDbContext dbReplies = new ApplicationDbContext();
        //public RepliesDbService(ApplicationDbContext db) //Полный конструктор
        //{
        //    dbReplies = db;
        //}
        public IQueryable<Reply> ExtractReplies()
        {
            return dbReplies.Replies.Include(r => r.Message);
        }

        public Reply FindReplyById(int? id)
        {
            return dbReplies.Replies.Find(id);
        }

        public void AddReply(Reply reply)
        {
            dbReplies.Replies.Add(reply);
            dbReplies.SaveChanges();
        }

        public void ModifyReply(Reply reply)
        {
            dbReplies.Entry(reply).State = EntityState.Modified;
            dbReplies.SaveChanges();
        }

        public void RemoveRepliy(Reply reply)
        {
            dbReplies.Replies.Remove(reply);
            dbReplies.SaveChanges();
        }

        public void SaveChanges()
        {
            dbReplies.SaveChanges();
        }
    }
}