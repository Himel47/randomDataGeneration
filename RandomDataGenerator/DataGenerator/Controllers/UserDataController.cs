using CsvHelper;
using DataGenerator.Models;
using DataGenerator.Operations;
using Microsoft.AspNetCore.Mvc;

namespace DataGenerator.Controllers
{
    public class UserDataController : Controller
    {
        private DataOperations _operations;

        public UserDataController()
        {
            _operations = new DataOperations(ERegion.Poland,0);
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GenerateUserData(ERegion region, int errorsPerRecord, int seed, int pageNumber)
        {
            _operations = new DataOperations(region, seed);
            var userDataList = _operations.GenerateUserData(pageNumber, errorsPerRecord, 20); // 20 records per page
            return PartialView("_UserDataTable", userDataList);
        }

        public ActionResult ExportToCsv(int pageNumber)
        {
            var userDataList = _operations.GenerateUserData(pageNumber, 0, 20); // 20 records per page
            var csvFormatter = new CsvFormatter();
            var csvData = csvFormatter.Format(userDataList);
            return File(csvData, "text/csv", "user_data.csv");
        }
    }
}
