using Autofac;
using Prism.Events;
using Microsoft.Extensions.Configuration;
using LichenOrganizer.DataAccess;
using LichenOrganizer.UI.Data;
//using LichenOrganizer.UI.ViewModel;
using LichenOrganizer.UI.ViewModels;

namespace LichenOrganizer.UI.Startup

{
    /// <summary>
    /// The bootstrapper class is responsible for creating the Autofac container.  The container knows about all the types and 
    /// is used to create instances.
    /// </summary>
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            //Register types. 
            builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();
            builder.RegisterType<LichenOrganizerDbContext>().AsSelf();

            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainViewModel>().AsSelf();
            builder.RegisterType<NavigationViewModel>().As<INavigationViewModel>();
            builder.RegisterType<FriendDetailViewModel>().As<IFriendDetailViewModel>();

            builder.RegisterType<LookupDataService>().AsImplementedInterfaces();
            builder.RegisterType<FriendDataService>().As<IFriendDataService>();

            //builder.RegisterType<LichenOrganizerDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            return builder.Build();

        }
    }
}
