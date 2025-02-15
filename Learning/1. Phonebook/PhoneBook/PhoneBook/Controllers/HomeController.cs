﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using OfficeOpenXml;
using PhoneBook.DAL;
using PhoneBook.Models;
using PhoneBook.Services;

namespace PhoneBook.Controllers
{
    public class HomeController : Controller
    {
        private IDbService dbService;
        
        public HomeController(IDbService dbServiceParam)
        {
            dbService = dbServiceParam;
        }

        public ActionResult Index(string searching = null) //Список телефонов
        {
            List<RecordViewModel> model = null;

            if (searching != null)
            {
                model = dbService.Search(searching);
                return View(model);
            }
            else
            {
                model = dbService.ShowRecords();
                return View(model);
            }
        }

        public ViewResult Add()
        {
            return View(new RecordViewModel());
        }

        [HttpPost]
        public ActionResult FormAdd(RecordViewModel record)
        {
            dbService.Add(record);
            return RedirectToAction("Index");
        }

        public ActionResult Remove(int? Id)
        {
            dbService.Delete(Id);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? Id)
        {
            var recordToEdit = dbService.Get(Id);
            if (recordToEdit == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                var result = new RecordViewModel { Id = recordToEdit.Id, Name = recordToEdit.Name, Surname = recordToEdit.Surname, Phone = recordToEdit.Phone };
                return View("Add", result);
            }
        }

        public void ExportToExcel()
        {
            List<Record> Records = dbService.GetAll();

            using (var stream = new MemoryStream())
            {
                Response.ClearContent();
                Response.AddHeader("content-disposition", "attachment; filename=PhoneBook.xlsx");

                ExcelPackage package = new ExcelPackage(stream);
                ExcelWorkbook workbook = package.Workbook;
                ExcelWorksheet sheet = workbook.Worksheets.Add("SheetA");

                sheet.Cells[1, 1].Value = "Фамилия";
                sheet.Cells["b1"].Value = "Имя";
                sheet.Cells["c1"].Value = "Телефон";

                int row = 2;

                foreach (Record record in Records)
                {
                    sheet.Cells[row, 1].Value = record.Surname;
                    sheet.Cells[row, 2].Value = record.Name;
                    sheet.Cells[row, 3].Value = record.Phone;
                    row++;
                }

                sheet.Cells[1, 1, 1, 3].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                sheet.Cells[1, 1, 1, 3].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);

                sheet.Cells["a1:b10"].AutoFitColumns();

                sheet.View.FreezePanes(2, 1);

                package.Save();

                stream.WriteTo(Response.OutputStream);

                Response.End();
            };            
       }

    }
}