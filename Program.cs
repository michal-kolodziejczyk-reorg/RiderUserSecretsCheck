// this is a project to check how OS reads user secrets
// 1. Run the project. It should fail due to the fact that AddUserSecrets has optional argument set to false
// 2. Change AddUserSecrets optional argument to true
// 3. Run the project. It should read appsettings.json file and display "appsettings" on Console
// 4. Add user secrets to the project
// 5. Put body of appsettings.json into user secrets, change value of "Source" to "user secrets"
// 6. Run the project. Now user secrets should override appsettings.json and program displays "user secrets"

var builder = Host.CreateEmptyApplicationBuilder(new HostApplicationBuilderSettings());
builder.Services.AddOptions();
builder.Configuration
    .AddJsonFile("appsettings.json", optional: false)
    .AddUserSecrets(Assembly.GetExecutingAssembly(), optional: false);

var host = builder.Build();
var configuration = host.Services.GetRequiredService<IConfiguration>();
Console.WriteLine(configuration.GetValue<string>("Source"));
