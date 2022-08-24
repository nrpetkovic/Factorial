using FluentAssertions;
using NUnit.Framework;

namespace Factorial.Tests;

[TestFixture]
public class FactorialTestsUI : BaseTest
{
	
	[Test]
	public void OpenFactorialCalculator()
	{
		var factorialPage = OpenFactorialPage();

		factorialPage.IsH1TextDisplayed().Should().BeTrue();
		factorialPage.GetH1Text().Should().BeEquivalentTo("The greatest factorial calculator!");
	}

	[Test]
	[TestCase("0", "1")]
	[TestCase("1","1")]
	[TestCase("21","510909421")]
	[TestCase("22","6077e+21")]
	[TestCase("990","4.20968553")]
	[TestCase("991","4.17179837")]
	[TestCase("992","Infinity")]
	public void RunFactorial(string number, string result)
	{
		var factorialPage = OpenFactorialPage();
		
		factorialPage.SetNumber(number).Calculate();
		factorialPage.GetResult().Should().Contain(result);
	}

	[Test]
	[TestCase("")]
	[TestCase(" ")]
	[TestCase("0.5")]
	[TestCase("5e2")]
	[TestCase("Test")]
	[TestCase("%'\"<>")]
	[TestCase("-5")]
	public void TryToSubmitInvalidInputs(string input)
	{
		var factorialPage = OpenFactorialPage();
		factorialPage.SetNumber(input).Calculate();

		factorialPage.GetInputFieldStyle().Should().Contain("red");
		factorialPage.GetResult().Should().Contain("Please enter an integer");
	}
}