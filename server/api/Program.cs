using data.concrete;
using data.interfaces;
using data.mongo;
using Microsoft.Extensions.Options;


const string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(option => {
    option.AddPolicy(name: MyAllowSpecificOrigins,
    policy => {
        policy.WithOrigins("http://localhost:3000").AllowAnyHeader()
                                                  .AllowAnyMethod();;
    });
});


// Add services to the container.

builder.Services.Configure<MongoDbConfig>(
    builder.Configuration.GetSection("MongoDb")
);

builder.Services.AddSingleton<IDatabaseConfig>(serviceProvider =>
    serviceProvider.GetRequiredService<IOptions<MongoDbConfig>>().Value);

builder.Services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));

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
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();
app.MapControllers();
app.Run();
