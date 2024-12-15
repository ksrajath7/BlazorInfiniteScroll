# Blazor Infinite Scroll

Blazor Infinite Scroll is a Blazor component that provides an easy-to-use infinite scroll functionality. It triggers events when the user scrolls to the end of a content container, allowing you to load more content dynamically.

## Features

- Supports infinite scrolling for any Blazor component.
- Allows you to define when to trigger loading more data.
- Built-in support for scroll detection using `IntersectionObserver` and `scroll` events.
- Easy integration into your Blazor application.

## Installation

To install the Blazor Infinite Scroll package, follow these steps:

1. **Install the NuGet Package**

   You can add the package to your Blazor project by running the following command in your project directory:

   ```cmd
   dotnet add package BlazorInfiniteScroll

2. **Usage**
```razor
@* Example with normal list of items *@
<InfiniteScroll 
    ClassName="custom-scroll" 
    Style="height:400px;" 
    ObserverId="observer1" 
    ScrollBoxId="scrollBox1" 
    HasAnythingExistToLoadMore="true" 
    IsLoadingMore="false" 
    IsInfiniteLoadingNeeded="true" 
    OnEndReached="HandleEndReached">
      @foreach(var item in YourList){
    
      }
    <div id="observer1"></div>
</InfiniteScroll>

@* Example with virtualized list of items *@
<InfiniteScroll 
    ClassName="custom-scroll" 
    Style="height:400px;" 
    ObserverId="observer2" 
    ScrollBoxId="scrollBox2" 
    HasAnythingExistToLoadMore="true" 
    IsLoadingMore="false" 
    IsInfiniteLoadingNeeded="true" 
    OnEndReached="HandleEndReached">
   <Virtualize Items="YourList" Context="item">

   </Virtualize>
   <div id="observer2"></div>
</InfiniteScroll>
@code {
    private async Task HandleEndReached(bool isVisible)
    {
        if (isVisible)
        {
            // Load more content
        }
    }
}
