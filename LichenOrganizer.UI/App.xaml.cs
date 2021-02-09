using Autofac;
using LichenOrganizer.DataAccess.Data;
using LichenOrganizer.UI.Data;
using LichenOrganizer.UI.Startup;
using LichenOrganizer.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace LichenOrganizer.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //Initialize DIC and return container to App.
            var bootstrapper = new Bootstrapper();
            var container = bootstrapper.Bootstrap();

            //Call the MainWindow instance from the DIC.
            var mainWindow = container.Resolve<MainWindow>();

            //LichenOrganizerDbContextExtensions.SeedMockData(container.Resolve<LichenOrganizerDbContext>());
            
            mainWindow.Show();

        }
    }
}
