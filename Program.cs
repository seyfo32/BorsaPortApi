using api.Data;
using api.Interfaces;
using api.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 🔧 Swagger servisini ekliyoruz
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); // Swagger JSON için
builder.Services.AddSwaggerGen();   
        // Swagger UI için
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IStockRepository, StockRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
var app = builder.Build();

// 🔧 Sadece geliştirme ortamında Swagger UI aktif
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();       // /swagger/v1/swagger.json
    app.UseSwaggerUI();     // Tarayıcıda UI arayüzü
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

