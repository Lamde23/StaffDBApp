using StaffLibrary;
using StaffLibrary.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddSingleton<IStaffData, StaffData>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapGet("/staffGet", async (IStaffData db) =>
{
    var output = await db.GetStaff();
    return output;
});
app.MapPost("/staffInsert", async (IStaffData db, StaffModel data) =>
{
    await db.InsertStaffAsync(data);
});

//Upsert
app.MapPost("/purchase", async (IStaffData db, StaffPaymentModel data) =>
{
    await db.InsertPaymentAsync(data);
});

app.UseAuthorization();

app.MapControllers();

app.Run();
