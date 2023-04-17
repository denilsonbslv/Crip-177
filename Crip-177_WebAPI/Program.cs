using Crip_177_WebAPI.IServices;
using Crip_177_WebAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Adiciona os serviços do MVC.
builder.Services.AddControllers();

// Registra o serviço de criptografia.
builder.Services.AddScoped<IEncryptionService, EncryptionService>();

// Configura o aplicativo para usar o MVC.
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();