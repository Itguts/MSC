using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient("restapiclient", c => c.BaseAddress = new System.Uri(builder.Configuration["WebAPIBaseUrl"]));
//Uri endPointA = new Uri("http://localhost:44318/api/"); // this is the endpoint HttpClient will hit
//HttpClient httpClient = new HttpClient()
//{
//    BaseAddress = endPointA,
//};

//ServicePointManager.FindServicePoint(endPointA).ConnectionLeaseTimeout = 60000; // sixty seconds

//builder.Services.AddSingleton<HttpClient>(httpClient);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
