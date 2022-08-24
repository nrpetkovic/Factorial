using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Factorial.Helpers;

public static class WebDriverExtensions
{
	public static void WaitForAjax(this IWebDriver driver)
	{
		var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
		wait.Until(webDriver => (bool)((IJavaScriptExecutor)webDriver).
			ExecuteScript("return jQuery.active == 0"));
	}
}