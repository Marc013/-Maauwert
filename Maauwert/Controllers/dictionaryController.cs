using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Formats.Asn1;
using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;

namespace Maauwert.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class dictionaryController : ControllerBase
    {
        [HttpGet]
        public string[] getWord()
        {
            // string[] words = { "word1", "word2", "word3" }; //get information from CSV
            //var data = system.io.file.readalltext("data/tilburgswoordenboek.csv");
            //var words = data.Split(';') ;

            using (var reader = new StreamReader("data/tilburgswoordenboek.csv"))
            {
                var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = ";"
                };

                using (var csv = new CsvReader(reader, csvConfig))
                {
                    var records = csv.GetRecords<dynamic>().ToList();
                }
            }
            string[] words = { "test1", "test2" };

            return words;
        }
    }

    //public class woordenBoek
    //{
    //    public string? Nederlands { get; set; }
    //    public string? Tilburgs { get; set; }
    //}
}
