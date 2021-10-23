using BlazorYoutubeDl.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;

namespace BlazorYoutubeDl.Client.RouteViews
{
    public class AppRouteView : RouteView
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IAccountService AccountService { get; set; }

        protected override void Render(RenderTreeBuilder builder)
        {
            var authorize = Attribute.GetCustomAttribute(RouteData.PageType, typeof(AuthorizeAttribute)) != null;
            if (authorize && AccountService.User == null)
            {
                NavigationManager.NavigateTo($"login");
            }
            else
            {
                base.Render(builder);
            }
        }
    }
}
