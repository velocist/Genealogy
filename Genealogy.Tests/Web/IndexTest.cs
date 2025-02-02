using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.MSTest;

namespace Genealogy.Tests.Web;

[TestClass]
public class IndexTest : PageTest
{

    [TestInitialize]
    public async Task TestInitialize()
    {
        await Context.Tracing.StartAsync(new()
        {
            Title = $"{TestContext.FullyQualifiedTestClassName}.{TestContext.TestName}",
            Screenshots = true,
            Snapshots = true,
            Sources = true
        });
    }

    [TestCleanup]
    public async Task TestCleanup()
    {
        await Context.Tracing.StopAsync(new()
        {
            Path = Path.Combine(
                Environment.CurrentDirectory,
                "playwright-traces",
                $"{TestContext.FullyQualifiedTestClassName}.{TestContext.TestName}.zip"
            )
        });
    }

	[TestMethod]
	public async Task HasTitle() {
		await Page.GotoAsync("https://playwright.dev");

		// Expect a title "to contain" a substring.
		await Expect(Page).ToHaveTitleAsync(new Regex("Playwright"));
	}

	[TestMethod]
	public async Task Test() {
		// Create a page.
		var page = await Context.NewPageAsync();

		// Navigate explicitly, similar to entering a URL in the browser.
		await page.GotoAsync("https://playwright.dev");
		// Fill an input.
		await page.Locator(".DocSearch .DocSearch-Button").FillAsync("query");

		// Navigate implicitly by clicking a link.
		await page.Locator("#submit").ClickAsync();
		// Expect a new url.
		Console.WriteLine(page.Url);
	}
}
