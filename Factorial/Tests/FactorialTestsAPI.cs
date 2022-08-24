using System.Net;
using FluentAssertions;
using NUnit.Framework;
using RestSharp;

namespace Factorial.Tests;

[TestFixture]
public class FactorialAPI
{
	[Test]
	[TestCase("0", "1")]
	[TestCase("1","1")]
	[TestCase("5","120")]
	[TestCase(" 5","120")]
	[TestCase("05","120")]
	[TestCase("+5","120")]
	[TestCase("990","420968553")]
	[TestCase("991","417179837")]
	public void RunFactorial(string number, string result)
	{
		var client = new RestClient("https://qainterview.pythonanywhere.com/");
		var request = new RestRequest("factorial", Method.Post);
		request.AddParameter("number", number);

		var response = client.Execute(request);

		response.StatusCode.Should().Be(HttpStatusCode.OK);
		response.Content.Should().Contain(result);
	}
}