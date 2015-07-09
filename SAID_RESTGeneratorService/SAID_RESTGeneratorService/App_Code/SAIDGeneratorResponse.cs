using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAID_RESTGeneratorService.App_Code
{
	public class SAIDGeneratorResponse
	{
		public bool Success  { get; set; }
		public string Message { get; set; }

		public SAIDGeneratorResponse() { }
		public SAIDGeneratorResponse(bool Success, string Message)
		{
			this.Success = Success;
			this.Message = Message;
		}
	}
}