var http = require("http");
var fs = require("fs");
var path = require("path");
var staticResourceExtns = [".html",".css",".js",".jpg",".png",".ico"];
function isStatic(resource){
    return staticResourceExtns.indexOf(path.extname(resource)) !== -1;
}
http.createServer(function(req, res){
    var resource = req.url;
    var resourcePath = path.join(__dirname, req.url);
    if (isStatic(resource) && fs.existsSync(resourcePath)){
        fs.createReadStream(resourcePath).pipe(res);
    } else {
        res.statusCode = 404;
        res.end();
    }
}).listen(8080);