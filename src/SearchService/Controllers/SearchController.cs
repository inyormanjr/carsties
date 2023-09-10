using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Entities;
using SearchService.Models;

namespace SearchService.Controllers
{
    [Route("[controller]")]
    [Route("api/search")]
    public class SearchController : ControllerBase
    {
        private readonly ILogger<SearchController> _logger;

        public SearchController(ILogger<SearchController> logger)
        {
            _logger = logger;
        }

        // GET /search
        [HttpGet]
        public async Task<ActionResult<List<Item>>> SearchItems(string SearchTerm, int pageNumber = 1, int pageSize = 4)
        {
            //with pagination
            var query = DB.PagedSearch<Item>();
            query.Sort(x => x.Ascending(y => y.Make));

            if(!string.IsNullOrEmpty(SearchTerm))
            {
                query.Match(Search.Full,SearchTerm).SortByTextScore();
            }

            query.PageNumber(pageNumber);
            query.PageSize(pageSize);
            var result = await query.ExecuteAsync();
            return Ok(new {
                results = result.Results,
                pageCount = result.PageCount,
                totalCount = result.TotalCount
            });
        }
    }
}