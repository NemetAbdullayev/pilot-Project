using BusinessLayer.Abstract.BuildingAbstractServices;
using BusinessLayer.Abstract.PoiAbstractServices;
using BusinessLayer.Abstract.RoadAbstractServices;
using BusinessLayer.Concrete.BuildingManagers;
using BusinessLayer.Concrete.PoiManagers;
using BusinessLayer.Concrete.RoadManagers;
using BusinessLayer.Mapper;
using DataAccessLayer.Abstract;
using DataAccessLayer.Abstract.BuildingInterfaces;
using DataAccessLayer.Abstract.DapperInterface;
using DataAccessLayer.Abstract.PoiInterfaces;
using DataAccessLayer.Abstract.RoadInterfaces;
using DataAccessLayer.Concrete.Context;
using DataAccessLayer.Concrete.EntityFramework;
using DataAccessLayer.Concrete.EntityFramework.BuildingRepositories;
using DataAccessLayer.Concrete.EntityFramework.DapperRepository;
using DataAccessLayer.Concrete.EntityFramework.PoiRepositories;
using DataAccessLayer.Concrete.EntityFramework.RoadRepositories;
using EntityLayer.Concrete.Building;
using EntityLayer.Concrete.Point;
using EntityLayer.Concrete.Road;
using EntityLayer.DapperContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
string connection = builder.Configuration.GetConnectionString("Db");

builder.Services.AddDbContext<DatabaseContext>(opts =>  
{
    opts.UseNpgsql(
        connection,
        x => x.UseNetTopologySuite()
    );
});
builder.Services.AddControllers().AddNewtonsoftJson();

builder.Services.AddScoped<IPoiRepository, PoiRepository>();
builder.Services.AddScoped<IGenericRepository<Poi>, GenericRepository<Poi>>();
builder.Services.AddScoped<IPoiService, PoiManager>();
//
builder.Services.AddScoped<IPoiPropertiesRepository, PoiPropertiesRepository>();
builder.Services.AddScoped<IGenericRepository<PoiProperties>, GenericRepository<PoiProperties>>();
builder.Services.AddScoped<IPoiPropertiesService, PoiPropertiesManager>();

////
builder.Services.AddScoped<IPoiFeatureRepository, PoiFeatureRepository>();
builder.Services.AddScoped<IGenericRepository<PoiFeature>, GenericRepository<PoiFeature>>();
builder.Services.AddScoped<IPoiFeatureService, PoiFeatureManager>();
//
builder.Services.AddScoped<IBuildingRepository, BuildingRepository>();
builder.Services.AddScoped<IGenericRepository<Building>, GenericRepository<Building>>();
builder.Services.AddScoped<IBuildingService, BuildingManager>();
//
builder.Services.AddScoped<IBuildingFeatureRepository, BuildingFeatureRepository>();
builder.Services.AddScoped<IGenericRepository<BuildingFeature>, GenericRepository<BuildingFeature>>();
builder.Services.AddScoped<IBuildingFeatureService, BuildingFeatureManager>();
//
builder.Services.AddScoped<IRoadFeauteRepository, RoadFeatureRepository>();
builder.Services.AddScoped<IGenericRepository<RoadFeature>, GenericRepository<RoadFeature>>();
builder.Services.AddScoped<IRoadFeautreService, RoadFeatureManager>();
//
builder.Services.AddScoped<IRoadRepository, RoadRepository>();
builder.Services.AddScoped<IGenericRepository<Road>, GenericRepository<Road>>();
builder.Services.AddScoped<IRoadService, RoadManager>();
//
builder.Services.AddScoped<IRoadPropertiesRepository, RoadPropertiesRepository>();
builder.Services.AddScoped<IGenericRepository<RoadProperties>, GenericRepository<RoadProperties>>();
builder.Services.AddScoped<IRoadPropertiesService, RoadPropertiesManager>();
builder.Services.AddScoped<DataContext>();
builder.Services.AddScoped<IDapperRepository<Building>, DapperRepository<Building>>();
builder.Services.AddScoped<IDapperRepository<Poi>, DapperRepository<Poi>>();
builder.Services.AddScoped<IDapperRepository<Road>, DapperRepository<Road>>();
builder.Services.AddAutoMapper(typeof(Automapper));
// Configure the HTTP request pipeline.
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
