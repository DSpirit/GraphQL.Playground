using GraphQL;
using GraphQL.Server.Ui.Playground;
using Microsoft.EntityFrameworkCore;
using Playground.Entities;
using Playground.Interfaces;
using Playground.Repositories;
using Playground.Schemas;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IMovieRepository, MovieRepository>();
builder.Services.AddTransient<ICinemaRepository, CinemaRepository>();
builder.Services.AddGraphQL(qlBuilder => qlBuilder
    .AddAutoSchema<GraphQLSchema>()
    .AddSystemTextJson());

builder.Services.AddDbContext<MovieDbContext>(
    options => options.UseMongoDB(
        builder.Configuration.GetConnectionString("MongoDB")!,
        "movies"));

builder.Services.AddDbContext<CinemaDbContext>(
    options => options.UseSqlite(
        builder.Configuration.GetConnectionString("Sqlite")!));

var app = builder.Build();

using var db = new CinemaDbContext();
db.Database.EnsureCreated();

app.UseGraphQL();
app.UseGraphQLVoyager();
app.UseGraphQLPlayground("/", new PlaygroundOptions
{
    GraphQLEndPoint = "/graphql",
    SubscriptionsEndPoint = "/graphql"
});

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