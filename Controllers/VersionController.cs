using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ISWebApp.Models;
using Serilog;

namespace ISWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VersionController : ControllerBase
    {
       
        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {   Log.Information("Acquiring version info");
            Log.Warning("Some warning");
            Log.Error("Here comes an error");
           var versionInfo = new VersionModel
            {
                Company = Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyCompanyAttribute>().Company,

                Product = Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyProductAttribute>().Product,

                ProductVersion = Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion

            };
            
            Log.Information($"Acquired version is {versionInfo.ProductVersion}");
            Log.Debug($"Full version info: {@versionInfo}");
            return Ok(versionInfo);
        }
    } 
}

