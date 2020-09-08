using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

using System.Text;
using System;
using System.Web.Http;

namespace Anachronism
{
    public class Acronym
    {
        public string Abbreviation;

        public string FullForm;
    }

    public class Anachronism
    {
        private readonly IWordService _wordService;

        public Anachronism(IWordService wordService)
        {
            _wordService = wordService;
        }

        public Acronym MakeAcronym(string acronym)
        {
            var fullForm = new StringBuilder();

            foreach(var c in acronym)
            {
                var word = _wordService.GetWordBeginningWith(c);
                fullForm.Append($"{word} ");
            }

            return new Acronym {
                Abbreviation = acronym.ToUpper(),
                FullForm = fullForm.ToString().Trim()
            };
        }

        [FunctionName("Anachronism")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            try
            {
                string acronymInputString = req.Query["acronym"];
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                dynamic data = JsonConvert.DeserializeObject(requestBody);
                acronymInputString = acronymInputString ?? data?.acronym;

                if(string.IsNullOrEmpty(acronymInputString))
                {
                    return new OkObjectResult("Ok!");
                }

                log.LogInformation($"Generating acronym: {acronymInputString.ToUpper()}");

                var acronym = MakeAcronym(acronymInputString);
                return new JsonResult(acronym);
            }
            catch(Exception ex)
            {
                return new ExceptionResult(ex, true);
            }
        }
    }
}
