using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WhoisCheck.Models;

namespace WhoisCheck.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult TldServerList()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult CheckDomain(DomainViewModels model)
        {
            string whoisText = null;
            var tldServer = Whois.GetWhoisServerName(model.DomainName);

            if (tldServer != null) { whoisText = Whois.GetWhoisInformation(tldServer, model.DomainName); }
            else { whoisText = Whois.GetWhoisInformation("whois.verisign-grs.com", model.DomainName + ".com"); }

            whoisText = whoisText.Replace("\r\n", "<br/>");
            model.DomainDetails = whoisText;
            return View("Index", model);
        }
    }
}