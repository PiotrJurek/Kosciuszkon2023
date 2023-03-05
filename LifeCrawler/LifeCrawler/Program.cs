using LifeCrawler.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<HabitDb>(options => options.UseSqlite("Data Source=C:\\Users\\Peter\\Documents\\Kosciuszkon2023\\LifeCrawler\\LifeCrawler.db;Version=3;"));
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo {
        Title = "LifeCrawler API",
        Description = "Level up your Life!",
        Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGet("/habits", async (HabitDb db) => await db.Habits.ToListAsync());
app.MapPost("/habit", async (HabitDb db, Habit habit) =>
{
    await db.Habits.AddAsync(habit);
    await db.SaveChangesAsync();
    return Results.Created($"/habit/{habit.habitId}", habit);
});

app.Run();