using CRM_API;
using CRM_API.DTOs;
using CRM_API.Repository;
using CRM_API.Services;
using CRM_API.Validations;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IValidator<DCustomer>, AddCustomerValidator>();
builder.Services.AddScoped<IValidator<string>, GetCustomersByNameValidator>(); 
builder.Services.AddScoped<IValidator<DCustomer>, UpdateCustomerValidator>();
builder.Services.AddScoped<IValidator<DCustomer>, DeleteCustomerValidator>();
builder.Services.AddScoped<IValidator<DCustomer>>(provider =>
{
    var customerRepository = provider.GetRequiredService<ICustomerRepository>();
    return new UpdateCustomerValidator(customerRepository);
}); 
builder.Services.AddScoped<IValidator<DCustomer>>(provider =>
{ 
    var customerRepository = provider.GetRequiredService<ICustomerRepository>(); 
    return new DeleteCustomerValidator(customerRepository); 
});
builder.Services.AddScoped<ICustomerServiceFactory, CustomerServiceFactory>();
builder.Services.AddScoped<ICustomerService>(provider =>
{
    var factory = provider.GetRequiredService<ICustomerServiceFactory>();
    return factory.CreateCustomerService();
});
builder.Services.AddDbContext<CRMDBContext>();
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