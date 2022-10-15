using WebApiDemo.CustomMiddlewares;
using WebApiDemo.DataAccess;
using WebApiDemo.Formatters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.OutputFormatters.Add(new VCardOutputFormatter());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProductDal, EfProductDal>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<AuthenticationMiddleware>();
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();
