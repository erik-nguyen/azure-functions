using System.Collections.Generic;

namespace ExampleFunction.Models
{
    public class Coord
    {
        public double lon { get; set; }
        public double lat { get; set; }
    }

    public class Weather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    public class Main
    {
        public double temp { get; set; }
        public double pressure { get; set; }
        public double humidity { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
    }

    public class Wind
    {
        public double speed { get; set; }
        public double deg { get; set; }
    }

    public class Clouds
    {
        public double all { get; set; }
    }

    public class Sys
    {
        public int type { get; set; }
        public int id { get; set; }
        public double message { get; set; }
        public string country { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
    }

    public class ResponseWeather
    {
        public Coord coord { get; set; }
        public List<Weather> weather { get; set; }
        public string @base { get; set; }
        public Main main { get; set; }
        public int visibility { get; set; }
        public Wind wind { get; set; }
        public Clouds clouds { get; set; }
        public int dt { get; set; }
        public Sys sys { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int cod { get; set; }
        public string message { get; set; }
    }
}


//d7381afe-1dff-48a0-b67c-1306c1bfa10a
//https://maps.googleapis.com/maps/api/geocode/json?address=1600+Amphitheatre+Parkway,+Mountain+View,+CA&key=AIzaSyA8tx1f58tKYQ9Cg7QlWTLx4PqxrXdQm7Q
//https://maps.googleapis.com/maps/api/geocode/json?address=Ho Chi Minh&key=AIzaSyA8tx1f58tKYQ9Cg7QlWTLx4PqxrXdQm7Q
//https://maps.googleapis.com/maps/api/geocode/json?address=Ho+Chi+Minh+City,+Vietnam&key=AIzaSyA5ZSglExH1eZYFCvjTJ5G--G8UnNYimpM
//http://maps.googleapis.com/maps/api/geocode/xml?address=1600+Amphitheatre+Parkway,+Mountain+View,+CA&sensor=true_or_false
//https://maps.googleapis.com/maps/api/geocode/xml?address=1600+Amphitheatre+Parkway,+Mountain+View,+CA&key=AIzaSyA5ZSglExH1eZYFCvjTJ5G--G8UnNYimpM

//9704060334879297
//59134b435059d763c564f59f0b23c17d
//http://api.openweathermap.org/data/2.5/weather?q=London&mode=json&units=imperial&APPID=59134b435059d763c564f59f0b23c17d
//59134b435059d763c564f59f0b23c17d
//http://api.openweathermap.org/data/2.5/weather?q=London&mode=json&units=imperial&appid=9749874xw2kfiq9029j092m0j9kfj07e
//1600 Amphitheatre Parkway, Mountain View, CA
//http://api.openweathermap.org/data/2.5/weather?q=HoChiMinh