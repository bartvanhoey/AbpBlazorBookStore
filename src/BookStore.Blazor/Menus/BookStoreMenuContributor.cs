﻿using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BookStore.Localization;
using Volo.Abp.Account.Localization;
using Volo.Abp.UI.Navigation;
using Volo.Abp.Users;
using BookStore.Permissions;

namespace BookStore.Blazor.Menus
{
  public class BookStoreMenuContributor : IMenuContributor
  {
    private readonly IConfiguration _configuration;

    public BookStoreMenuContributor(IConfiguration configuration)
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

    private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
      var l = context.GetLocalizer<BookStoreResource>();

      context.Menu.Items.Insert(
          0,
          new ApplicationMenuItem(
              BookStoreMenus.Home,
              l["Menu:Home"],
              "/",
              icon: "fas fa-home"
          )
      );

      var bookStoreMenu = new ApplicationMenuItem("BookStoreMenu", l["Menu:BookStore"], icon: "fa fa-book");
      context.Menu.AddItem(bookStoreMenu);

      if (await context.IsGrantedAsync(BookStorePermissions.Books.Default))
      {
        var booksMenu = new ApplicationMenuItem("BooksMenu", l["Menu:Books"], url: "/books");
        bookStoreMenu.AddItem(booksMenu);
      }
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
            $"{identityServerUrl.EnsureEndsWith('/')}Account/Manage?returnUrl={_configuration["App:SelfUrl"]}",
            icon: "fa fa-cog",
            order: 1000,
            null));
      }

      return Task.CompletedTask;
    }
  }
}
