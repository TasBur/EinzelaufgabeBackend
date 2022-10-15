using System;

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace Fahrtenbuch_Backend
{

    /*
	 * 
	 * 
	 * "driver": "Anna",
	"description": "Fahrt nach Innsbruck",
	"start": "2022-09-13T18:21:23Z",
	"end": "2022-09-13T20:35:05Z",
	"distance": 185,
	"id": 1

	*/
	public class Journey
	{
		public int Id { get; set; }
		//[Required]
		public string Driver { get; set; }
        //[Required]
        public string Description { get; set; }
		[Required]
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int Distance { get; set; }

		public Journey(string driver,string description, DateTime start, DateTime end, int distance)
		{
			Driver = driver;
			Description = description;
			Start = start;
			End = end;
			Distance = distance;
		}
		
	}
}
