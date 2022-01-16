using System;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;

namespace Almostengr.GardenMgr.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        internal readonly HttpClient _httpClient;

        public BaseController(HttpClient httpClient, AppSettings appSettings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(appSettings.ApiUrl);
        }
    }
}