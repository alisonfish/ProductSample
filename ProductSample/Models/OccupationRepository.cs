using System;
using System.Linq;
using System.Collections.Generic;
	
namespace ProductSample.Models
{   
	public  class OccupationRepository : EFRepository<Occupation>, IOccupationRepository
	{

	}

	public  interface IOccupationRepository : IRepository<Occupation>
	{

	}
}