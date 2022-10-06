using Asp.Omeno.Service.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Collections;

using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Asp.Omeno.Service.Application.Services.Languages.Queries.GetLanguageTranslation
{
    public class GetLanguageTranslationQueryHandler : IRequestHandler<GetLanguageTranslationModel, OkObjectResult>
    {
        
      
        public async Task<OkObjectResult> Handle(GetLanguageTranslationModel request, CancellationToken cancellationToken)
        {
            object TranslatedData = TranslateText(request.inputData, request.languagePair);
            return new OkObjectResult(TranslatedData);            
        }


        private static string TranslateText(string input, string languagePair)
        {
            // Set the language from/to in the url (or pass it into this function)
            string url = String.Format
            ("https://translate.googleapis.com/translate_a/single?client=gtx&sl={0}&tl={1}&dt=t&q={2}",
             "en", languagePair, Uri.EscapeUriString(input));
            HttpClient httpClient = new HttpClient();
            string result = httpClient.GetStringAsync(url).Result;
            

            // Get all json data
            //var jsonData = new JavaScriptSerializer().Deserialize<List<dynamic>>(result);
            dynamic jsonData = JArray.Parse(result);
            // Extract just the first array element (This is the only data we are interested in)
            var translationItems = jsonData[0];

            // Translation Data
            string translation = "";

            // Loop through the collection extracting the translated objects
            foreach (object item in translationItems)
            {
                // Convert the item array to IEnumerable
                IEnumerable translationLineObject = item as IEnumerable;

                // Convert the IEnumerable translationLineObject to a IEnumerator
                IEnumerator translationLineString = translationLineObject.GetEnumerator();

                // Get first object in IEnumerator
                translationLineString.MoveNext();

                // Save its value (translated text)
                translation += string.Format(" {0}", Convert.ToString(translationLineString.Current));
            }

            // Remove first blank character
            if (translation.Length > 1) { translation = translation.Substring(1); };

            // Return translation
            return translation;
        }

    }
}
