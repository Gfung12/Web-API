using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Configuración de servicios
builder.Services.AddControllers();  // Habilita los controladores

// Registrar nuestro servicio de lista enlazada como Singleton
// (para que mantenga el estado durante toda la vida de la aplicación)
builder.Services.AddSingleton<Web_API.Services.LinkedListService>();

// Configuración de Swagger/OpenAPI (opcional, pero útil para probar)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuración del pipeline de HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();  // Mapea los endpoints de los controladores

app.Run();