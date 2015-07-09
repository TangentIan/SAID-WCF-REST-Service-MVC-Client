using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SAID_RESTGeneratorService
{
	[ServiceContract]
	public interface ISAIDGeneratorService
	{
		[OperationContract]
		[WebGet(ResponseFormat = WebMessageFormat.Json)]
		string GenerateRandomSAIDNumber();

		[OperationContract]
		[WebGet(UriTemplate = "ValidateSAIDNumber/{IDNumber}", ResponseFormat = WebMessageFormat.Json)]
		string ValidateSAIDNumber(string IDNumber);
	}
}
