var mysql = require('mysql');
var express = require('express');
var connection = mysql.createConnection({
    host     : 'localhost',
    user : "root",
    port : 3306,
    database : 'chronos'
  });

connection.connect(function(err){
    if(err) throw err;
    console.log("Connected!");
});
var app = express();

app.get('/login', function (req, res) {

    connection.query("SELECT * FROM users WHERE name = ? AND password = ?;", [req.query.name, req.query.password] , function(err, results, fields){
        if(err) throw err;
        if(!results.length){
            res.send("-1");
        }
        else if(results[0].admin === 1){
            res.send("1");
        }
        else{
            res.send("0");
        }
    });
})

app.get("/users", function(req, res){
	connection.query("SELECT * FROM users", function(err, results){
		if(err) throw err;
		res.send(results);
		console.log(results);
	})
})

app.listen(3000)
