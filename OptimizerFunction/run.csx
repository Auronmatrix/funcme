#r "System.Web"
#r "System.Core"

using System.Dynamic;
using System.Net;
using System.Web;


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
    
    // Set name to query string or body data
    // name = name ?? data?.User_Name;
   var responseMsg = new { text = "This is a response message to " + parameters.user_name };
     return parameters.user_name == null
         ? req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a name on the query string or in the request body")
        : req.CreateResponse(HttpStatusCode.OK, responseMsg );
}