using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SAID_RESTGeneratorService
{
	public class SAIDGeneratorService : ISAIDGeneratorService
	{
		public string GenerateRandomSAIDNumber()
		{
			throw new NotImplementedException();
		}
		public string ValidateSAIDNumber(string IDNumber)
		{
			throw new NotImplementedException();
		}
	}
}
