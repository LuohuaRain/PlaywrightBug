using Microsoft.Playwright;
using System;

using var playwright = await Playwright.CreateAsync();
await using var browser = await playwright.Webkit.LaunchAsync();
var i = 0;
while (true)
{
    i++;
    await using var context = await browser.NewContextAsync();
    var page = await context.NewPageAsync();
    var response = await page.GotoAsync("https://www.microsoft.com");
    Console.WriteLine($"[{i}]response {response.Status}, browser context count:{browser.Contexts.Count}");
}
