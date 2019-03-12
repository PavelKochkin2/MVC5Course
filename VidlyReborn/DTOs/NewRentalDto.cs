using System.Collections.Generic;

namespace VidlyReborn.DTOs
{
    public class NewRentalDto
    {
        public int CustomerId { get; set; }
        public List<int> MovieIds { get; set; }
    }
}