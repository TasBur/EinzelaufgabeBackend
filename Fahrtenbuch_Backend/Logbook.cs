using System;
namespace Fahrtenbuch_Backend
{
	//List of Journeys
	public class Logbook
	{
		
		public List<Journey> Journeys { get; set; }
		//Sum all distances
		public int DistanceTotal { get { return Journeys.Sum(x => x.Distance); } }
		public Logbook(List<Journey> journeys)
		{
			Journeys = journeys;
		}
	}
}
