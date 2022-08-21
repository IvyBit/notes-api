




using Microsoft.EntityFrameworkCore;
using notes_api.Data.Context;
using notes_api.Data.Entities;
using notes_api.Filters;
using notes_api.Services.NotesProvider;

var corsPolicyName = "allowAll";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddCors(options =>
{
    options.AddPolicy(corsPolicyName,
                      policy =>
                      {
                          policy.AllowAnyHeader()
                                .AllowAnyOrigin()
                                .AllowAnyMethod();
                      });
});

builder.Services.AddDbContext<InMemoryDbContext>(opt =>
{
    opt.UseInMemoryDatabase("NotesDb");
});

builder.Services.AddTransient<INotesProviderService, NotesProviderService>();

builder.Services.AddControllers(opt => {
    opt.Filters.Add(new GlobalExceptionFilter());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));



var app = builder.Build();

app.UseCors(corsPolicyName);

SeedNotes(app);



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



static void SeedNotes(WebApplication app)
{
    var scope = app.Services.CreateScope();
    var notes = scope.ServiceProvider.GetService<InMemoryDbContext>();

    if(notes != null)
    {
        notes.Notes.Add(new Note
        {
            TimeStamp = DateTime.Now,
            Title = "Call",
            Content = "Someone called..."
        });

        notes.Notes.Add(new Note
        {
            TimeStamp = DateTime.Now,
            Title = "To self",
            Content = "Get some sort of spellchecker for VS..."
        });

        notes.SaveChanges();
    }
}