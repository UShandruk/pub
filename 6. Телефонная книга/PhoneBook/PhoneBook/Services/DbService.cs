using PhoneBook.DAL;
using PhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneBook.Services
{
    public class DbService
    {
        private PhoneBookDataContext db = new PhoneBookDataContext();

        public List<RecordViewModel> Search(string searching)
        {
           return db.Records.Where(x => x.Name.Contains(searching) || x.Surname.Contains(searching) || x.Phone.Contains(searching)).Select(x => new RecordViewModel { Id = x.Id, Name = x.Name, Surname = x.Surname, Phone = x.Phone }).ToList();
        }

        public List<RecordViewModel> ShowRecords()
        {
            return db.Records.Select(x => new RecordViewModel { Id = x.Id, Name = x.Name, Surname = x.Surname, Phone = x.Phone }).ToList();
        }

        public void Add(RecordViewModel record)
        {
            var recordToEdit = db.Records.FirstOrDefault(r => r.Id == record.Id);
            if (record.Id == 0)
            {
                db.Records.InsertOnSubmit(new Record { Surname = record.Surname, Name = record.Name, Phone = record.Phone });
            }
            
            else
            {
                recordToEdit.Surname = record.Surname;
                recordToEdit.Name = record.Name;
                recordToEdit.Phone = record.Phone;
            }
            db.SubmitChanges();
        }

        public Record Get(int? Id)
        {
            var result = db.Records.FirstOrDefault(r => r.Id == Id);
            return result;
            //if (result == null)
            //    return null;
            //else {
            //    return new RecordViewModel { Id = recordToEdit.Id, Name = recordToEdit.Name, Surname = recordToEdit.Surname, Phone = recordToEdit.Phone } 
                //new RecordViewModel { Id = recordToEdit.Id, Name = recordToEdit.Name, Surname = recordToEdit.Surname, Phone = recordToEdit.Phone }
            //}
                
        }
        public List<Record> GetAll()
        {
            return db.Records.ToList();
        }

        //public void Submit()
        //{
        //    db.SubmitChanges();
        //}

        public void Delete(int? Id)
        {
            var recordToDelete = db.Records.FirstOrDefault(r => r.Id == Id);
            if (recordToDelete == null)
                return;
            
            db.Records.DeleteOnSubmit(recordToDelete);
            db.SubmitChanges();
        }
    }
}