using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System.Diagnostics;
using testQRcode.Models;
using static QRCoder.PayloadGenerator;

namespace testQRcode.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(new ErrorViewModel());
        }

        [HttpPost]
        public IActionResult Index(ErrorViewModel model)
        {
            Payload payload = new Url(model.WebSiteURLText);
            QRCodeGenerator codeGenerator = new QRCodeGenerator();
            QRCodeData qRCodeData = codeGenerator.CreateQrCode(payload);
            QRCoder.PngByteQRCode pngByteQRCode = new PngByteQRCode(qRCodeData);

            var qrAsByte = pngByteQRCode.GetGraphic(20);

            string base64String = Convert.ToBase64String(qrAsByte);
            model.QRImageURL = "data:image/png;base64," + base64String;

            return View("Index", model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
