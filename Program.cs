




using Microsoft.EntityFrameworkCore;
using notes_api.Data.Context;
using notes_api.Data.Entities;
using notes_api.Services.NotesProvider;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<InMemoryDbContext>(opt =>
{
    opt.UseInMemoryDatabase("NotesDb");
});

builder.Services.AddTransient<INotesProviderService, NotesProviderService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));


var app = builder.Build();

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
            Title = "Dentist",
            Content = "Avoid at all cost!"
        });

        notes.Notes.Add(new Note
        {
            TimeStamp = DateTime.Now,
            Title = "Dentist",
            Content = "efefef"
        });

        notes.SaveChanges();
    }
}