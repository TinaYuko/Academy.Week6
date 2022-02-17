using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AcademyD.Demo4.ClientWebApi
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World! I'm using the Web Api client!");

            HttpClient client = new HttpClient();

            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://localhost:44359/api/Employee")
            };

            HttpResponseMessage httpResponse = await client.SendAsync(request);

            if (httpResponse.IsSuccessStatusCode)
            {
                var jsonData = await httpResponse.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<IList<EmployeeContract>>(jsonData);

                foreach (var item in result)
                {
                    Console.WriteLine($"{item.FirstName} {item.LastName}");
                    //Console.WriteLine($"{item.Name} {item.LastName}");
                }
            }

            // ==============================================

            var employee = new EmployeeContract
            {
                Id = "f3c18c4c-f149-4fa2-8057-32f5d736c64c",
                FirstName = "Alessandro",
                LastName = "Manzoni",
                EmployeeCode = "EMP100"
            };

            httpResponse = await client.PutAsync(
                new Uri("https://localhost:44359/api/Employee/f3c18c4c-f149-4fa2-8057-32f5d736c64c"),
                new StringContent(JsonConvert.SerializeObject(employee), Encoding.UTF8, "application/json") 
                // e' necessario spcificare l'encoding della stringa che arriva dall'api e il media type
                );

            if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonData = await httpResponse.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<EmployeeContract>(jsonData);
                Console.WriteLine($"Employe updated {result.FirstName} {result.LastName}");
            }
        }
    }
}
