using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BlazorYoutubeDl.Client.Shared
{
    public partial class LoginLayout
    {
        string[] images = { "img/winter.jpg", "img/winter2.png", "img/herbst2.jpg" };
        string img;
        Random random = new Random();

        protected async override Task OnInitializedAsync()
        {
            img = images[random.Next(0, images.Length - 1)];
            await Task.CompletedTask;
        }
    }
}
