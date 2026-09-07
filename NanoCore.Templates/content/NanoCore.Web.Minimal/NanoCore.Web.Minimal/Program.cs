using Nano.App.Web;
using NanoCore.Web.Minimal;

NanoWebApplication
    .ConfigureApp()
    .ConfigureServices(_ =>
    {
        // Add your services here.
    })
    .Build<App>()
    .Run();
