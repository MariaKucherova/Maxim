using MaximTasks.Task1.Lib;
using Microsoft.OpenApi.Models;

namespace MaximTasks.Task.WebAPI
{
    public class Program
    {
        static HttpClient httpClient = new HttpClient();

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Task API",
                    Version = "v1",
                });
            });

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Task API V1");
            });

            app.MapGet("/string/{input}/{sorting}", async (string input, int sorting) =>
            {
                var result = StringUtilities.Transform(input);

                if (result.Contains("Были введены не подходящие символы:") || result == string.Empty)
                {
                    return Results.BadRequest(new { message = result });
                }

                var obj = new StringResponse();
                obj.Result = result;

                var chars = StringUtilities.CalculateNumberChar(result);
                obj.Chars = chars;

                var substring = StringUtilities.GetLongestSubstringVowel(result);
                if (substring != string.Empty)
                {
                    obj.Substring = substring;
                }

                if (sorting == 1)
                {
                    obj.SortedResult = SortingAlgorithms.QuickSort(result.ToCharArray(), 0, result.Length - 1);
                }
                else if (sorting == 2)
                {
                    obj.SortedResult = SortingAlgorithms.TreeSort(result.ToCharArray());
                }


                var max = result.Length - 1;
                var requestUri = $"http://www.randomnumberapi.com/api/v1.0/random?min=0&max={max}&count=1";
                using HttpResponseMessage response = await httpClient.GetAsync(requestUri);

                int randomNumber;

                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    var random = new Random();
                    randomNumber = random.Next(0, max);
                }
                else
                {
                    var content = await response.Content.ReadAsStringAsync();
                    randomNumber = int.Parse(content.Substring(1, content.Length - 3));
                }

                obj.CutedResult = result.Remove(randomNumber, 1);

                return Results.Json(obj);
            });

            app.Run();
        }
    }
}
