using SAID_RESTGeneratorService.App_Code;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace SAID_RESTGeneratorService
{
	[ServiceContract]
	public interface ISAIDGeneratorService
	{
		[OperationContract]
		[WebGet(ResponseFormat = WebMessageFormat.Json)]
		SAIDGeneratorResponse GenerateRandomSAIDNumber();

		[OperationContract]
		[WebGet(UriTemplate = "ValidateSAIDNumber/{IDNumber}", ResponseFormat = WebMessageFormat.Json)]
		SAIDGeneratorResponse ValidateSAIDNumber(string IDNumber);
	}
}
