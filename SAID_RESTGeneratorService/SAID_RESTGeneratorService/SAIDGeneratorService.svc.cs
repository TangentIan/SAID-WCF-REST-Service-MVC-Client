using SAID_RESTGeneratorService.App_Code;

namespace SAID_RESTGeneratorService
{
	public class SAIDGeneratorService : ISAIDGeneratorService
	{
		private SAIDNumberWorker IDNumberWorker = new SAIDNumberWorker();

		public SAIDGeneratorService()
		{
			this.IDNumberWorker = new SAIDNumberWorker();
		}
		public SAIDGeneratorResponse GenerateRandomSAIDNumber()
		{
			return this.IDNumberWorker.GenerateRandomSAIDNumber();
		}
		public SAIDGeneratorResponse ValidateSAIDNumber(string IDNumber)
		{
			return this.IDNumberWorker.ValidateSAIDNumber(IDNumber);
		}
	}
}
