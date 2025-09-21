using Datavanced.Applications;
using Datavanced.Applications.Actions.Doctors.Pull.PullDoctors;
using Datavanced.Applications.Actions.Medicines.Push;
using Datavanced.Infrastructures;
using Datavanced.Medical.Framework.Validator;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DatavancedMedicalDbContext>(o =>
{
    o.UseSqlServer(builder.Configuration.GetConnectionString("DatavancedMedicalDbContext"));
    if (builder.Environment.IsDevelopment())
    {
        o.EnableDetailedErrors();
        o.EnableSensitiveDataLogging();
    }
});

builder.Services.AddScoped<IDatavancedMedicalDbContext, DatavancedMedicalDbContext>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(PullDoctorsHandler).GetTypeInfo().Assembly));

builder.Services.AddValidatorsFromAssemblyContaining<PushMedicineValidator>();

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidator<,>));

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
