using System;
using Microsoft.AspNetCore.Mvc.Testing;


namespace TestBackend
{
	public class IntegrationTest : IClassFixture<WebApplicationFactory<Program>>
	{
		private readonly HttpClient _client;
		private readonly WebApplicationFactory<Program> webApplicationFactory;

		public IntegrationTest()
		{
		}
	}
}

