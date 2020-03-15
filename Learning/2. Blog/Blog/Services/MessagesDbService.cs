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
    public class MessagesDbService : IMessagesDbService
    {
        private ApplicationDbContext dbMessages = new ApplicationDbContext();

        public IOrderedQueryable<Message> ExtractMessages()
        {
            return dbMessages.Messages.Include(x => x.Replies).OrderByDescending(x => x.PublishDate);
        }

        public Message FindMessageById(int? id)
        {
            return dbMessages.Messages.Find(id);
        }

        public void AddMessage(Message message)
        {
            dbMessages.Messages.Add(message);
            dbMessages.SaveChanges();
        }

        public void ModifyMessage(Message message)
        {
            dbMessages.Entry(message).State = EntityState.Modified;
            dbMessages.SaveChanges();
        }

        public void RemoveMessage(int Id)
        {
            Message message = FindMessageById(Id);
            dbMessages.Messages.Remove(message);
            dbMessages.SaveChanges();
        }

        public void SaveChanges()
        {
            dbMessages.SaveChanges();
        }
    }
}