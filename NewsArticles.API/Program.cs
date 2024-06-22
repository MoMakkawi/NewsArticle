using Microsoft.AspNetCore.Identity;

using Microsoft.EntityFrameworkCore;
using NewsArticles.API.Application;
using NewsArticles.API.Application.Contracts;
using NewsArticles.API.Application.Profiles;
using NewsArticles.API.Endpoints;
using NewsArticles.API.Persistence;
using NewsArticles.API.Persistence.Data;
using NewsArticles.API.Persistence.Identity;
using NewsArticles.API.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.AddPersistenceServices()
    .AddApplicationServices();

builder.Services.AddAuthentication(IdentityConstants.ApplicationScheme);
builder.Services.AddAuthorizationBuilder();

builder.Services
    .AddIdentity<User, IdentityRole<Guid>>()
    .AddEntityFrameworkStores<NewsArticleDBContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapNewsArticlesEndpoints();

app.UseDeveloperExceptionPage();
app.UseHttpsRedirection();

app.UseAuthentication()
   .UseAuthorization();

app.Run();


