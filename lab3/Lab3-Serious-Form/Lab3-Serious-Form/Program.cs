using Lab3_Serious_Form.Endpoints;
using Lab3_Serious_Form.Options;
using Lab3_Serious_Form.Repository;
using Lab3_Serious_Form.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

WebApplicationOptions webApplicationOptions = new WebApplicationOptions
{
    Args = args,
};
var builder = WebApplication.CreateBuilder(webApplicationOptions);

// мы могли бы реализовать интерфейс для монги, но вместо этого мы берем фабрику
builder.Services.AddScoped(typeof(IMongoDatabase), sp =>
{
    var option = sp.GetRequiredService<IOptions<DatabaseOptions>>();
    var url = MongoUrl.Create(option.Value.ConnectionString);
    var client = new MongoClient(url);
    return client.GetDatabase(url.DatabaseName);
});

// 
builder.Services.Configure<DatabaseOptions>(builder.Configuration.GetSection(nameof(DatabaseOptions)));
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<IReviewService, ReviewService>();

builder.Services.AddControllers();

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
app.UseDefaultFiles(new DefaultFilesOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/dist/lab3/browser")),
});
app.UseStaticFiles(new StaticFileOptions() { FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/dist/lab3/browser")) });

app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
 ReviewEndpoint.MapUserEndpoints(endpoints));
app.MapControllers();

app.Run();
