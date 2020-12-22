using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbpBookStore.Application.Contracts.Authors;
using AbpBookStore.Permissions;
using Blazorise;
using Blazorise.DataGrid;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Volo.Abp.Application.Dtos;

namespace AbpBookStore.Blazor.Pages
{
  public partial class Authors
  {
    [Inject] protected IAuthorAppService AuthorAppService { get; set; }
    protected IReadOnlyList<AuthorDto> AuthorList { get; set; }
    protected int PageSize { get; } = LimitedResultRequestDto.DefaultMaxResultCount;
    protected int CurrentPage { get; set; }
    protected string CurrentSorting { get; set; }
    protected int TotalCount { get; set; }
    protected bool CanCreateAuthor = true;
    protected bool CanUpdateAuthor = true;
    protected bool CanDeleteAuthor = true;

    protected CreateAuthorDto NewEntity { get; set; } = new CreateAuthorDto();

    protected Guid EditingAuthorId { get; set; }
    protected UpdateAuthorDto EditingEntity { get; set; } = new UpdateAuthorDto();

    protected Modal CreateModal { get; set; }
    protected Modal EditModal { get; set; }

    protected override async Task OnInitializedAsync()
    {
      await SetPermissionsAsync();
      await GetAuthorsAsync();

    }

    protected async Task SetPermissionsAsync()
    {
      CanCreateAuthor = await AuthorizationService.IsGrantedAsync(AbpBookStorePermissions.Author.Create);
      CanUpdateAuthor = await AuthorizationService.IsGrantedAsync(AbpBookStorePermissions.Author.Update);
      CanDeleteAuthor = await AuthorizationService.IsGrantedAsync(AbpBookStorePermissions.Author.Delete);
    }

    protected void OpenCreateModal()
    {
      NewEntity = new CreateAuthorDto();
      CreateModal.Show();
    }

    protected void CloseCreateModalAsync()
    {
      CreateModal.Hide();
    }

    protected void OpenEditModal(AuthorDto author)
    {
      EditingAuthorId = author.Id;
      EditingEntity = ObjectMapper.Map<AuthorDto, UpdateAuthorDto>(author);
      EditModal.Show();
    }

    protected async Task DeleteAuthorAsync(AuthorDto author)
    {
      var confirmMessage = L["AuthorDeletionConfirmationMessage", author.Name];
      if (!await Message.Confirm(confirmMessage))
      {
        return;
      }

      await AuthorAppService.DeleteAsync(author.Id);
      await GetAuthorsAsync();
    }

    protected async Task GetAuthorsAsync()
    {
      var result = await AuthorAppService.GetListAsync(
          new GetAuthorListDto
          {
            MaxResultCount = PageSize,
            SkipCount = CurrentPage * PageSize,
            Sorting = CurrentSorting
          }
      );

      AuthorList = result.Items;
      TotalCount = (int)result.TotalCount;
    }

    protected async Task OnDataGridReadAsync(DataGridReadDataEventArgs<AuthorDto> e)
    {
      CurrentSorting = e.Columns
          .Where(c => c.Direction != SortDirection.None)
          .Select(c => c.Field + (c.Direction == SortDirection.Descending ? "DESC" : ""))
          .JoinAsString(",");
      CurrentPage = e.Page - 1;

      await GetAuthorsAsync();

      StateHasChanged();
    }

    protected void CloseEditModalAsync()
    {
      EditModal.Hide();
    }

    protected async Task CreateEntityAsync()
    {
      await AuthorAppService.CreateAsync(NewEntity);
      await GetAuthorsAsync();
      CreateModal.Hide();
    }

    protected async Task UpdateEntityAsync()
    {
      await AuthorAppService.UpdateAsync(EditingAuthorId, EditingEntity);
      await GetAuthorsAsync();
      EditModal.Hide();
    }
  }
}