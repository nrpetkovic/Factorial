using Factorial.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Factorial.Tests;

public class BaseTest
{
	private IWebDriver _driver;

	[SetUp]
	protected void TestSetup()
	{
	}

	protected FactorialPage OpenFactorialPage()
	{
		_driver = new ChromeDriver();
		_driver.Manage().Window.Maximize();
		_driver.Url = "https://qainterview.pythonanywhere.com";

		return new FactorialPage(_driver);
	}
	
	[TearDown]
	protected void Teardown()
	{
		_driver.Quit();
	}
}