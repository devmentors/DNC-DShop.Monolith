using System;
using System.Linq;
using System.Threading.Tasks;
using DShop.Monolith.Api.Framework;
using DShop.Monolith.Services.Dispatchers;
using DShop.Monolith.Core.Types;
using Microsoft.AspNetCore.Mvc;
using DShop.Monolith.Services;

namespace DShop.Monolith.Api.Controllers
{
    [Route("[controller]")]
    [Auth]
    public abstract class BaseController : Controller
    {
        private static readonly string AcceptLanguageHeader = "accept-language";
        private static readonly string DefaultCulture = "en-us";
        private static readonly string PageLink = "page";
        private readonly ICommandDispatcher _commandDispatcher;

        public BaseController(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        protected IActionResult Single<T>(T model, Func<T,bool> criteria = null)
        {
            if (model == null)
            {
                return NotFound();
            }
            var isValid = criteria == null || criteria(model);
            if (isValid)
            {
                return Ok(model);
            }

            return NotFound();
        }

        protected IActionResult Collection<T>(IPagedResult<T> pagedResult, Func<IPagedResult<T>,bool> criteria = null)
        {
            if (pagedResult == null)
            {
                return NotFound();
            }
            var isValid = criteria == null || criteria(pagedResult);
            if (!isValid)
            {
                return NotFound();
            }
            if (pagedResult.IsEmpty)
            {
                return Ok(Enumerable.Empty<T>());
            }
            Response.Headers.Add("link", GetLinkHeader(pagedResult));
            Response.Headers.Add("x-total-count", pagedResult.TotalResults.ToString());

            return Ok(pagedResult.Items);
        }

        protected async Task<IActionResult> DispatchAsync<T>(T command, 
            Guid? resourceId = null, string resource = "") where T : ICommand 
        {
            await _commandDispatcher.DispatchAsync(command);

            return Ok();
        }

        protected bool IsAdmin
            => User.IsInRole("admin");

        protected Guid UserId
            => string.IsNullOrWhiteSpace(User?.Identity?.Name) ? 
                Guid.Empty : 
                Guid.Parse(User.Identity.Name);

        protected string Culture 
            => Request.Headers.ContainsKey(AcceptLanguageHeader) ? 
                    Request.Headers[AcceptLanguageHeader].First().ToLowerInvariant() :
                    DefaultCulture;

        private string GetLinkHeader(IPagedResult result)
        {
            var first = GetPageLink(result.CurrentPage, 1);
            var last = GetPageLink(result.CurrentPage, result.TotalPages);
            var prev = string.Empty;
            var next = string.Empty;
            if (result.CurrentPage > 1 && result.CurrentPage <= result.TotalPages)
            {
                prev = GetPageLink(result.CurrentPage, result.CurrentPage - 1);
            }
            if (result.CurrentPage < result.TotalPages)
            {
                next = GetPageLink(result.CurrentPage, result.CurrentPage + 1);
            }

            return $"{FormatLink(next, "next")}{FormatLink(last, "last")}" +
                   $"{FormatLink(first, "first")}{FormatLink(prev, "prev")}";
        }

        private string GetPageLink(int currentPage, int page)
        {
            var path = Request.Path.HasValue ? Request.Path.ToString() : string.Empty;
            var queryString = Request.QueryString.HasValue ?  Request.QueryString.ToString() : string.Empty;
            var conjunction = string.IsNullOrWhiteSpace(queryString) ? "?" : "&";
            var fullPath = $"{path}{queryString}";
            var pageArg = $"{PageLink}={page}";
            var link = fullPath.Contains($"{PageLink}=")
                ? fullPath.Replace($"{PageLink}={currentPage}", pageArg)
                : fullPath += $"{conjunction}{pageArg}";

            return link;
        }

        private static string FormatLink(string path, string rel)
            => string.IsNullOrWhiteSpace(path) ? string.Empty : $"<{path}>; rel=\"{rel}\",";
    }
}