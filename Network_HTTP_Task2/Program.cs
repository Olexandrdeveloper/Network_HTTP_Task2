using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Network_HTTP_Task2
{
    internal class Program
    {
        private static HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.Write("Введіть ваше ім'я: ");
            string name = Console.ReadLine();

            Console.Write("Введіть повідомлення: ");
            string message = Console.ReadLine();

            string url = "https://jsonplaceholder.typicode.com/posts";

            var payload = new MessageModel
            {
                name = name,
                message = message
            };

            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync(url, payload);

                if (response.IsSuccessStatusCode)
                {
                    string responseString = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("\nСервер успішно відповів:");
                    Console.WriteLine(responseString);
                }
                else
                {
                    Console.WriteLine($"Помилка сервера: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }
        }
    }

    public class MessageModel
    {
        public string name { get; set; }
        public string message { get; set; }
    }
}
