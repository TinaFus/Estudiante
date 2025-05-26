using EstudentAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// ⬅️ Esta línea es la clave:
builder.Services.AddTransient<IStudentService, StudentService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection(); ← puedes comentar esto si te daba error antes

app.MapControllers();
app.Run();





