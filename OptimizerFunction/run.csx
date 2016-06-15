#r "System.Web"
#r "System.Core"
#load "tsp.csx"

using System.Dynamic;
using System.Net;
using System.Web;
using System.Collections.Generic;
using System.IO;

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
{
    log.Info($"C# HTTP trigger function processed a request. RequestUri={req.RequestUri}. This is Optiman!");
       
    // parse query parameter
    string name = req.GetQueryNameValuePairs()
        .FirstOrDefault(q => string.Compare(q.Key, "name", true) == 0)
        .Value;

    // Get request body
    string data = await req.Content.ReadAsStringAsync();
    
    var queryString = HttpUtility.ParseQueryString(data);

            dynamic parameters = new ExpandoObject();
            var temp = (IDictionary<string, object>)parameters;
            foreach (var key in queryString.AllKeys)
            {
                temp[key] = queryString[key];
            }
    
     log.Info($"Checking for username {parameters.user_name}");
     
     var result = "";

     TravellingSalesmanProblem problem = new TravellingSalesmanProblem();
            problem.FilePath = "Cities.txt";
            problem.Anneal();

            string path = "";
            for (int i = 0; i < problem.CitiesOrder.Count - 1; i++)
            {
                path += problem.CitiesOrder[i] + " -> ";
            }
            path += problem.CitiesOrder[problem.CitiesOrder.Count - 1];

            log.Info("Shortest Route: " + path);
            result = problem.ShortestDistance.ToString();
            log.Info("The shortest distance is: " + optimizationResult);
          
    // Set name to query string or body data
    // name = name ?? data?.User_Name;
   var responseMsg = new { text = $"hey {parameters.user_name} the optimization result was {result}" };
     return parameters.user_name == null
         ? req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a name on the query string or in the request body")
        : req.CreateResponse(HttpStatusCode.OK, responseMsg );
}