using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AbpBookStore.Localization;
using Volo.Abp.Account.Localization;
using Volo.Abp.UI.Navigation;
using Volo.Abp.Users;

namespace AbpBookStore.Blazor
{
    public class AbpBookStoreMenuContributor : IMenuContributor
    {
        private readonly IConfiguration _configuration;

        public AbpBookStoreMenuContributor(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
            else if (context.Menu.Name == StandardMenus.User)
            {
                await ConfigureUserMenuAsync(context);
            }
        }

        private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            var l = context.GetLocalizer<AbpBookStoreResource>();

            context.Menu.Items.Insert(
                0,
                new ApplicationMenuItem(
                    "AbpBookStore.Home",
                    l["Menu:Home"],
                    "/",
                    icon: "fas fa-home"
                )
            );


            var bookStoresMenu = new ApplicationMenuItem("bookStoresMenu",l["Menu:bookStores"], icon: "fa fa-book");
            var booksMenu = new ApplicationMenuItem("booksMenu",l["Menu:books"], url: "/books");
            
            bookStoresMenu.AddItem(booksMenu);

            context.Menu.AddItem(bookStoresMenu);


            return Task.CompletedTask;
        }

        private Task ConfigureUserMenuAsync(MenuConfigurationContext context)
        {
            var accountStringLocalizer = context.GetLocalizer<AccountResource>();
            var currentUser = context.ServiceProvider.GetRequiredService<ICurrentUser>();

            var identityServerUrl = _configuration["AuthServer:Authority"] ?? "";

            if (currentUser.IsAuthenticated)
            {
                context.Menu.AddItem(new ApplicationMenuItem(
                    "Account.Manage",
                    accountStringLocalizer["ManageYourProfile"],
                    $"{identityServerUrl.EnsureEndsWith('/')}Account/Manage",
                    icon: "fa fa-cog",
                    order: 1000,
                    null,
                    "_blank"));
            }

            return Task.CompletedTask;
        }
    }
}
