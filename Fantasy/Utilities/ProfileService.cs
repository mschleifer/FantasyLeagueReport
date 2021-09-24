using Blazored.LocalStorage;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;


/// <remarks>https://jonhilton.net/blazor-tailwind-dark-mode-local-storage/</remarks>
public class ProfileService
{

    private readonly ILocalStorageService _localStorageService;
    private readonly IJSRuntime _jsRuntime;

    public event Action<bool> OnDarkModeChange;

    public ProfileService(ILocalStorageService localStorageService, IJSRuntime jsRuntime)
    {
        _localStorageService = localStorageService;
        _jsRuntime = jsRuntime;
    }

    public async Task ToggleDarkMode()
    {
        var newDarkModeSetting = !(await GetDarkMode());
        await _localStorageService.SetItemAsync("darkMode", newDarkModeSetting);

        OnDarkModeChange?.Invoke(newDarkModeSetting);
    }

    public async Task<bool> GetDarkMode()
    {
        // if they've already specified their preferences explicitly, use them
        if (await _localStorageService.ContainKeyAsync("darkMode"))
        {
            return await _localStorageService.GetItemAsync<bool>("darkMode");
        }

        // else default to OS settings...
        var prefersDarkMode = await _jsRuntime.InvokeAsync<bool>("prefersDarkMode");

        return prefersDarkMode;

    }
}