using Microsoft.Playwright;
using System;
using System.Reflection.Metadata;

using var playwright = await Playwright.CreateAsync();
await using var browser = await playwright.Webkit.LaunchAsync();
var i = 0;
while (true)
{
    try
    {
        i++;
        await using var context = await browser.NewContextAsync();
        var page = await context.NewPageAsync();
        var response = await page.GotoAsync("https://www.baidu.com");
        Console.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}][{i}]response {response.Status}, browser context count:{browser.Contexts.Count}");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}
