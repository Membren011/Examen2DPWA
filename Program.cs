using Examen2DPWA;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

//Inicio de servicios


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Examen2 DPWA", Description = "Tienda", Version = "v1" });
});


// Fin de servicios

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "PizzaStore API V1");
    });
}

app.MapGet("productos/{id}", (int Id) => ProductsData.GetProductsId(Id));
app.MapGet("/productos/Get", () => ProductsData.GetProducts());
app.MapPost("/productos/Create", (Productos productos) => ProductsData.CreateProducts(productos));
app.MapPut("/productos/Update", (Productos productos) => ProductsData.UpdateProducts(productos));
app.MapDelete("/productos/Remove", (int Id) => ProductsData.DeleteProducts(Id));

app.Run();
