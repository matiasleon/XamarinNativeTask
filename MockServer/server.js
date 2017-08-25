var express = require('express');
var app = express();
var languages = ["C", "C++", "Java", "Java1", "Java2", "Java3", "Java4", ".NET", "iPhone", "Android", "ASP.NET", "PHP"];

app.get('/', function (req, res) {
  res.send('Hola server');
});

app.get('/languages', function (req, res) {
  res.send(languages);
});

app.listen(3000, function () {
  console.log('Escuchando en puerto 3000');
});