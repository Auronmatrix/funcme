var qs = require('querystring');

module.exports = function(context, req) {
    context.log('Node.js HTTP trigger function processed a request. RequestUri=%s', req.originalUrl);
    context.log(req.body);
    var params = qs.parse(req.body);
    context.log(params);
    
    var sassyReply = "";
    var command = params.text;
    var greetings = ['hi', 'hello', 'sup', 'whatsup'];
    var funk = ['funk', 'disco', 'party', 'dance'];
    var shipit = ['shipit', 'build', 'absolutely', 'high five'];
    
    if (greetings.some(function(v) { return command.indexOf(v) > -1; })) {
        sassyReply += "Funky greetings to you soul brother " + params.user_name + ". ";
    }
    
    if (funk.some(function(v) { return command.indexOf(v) > -1; })) {
        var commandOnly = command.replace(params.trigger_word, "");
        commandOnly = commandOnly.replace("you ", "");
        commandOnly = commandOnly.replace("?", "");
        sassyReply += "I'm definitely '" + commandOnly  + "' while listening to 'Get the funk out of your face' (https://www.youtube.com/watch?v=huzYji2OAD4). ";
        sassyReply += "Does " + params.team_domain + ' feel the funk ' + params.user_name + "? ";
    }
    
    if (shipit.some(function(v) { return command.indexOf(v) > -1; })) {
        sassyReply += "No shipit day is complete with out some serious Func-tioning Fun-c! Only here on #" + params.channel_name + ". " ;
    }
    
    if(!sassyReply)
    {
        sassyReply = "Yo! Someone called this disco maniac?";
    }
    
    console.log("Reply : " + sassyReply);
    if (params && params.user_name) {
        context.log("Found parameters");
        context.res = {
            status: 200,
            text : sassyReply
        };
    }
    else {
        context.res = {
            status: 400,
            text : "Please pass a name on the query string or in the request body"
        };
    }
    context.done();
};