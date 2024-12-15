using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorInfiniteScroll
{

    public partial class InfiniteScroll : IAsyncDisposable
    {
        [Parameter] public string ClassName { get; set; }
        [Parameter] public string Style { get; set; }
        [Parameter] public string ObserverId { get; set; }
        [Parameter] public string ScrollBoxId { get; set; }
        [Parameter] public EventCallback<bool> OnEndReached { get; set; }
        [Parameter] public bool HasAnythingExistToLoadMore { get; set; }
        [Parameter] public bool IsLoadingMore { get; set; }
        [Parameter] public bool IsInfiniteLoadingNeeded { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Inject] public IJSRuntime JSRuntime { get; set; }

        // This method is called whenever you want to trigger re-observing the element

        // This method is invoked whenever visibility changes, you can check conditions here
        [JSInvokable]
        public async Task HandleVisibilityChanged(bool isVisible)
        {
            // Check visibility and update the state to decide if re-observation is needed
            if (HasAnythingExistToLoadMore && !IsLoadingMore && isVisible)
            {
                await Task.Delay(500);
                await OnEndReached.InvokeAsync(isVisible);
            }

        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {

            if (firstRender)
            {
                if (IsInfiniteLoadingNeeded)
                {
                    await JSRuntime.InvokeVoidAsync("infiniteScroll.setupInfiniteScroll", ObserverId, ScrollBoxId, DotNetObjectReference.Create(this));
                }
            }
        }

        public async ValueTask DisposeAsync()
        {
            await JSRuntime.InvokeVoidAsync("infiniteScroll.stopObserving");
        }
    }
}
