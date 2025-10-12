using Microsoft.AspNetCore.Components;

namespace Workshops.Frontend.Components.Shared
{
    public partial class Loanding
    {
        [Parameter] public string? Label { get; set; }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            if (string.IsNullOrEmpty(Label))
            {
                Label = "Por favor espera...";
            }
        }
    }
}