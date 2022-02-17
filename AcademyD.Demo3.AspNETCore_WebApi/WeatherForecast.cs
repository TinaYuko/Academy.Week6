using System;

namespace AcademyD.Demo3.AspNETCore_WebApi
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
        public MiaNuovaClasse MyProperty { get; set; }
    }

    public class MiaNuovaClasse
    {
        public string Name { get; set; }    
        public string Surname { get; set; }    
    }
}
