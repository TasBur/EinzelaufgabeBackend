using System;
namespace Fahrtenbuch_Backend.DTO
{
	public class JourneyDTO
	{
		            
        public string Driver { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int Distance { get; set; }

            public JourneyDTO(string driver, string description, DateTime start, DateTime end, int distance)
            {
                Driver = driver;
                Description = description;
                Start = start;
                End = end;
                Distance = distance;
            }
     }
}

