using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//Configuração para a documentação do Swagger
builder.Services.AddEndpointsApiExplorer(); //Swagger
builder.Services.AddSwaggerGen(); //Swagger

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//Executando os serviços do Swagger
app.UseSwagger();
app.UseSwaggerUI();

//Executando os serviços do Scalar
app.MapScalarApiReference(s => s.WithTheme(ScalarTheme.BluePlanet));

app.UseAuthorization();

app.MapControllers();

app.Run();
