using System;
using System.Text.Json;
using Microsoft.AspNetCore.Builder;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Cấu hình CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        }); 
});

// Cấu hình Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();

app.Run();

partial class Program
{
    static string CalculateCircleProperties(double r)
    {
        var result = new
        {
            dien_tich = Math.PI * r * r,
            chu_vi = 2 * Math.PI * r,
            duong_kinh = 2 * r
        };

        return JsonSerializer.Serialize(result);
    }

    static void Main(string[] args)
    {
        double r;
        while (true)
        {
            Console.Write("Nhập bán kính r: ");
            if (double.TryParse(Console.ReadLine(), out r) && r > 0)
            {
                break;
            }
            Console.WriteLine("Bán kính không hợp lệ. Vui lòng nhập lại!");
        }

        string result = CalculateCircleProperties(r);
        Console.WriteLine($"Kết quả: {result}");
    }
}