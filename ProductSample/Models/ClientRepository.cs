using System;
using System.Linq;
using System.Collections.Generic;
	
namespace ProductSample.Models
{   
	public  class ClientRepository : EFRepository<Client>, IClientRepository
	{

	}

	public  interface IClientRepository : IRepository<Client>
	{

	}
}