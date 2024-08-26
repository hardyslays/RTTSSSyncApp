using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Text.Json;
using System.Web;
using System.Web.Mvc;
using RTTSSyncApp.Controllers.HttpControllers;
using RTTSSyncApp.Models;
using RTTSSyncApp.ViewModels;
using static RTTSSyncApp.Models.Configuration;

namespace RTTSSyncApp.Controllers
{
    public class HomeController : Controller
    {
        /* --------------------------------------------------
                       Intialization variables
           -------------------------------------------------- */
        private HomeViewModel viewModel { get; set; } = new HomeViewModel(Models.Configuration.DocTypes.ToArray());
        private void UpdateViewModel(FileValidationResult validationResult)
        {
            viewModel.validationResult = validationResult;
        }

        /* --------------------------------------------------
                               Routers
           -------------------------------------------------- */

        // Home page
        [Route("")]
        [Route("Home/Index")]
        public ActionResult Index()
        {
            return View(viewModel);
        }

        [Route("Home/Logs")]
        public ActionResult Logpage()
        {
            return View("Logs");
        }


        [HttpPost]
        public ActionResult Process(string selectedDocType, HttpPostedFileBase file)
        {
            // Validate response
            FileValidationResult validationResult = ValidateFile(file);
            //If not Valid, send back error
            if(!validationResult.valid)
            {
                UpdateViewModel(validationResult);
                return View("Index", viewModel);
            }
            //If Valid
            // Get the doc details
            DocTypeInfo docTypeInfo = Configuration.DocTypes.FirstOrDefault(x => x.DocId == selectedDocType);
            //Process the document
            // 1. Get Oauth token

            //string token = OauthController.GetToken();

            // 2. Make RTTS API call

            //string response = RTTSController.GetRTTSResponse(file, token, docTypeInfo);
            //Responseobj responseJson = JsonSerializer.Deserialize<Responseobj>(response);

            // Parse results to field values

            //AddResultsToViewModel(responseJson);

            // Add field Values to viewModel
            RTTSFieldValues[] fieldValues = new RTTSFieldValues[3];
            fieldValues[0] = new RTTSFieldValues { FieldName = "Name", FieldValue = "John Doe", Confidence = "100%" };
            fieldValues[1] = new RTTSFieldValues { FieldName = "Address", FieldValue = "123 Main St", Confidence = "100%" };
            fieldValues[2] = new RTTSFieldValues { FieldName = "Phone", FieldValue = "555-555-5555", Confidence = "100%" };

            viewModel.fieldValues = fieldValues;

            return View("Index", viewModel);
        }

        /* --------------------------------------------------
                            Utility methods
           -------------------------------------------------- */


        // Form submission page

        private FileValidationResult ValidateFile(HttpPostedFileBase file)
        {
            // Validate if File is passed
            if (file == null)
            {
                return new FileValidationResult(false, "No file selected.");
            }
            //Validate size
            if(file.ContentLength > Configuration.MaxFileSize)
            {
                return new FileValidationResult(false, "File size exceeds maximum allowed size of " + Convert.ToString(Configuration.MaxFileSize) + " bytes.");
            }
            //Validate type
            if(!Configuration.AllowedFileExt.Contains(file.ContentType))
            {
                return new FileValidationResult(false, "File type not allowed.");
            }

            return new FileValidationResult(true, "");
        }

        private void AddResultsToViewModel(string responseJson)
        {

        }
    }
}