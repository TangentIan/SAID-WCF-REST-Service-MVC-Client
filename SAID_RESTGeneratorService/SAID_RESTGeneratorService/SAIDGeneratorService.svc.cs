using SAID_RESTGeneratorService.App_Code;
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
		private SAIDNumberWorker IDNumberWorker = new SAIDNumberWorker();

		public SAIDGeneratorService()
		{
			this.IDNumberWorker = new SAIDNumberWorker();
		}
		public SAIDGeneratorResponse GenerateRandomSAIDNumber()
		{
			throw new NotImplementedException(); 
		}
		public SAIDGeneratorResponse ValidateSAIDNumber(string IDNumber)
		{
			return this.IDNumberWorker.ValidateSAIDNumber(IDNumber);
		}
	}
}
