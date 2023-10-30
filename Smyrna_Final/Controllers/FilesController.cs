using Microsoft.AspNetCore.Mvc;

namespace Smyrna_Prototype.Controllers
{
    public class FilesController : Controller
    {
        public ActionResult GetPdfFile()
        {
            // Step 1: Read the PDF file as a byte array
            string rootPath = @"C:\Users\fowle\source\repos\Smyrna_Prototype\Smyrna_Prototype\wwwroot\UploadedFiles\\"; // Replace this with the appropriate root directory path.
            string pdfFileName = "rehabilitationform.pdf";
            string pdfFilePath = Path.Combine(rootPath, pdfFileName);
       
            byte[] bytes = System.IO.File.ReadAllBytes(pdfFilePath);

            // Step 2: Set the appropriate content type for a PDF file
            string contentType = "application/pdf";

            // Step 3: Return the byte array with the correct content type
            return File(bytes, contentType, pdfFileName);
        }
    }
}
