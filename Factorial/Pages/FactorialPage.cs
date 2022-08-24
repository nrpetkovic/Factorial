using Factorial.Helpers;
using OpenQA.Selenium;

namespace Factorial.Pages;

public class FactorialPage
{
	private readonly IWebDriver _driver;
	
	public FactorialPage(IWebDriver driver)
	{
		_driver = driver;
	}

	private IWebElement H1Tag => _driver.FindElement(By.TagName("h1"));
	private IWebElement InputField => _driver.FindElement(By.TagName("input"));
	private IWebElement CalculateButton => _driver.FindElement(By.TagName("button"));
	private IWebElement ResultDiv => _driver.FindElement(By.Id("resultDiv"));

	public bool IsH1TextDisplayed()
	{
		return H1Tag.Displayed;
	}

	public string GetH1Text()
	{
		return H1Tag.Text;
	}

	public FactorialPage SetNumber(string s)
	{
		InputField.Clear();
		InputField.SendKeys(s);
		return this;
	}

	public string GetInputFieldStyle()
	{
		return InputField.GetAttribute("style");
	}

	public void Calculate()
	{
		CalculateButton.Click();
		_driver.WaitForAjax();
	}

	public string GetResult()
	{
		return ResultDiv.Text;
	}
}