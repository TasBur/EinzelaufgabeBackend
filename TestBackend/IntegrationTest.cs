using System;
using System.Net;
using System.Net.Http.Json;
using Fahrtenbuch_Backend;
using Microsoft.AspNetCore.Mvc.Testing;


namespace TestBackend
{
	public class IntegrationTest : IClassFixture<WebApplicationFactory<Program>>
	{
		private readonly HttpClient _client;
		private readonly WebApplicationFactory<Program> webApplicationFactory;

		public IntegrationTest(WebApplicationFactory<Program> factory)
		{
			webApplicationFactory = factory;
		}

		//[Fact]
		public async void GetJourneyOK()
		{
			var _client = webApplicationFactory.CreateClient();

			var response = await _client.GetAsync("/logbooks/journey");
			var res = await _client.GetFromJsonAsync<Logbook>("/logbooks/journey");

			Assert.Equal(HttpStatusCode.OK, response.StatusCode);

			
		}
		//[Fact]
		public async void PostEventCreated()
		{

            var j1 = new Journey("Burak", "Desc1", DateTime.Today, DateTime.Today.AddDays(1), 5);
            var respone = await _client.PostAsJsonAsync("/logbooks/journey",j1);

			Assert.Equal(HttpStatusCode.Created, respone.StatusCode);
		}
		//[Fact]
		public async void GetJourneysAsync()
		{
            var j1 = new Journey("Burak", "Desc1", DateTime.Today, DateTime.Today.AddDays(1), 5);
            var j2 = new Journey("Burak2", "Desc2", DateTime.Today, DateTime.Today.AddDays(1), 5);
            var j3 = new Journey("Burak3", "Desc3", DateTime.Today, DateTime.Today.AddDays(1), 5);
            var respone1 = await _client.PostAsJsonAsync("/logbooks/journey", j1);
            var respone2 = await _client.PostAsJsonAsync("/logbooks/journey", j2);
            var respone3 = await _client.PostAsJsonAsync("/logbooks/journey", j3);

			Assert.Equal(HttpStatusCode.Created, respone1.StatusCode);

			var getRes = await _client.GetAsync("/logbooks/journey");
			Assert.Equal(HttpStatusCode.OK, getRes.StatusCode);

        }
	}
}

