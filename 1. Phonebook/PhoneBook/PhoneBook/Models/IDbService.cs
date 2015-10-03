using PhoneBook.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Models
{
    public interface IDbService
    {
        List<RecordViewModel> Search(string searching);

        List<RecordViewModel> ShowRecords();

        void Add(RecordViewModel record);

        Record Get(int? Id);

        List<Record> GetAll();

        void Delete(int? Id);
    }
}
