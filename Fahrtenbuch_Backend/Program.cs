using Fahrtenbuch_Backend.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<LogBookDBContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("LogbookDBContext");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }

//asd

//docker run -it --rm --name logbookapi -p 3000:80 logbooksapi
// docker run -it --rm --name logbookapi -p 3000:80  - e "ConnectionStrings:LogbookContext"="" logbooksapi