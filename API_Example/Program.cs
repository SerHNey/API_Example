/*using Npgsql;

var connString = "Host=postgres;Username=postgres;Password=changeme;Database=ddp23";

await using var conn = new NpgsqlConnection(connString);
await conn.OpenAsync();

await using (var cmd = new NpgsqlCommand("INSERT INTO public.message(sqehg) VALUES (@p)", conn))
{
    cmd.Parameters.AddWithValue("p", "wastc");
    await cmd.ExecuteNonQueryAsync();
}
*/

using Newtonsoft.Json.Serialization;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(options => options.AddPolicy("CorsPolicy",
                build =>
                {
                    build.WithOrigins("http://localhost:5001").AllowAnyMethod().AllowAnyHeader();
                }));

builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
options.SerializerSettings.ReferenceLoopHandling=Newtonsoft.Json.ReferenceLoopHandling.Ignore)
    .AddNewtonsoftJson(options =>options.SerializerSettings.ContractResolver = new DefaultContractResolver());

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors("CorsPolicy");

app.UseAuthorization();



app.MapControllers();

app.Run();
