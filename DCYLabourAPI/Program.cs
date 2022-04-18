var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(c => c.AddPolicy("any", p => p.AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader()));
builder.Services.Configure<IISServerOptions>(options =>{
    options.MaxRequestBodySize = 1073741822;
});

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("any");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
