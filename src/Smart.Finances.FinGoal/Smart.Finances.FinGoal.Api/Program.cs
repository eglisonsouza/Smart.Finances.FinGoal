using Smart.Essentials.Filters;
using Smart.Finances.FinGoal.Application.Extensions;
using Smart.Finances.FinGoal.Infra.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfraestructure(builder.Configuration)
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddApplicationDependencies()
    .AddControllers(options => options.Filters.Add(typeof(DefaultExceptionFilterAttribute)));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app
        .UseSwagger()
        .UseSwaggerUI();
}

app
    .UseHttpsRedirection()
    .UseAuthorization();

app.MapControllers();

app.Run();
