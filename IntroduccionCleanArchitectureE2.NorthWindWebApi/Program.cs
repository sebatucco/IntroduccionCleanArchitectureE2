

using FluentValidation;
using IntroduccionCleanArchitectureE2.NorthWindEntities.Exceptions;
using IntroduccionCleanArchitectureE2.NorthWindInversionOfControl;
using IntroduccionCleanArchitectureE2.NorthWindWebExceptionPresenter;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
options.Filters.Add(new ApiExceptionFilterAtribute(
    new Dictionary<Type, IExceptionHandler>
    {
        { typeof(GeneralExceptions), new GeneralExceptionHandler()},
        { typeof(ValidationException), new ValidationExceptionHandler()}
    }
    )));
builder.Services.AddServicesIntroduccionCleanArchitectureE2(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.Run();
