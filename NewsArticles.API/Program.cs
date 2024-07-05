using Microsoft.AspNetCore.Identity;

using NewsArticles.API.Application.Profiles;
using NewsArticles.API.Endpoints;
using NewsArticles.API.Persistence;
using NewsArticles.API.Persistence.Data;
using NewsArticles.API.Persistence.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder
    .AddPersistenceServices()
    .AddApplicationServices();
    
builder.Services.AddAuthentication(IdentityConstants.ApplicationScheme);
builder.Services.AddAuthorizationBuilder();

builder.Services
    .AddIdentity<User, IdentityRole<Guid>>()
    .AddEntityFrameworkStores<NewsArticleDBContext>();

//builder.Services.AddAntiforgery();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

//app.UseAntiforgery();

app.UseDeveloperExceptionPage();
app.UseHttpsRedirection();

app.UseAuthentication()
   .UseAuthorization();

var newsArticleDBContext = app.Services
    .CreateScope()
    .ServiceProvider
    .GetRequiredService<NewsArticleDBContext>();

Seeders.SeedData(newsArticleDBContext);

app.MapNewsArticlesEndpoints();
app.MapCommentsEndpoints();

app.Run();


