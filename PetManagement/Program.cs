using Microsoft.Extensions.DependencyInjection;
using PetManagement.Business.Interface;
using PetManagement.Business.Services;
using PetManagement.Forms;
using System;
using System.Reflection;
using System.Windows.Forms;
using System.Linq;

namespace PetManagement
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);            
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var mainForm = serviceProvider.GetRequiredService<FrmMain>();

            Application.Run(mainForm);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            // Register the IDataService as a transient service
            services.AddScoped<IPetService, PetService>();

            //.AddScoped<IHelloWorkRepository, HelloWorkRepository>()
            // Register all forms in the current assembly
            RegisterAllForms(services);
        }

        private static void RegisterAllForms(IServiceCollection services)
        {
            var formType = typeof(Form);
            var assembly = Assembly.GetExecutingAssembly();

            var formTypes = assembly.GetTypes()
                                    .Where(t => t.IsSubclassOf(formType) && !t.IsAbstract);

            foreach (var type in formTypes)
            {
                services.AddTransient(type);
            }
        }
    }
}
