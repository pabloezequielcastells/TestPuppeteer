using PuppeteerSharp;

string outPut = Path.Combine(Environment.CurrentDirectory, "Pdfs", "test.pdf");
using var browserFetcher = new BrowserFetcher();
await browserFetcher.DownloadAsync();

await using var browser = await Puppeteer.LaunchAsync(
    new LaunchOptions()
    {
        Headless = true,
    });

await using var page = await browser.NewPageAsync();

// await page.GoToAsync("https://www.google.com");

await page.SetContentAsync("<div> test </div>");
await page.PdfAsync(outPut);

