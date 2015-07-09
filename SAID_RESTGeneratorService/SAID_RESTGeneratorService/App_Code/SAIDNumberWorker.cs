using System;
using System.Collections.Generic;
using System.Linq; 
using System.Text.RegularExpressions;
using System.Web;

namespace SAID_RESTGeneratorService.App_Code
{
	public class SAIDNumberWorker
	{
		private static Regex SAIDNumberRegex = new Regex("^[0-9]{13}$");
		private Random RandomNumber = null;

		public SAIDNumberWorker()
		{
			this.RandomNumber = new Random((int)System.DateTime.Now.Ticks); //Will be used to randomly create the various sections of the ID Number.
		}

		#region Validate SA ID Number.
		public SAIDGeneratorResponse ValidateSAIDNumber(string IDNumber)
		{
			SAIDGeneratorResponse ValidationResponse = new SAIDGeneratorResponse();
			ValidationResponse.Success = false;

			if (IDNumber == null || IDNumber.Trim() == "") //Ensures an empty value was not received.
			{
				ValidationResponse.Message = "Invalid - Empty values are not allowed.";
			}
			else
			{
				IDNumber = IDNumber.Trim();

				if (!SAIDNumberWorker.SAIDNumberRegex.IsMatch(IDNumber)) //Ensures a 13 digit numerical value was received.
				{
					ValidationResponse.Message = "Invalid - Enter a 13 digit numerical only ID number.";
				}
				else //Validation passed.
				{
					if (this.ValidateIDControlDigit(IDNumber) != int.Parse(IDNumber[IDNumber.Length - 1].ToString())) //Checks if the last digit of the ID number matches the control digit.
					{
						ValidationResponse.Message = "Invalid - The ID Number entered is not valid.";
					}
					else
					{
						ValidationResponse.Success = true;
						ValidationResponse.Message = "Validated - The ID Number entered has been validated successfully.";
					}
				}
			}

			return ValidationResponse;
		}
		//The 13th digit validation functionality provided at: http://geekswithblogs.net/willemf/archive/2005/10/30/58561.aspx
		private int ValidateIDControlDigit(string IDNumber)
		{
			int d = -1;

			try
			{
				int a = 0;

				for (int i = 0; i < 6; i++)
				{
					a += int.Parse(IDNumber[2 * i].ToString());
				}

				int b = 0;

				for (int i = 0; i < 6; i++)
				{
					b = b * 10 + int.Parse(IDNumber[2 * i + 1].ToString());
				}

				b *= 2;

				int c = 0;

				do
				{
					c += b % 10;
					b = b / 10;
				}
				while (b > 0);

				c += a;
				d = 10 - (c % 10);

				if (d == 10) d = 0;
			}
			catch {/*ignore*/}

			return d;
		}
		#endregion
	}
}