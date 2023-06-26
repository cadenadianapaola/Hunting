using STGenetics.Data;
using STGenetics.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

var MyCors = "MyCors";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContextFactory<STGeneticsDbContext>();
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<IAnimalRepository, AnimalRepository>();


builder.Services.AddCors(options =>
{
    options.AddPolicy(MyCors, builder =>
    {
        builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();

    });
});



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

app.UseCors(MyCors);


app.Run();
