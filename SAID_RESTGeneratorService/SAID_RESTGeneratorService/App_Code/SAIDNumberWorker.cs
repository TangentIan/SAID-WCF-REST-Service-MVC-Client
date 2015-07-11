using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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

		#region Generate Random SA ID Number.
		public SAIDGeneratorResponse GenerateRandomSAIDNumber()
		{
			SAIDGeneratorResponse GenerationResponse = new SAIDGeneratorResponse();

			int MaxRetries = 15; //Max allowed retries, allow retry, but prevent an infinite loop.
			string IDString = this.ConcatenateRandomIDParts();
			GenerationResponse = this.ValidateSAIDNumber(IDString);

			while (!GenerationResponse.Success && MaxRetries < 15)
			{
				IDString = this.ConcatenateRandomIDParts();
				GenerationResponse = this.ValidateSAIDNumber(IDString);
				MaxRetries += 1;
			}

			if (!GenerationResponse.Success) //Random SA ID Number generation failed.
			{
				GenerationResponse.Message = "Error - An unforseen error prevented a random SA ID number from being generated. Please try again.";
			}
			else
			{
				GenerationResponse.Message = IDString;
			}

			return GenerationResponse;
		}
		private string ConcatenateRandomIDParts()
		{
			Task<string>[] IDTaskArray = { 
													 Task<string>.Factory.StartNew(() => GenerateRandomDateOfBirth()),
                                        Task<string>.Factory.StartNew(() => GenerateRandomGenderSequence()), 
                                        Task<string>.Factory.StartNew(() => GenerateRandomCitizenship()),
                                        Task<string>.Factory.StartNew(() => GenerateRandomSubEndValue())
												  };

			Task.WaitAll(IDTaskArray); //Wait for all tasks to complete.

			string IDString = "";

			for (int i = 0; i < IDTaskArray.Length; i++) //Concatenate the randomly generated parts.
			{
				IDString += IDTaskArray[i].Result;
			}

			IDString += this.CalculateOddAndEvenNumberSums(IDString); //Calculate the 13th digit to balance the randomly generated ID.

			return IDString;
		}
		private string GenerateRandomDateOfBirth()
		{
			DateTime EndDate = System.DateTime.Today;
			DateTime StartDate = EndDate.AddYears(-99); //Only the last 100 years for a unique set of years.

			return StartDate.AddDays(this.RandomNumber.Next((EndDate - StartDate).Days + 1)).ToString("yyMMdd");
		}
		private string GenerateRandomGenderSequence()
		{
			return this.RandomNumber.Next(10000).ToString().PadLeft(4, '0'); //0 - 4999 is female, 5000 - 9999 is male.
		}
		private string GenerateRandomCitizenship()
		{
			return this.RandomNumber.Next(2).ToString(); //0 - RSA, 1 - Other.
		}
		private string GenerateRandomSubEndValue()
		{
			return this.RandomNumber.Next(10).ToString(); //Random number, no rules 0 - 9.
		}
		private string CalculateOddAndEvenNumberSums(string IDString)
		{
			try
			{
				int EvenNumbersSum = 0;
				int OddNumbersSum = 0;

				string EvenNumbers = "";
				List<int> OddNumbersList = new List<int>();

				for (int i = 0; i < IDString.Length; i++)
				{
					if ((i + 1) % 2 == 0)
					{
						EvenNumbers += IDString[i].ToString(); //Concatenate even numbers.
					}
					else
					{
						OddNumbersList.Add(int.Parse(IDString[i].ToString())); //Add uneven numbers to a list.
					}
				}

				OddNumbersSum = OddNumbersList.Sum(); //Summ all uneven numbers.
				EvenNumbers = (int.Parse(EvenNumbers) * 2).ToString(); //Multiply the concatenated even numbers result with 2.

				foreach (char chr in EvenNumbers)
				{
					EvenNumbersSum += int.Parse(chr.ToString()); //Get the sum of the individual numbers of the abovementioned result.
				}

				int SumTotal = (OddNumbersSum + EvenNumbersSum) % 10; //Get the MOD of the calculated uneven & even numbers result - to get the last/second digit.
				SumTotal = (10 - SumTotal) % 10; //Subtract the above result from 10 - get the MOD of the cum of the above - to get the last/second digit --> the control digit for the supplied 12 digits ID.

				return SumTotal.ToString();
			}
			catch
			{
				return null;
			}
		}
		#endregion

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
						ValidationResponse.Message = "Validated - The ID Number entered is correct.";
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