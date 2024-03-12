using Web.Core;
using Web.Api.Extensions;
using Web.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();

    builder.Services.AddDefaultCors(builder.Configuration);

    builder.Services.AddScoped<IRecordPresenter, RecordPresenter>();

    builder.Services.AddMemoryCache();

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseCors();

    app.MapControllers();
}

app.Run();
