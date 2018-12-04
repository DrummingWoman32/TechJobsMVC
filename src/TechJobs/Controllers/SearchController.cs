using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results

            //need two parameters: type of search, search term
        public IActionResult Results(string searchType, string searchTerm)
        {
            //look up search results via the JobData class, then
            //pass them into Views/Search/Index.cshtml view (which is not
            //the default view for this action)

            //making this to put in the job results 
            List<Dictionary<string, string>> jobs = new List<Dictionary<string, string>>();

            //if the user doesn't search all, we use FindByColumnAndValue
            if(!searchType.Equals("all"))
            {
                jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
            }

            //else we use FindByValue to search all columns for one term
            else
            {
                jobs = JobData.FindByValue(searchTerm);
            }

            ViewBag.columns = ListController.columnChoices;
            ViewBag.jobs = jobs;
            //pass results into Views/Search/Index.cshtml
            return View("Index");
           
            
        }
    }
}
