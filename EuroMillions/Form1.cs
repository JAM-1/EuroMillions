using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace EuroMillions
{
    public partial class Form1 : Form
    {
		public Form1()
        {
            InitializeComponent();
			this.Text = "EuroMillions";
		}

		#region EuroMillions2

		// Check for Duplicates after Input and Click
		private bool CheckForDuplicates()
		{
			bool reset = false;
			bool complete = false;
			if 
			(
				(textBox1.Text != null) && (textBox1.Text != textBox2.Text) && (textBox1.Text != textBox3.Text) && (textBox1.Text != textBox4.Text) && (textBox1.Text != textBox5.Text)
				&& (textBox2.Text != null) && (textBox2.Text != textBox3.Text) && (textBox2.Text != textBox4.Text) && (textBox2.Text != textBox5.Text)
				&& (textBox3.Text != null) && (textBox3.Text != textBox4.Text) && (textBox3.Text != textBox5.Text)
				&& (textBox4.Text != null) && (textBox4.Text != textBox5.Text)
				&& textBox5.Text != null
				&& (textBox7.Text != null) && (textBox7.Text != textBox8.Text)
				&& textBox8.Text != null)
			{
				return true;
			}
            else
            {
                MessageBox.Show($"Duplicate values found");
                return false;
            }
		}

        private void BtnCheckEuroMillionsNumbers_Click(object sender, EventArgs e)
        {
			if (CheckForDuplicates())
			{
                CompareEuroMillionsInputs(GetEuroMillionsNumbers(), GetEuroMillionsResults(GetListOfEuroMillionYears()));
            }
			else
			{
                GetEuroMillionsNumbers();
			}
        }

		// Get User Input
		private List<string> GetEuroMillionsNumbers()
		{
			List<string> userNumbers = new List<string>();
			List<string> userHotPicks = new List<string>();
			bool reset = false;
			bool complete = false;
			while (complete == false)
            {
				string numberOne = textBox1.Text;
				userNumbers.Add(DoubleDigit(numberOne));

				string numberTwo = textBox2.Text;
				userNumbers.Add(DoubleDigit(numberTwo));
                
				string numberThree = textBox3.Text;
                userNumbers.Add(DoubleDigit(numberThree));

				string numberFour = textBox4.Text;
                userNumbers.Add(DoubleDigit(numberFour));

				string numberFive = textBox5.Text;
                userNumbers.Add(DoubleDigit(numberFive));

				string hotpickOne = textBox7.Text;
                userHotPicks.Add(DoubleDigit(hotpickOne));

				string hotpickTwo = textBox8.Text;
                userHotPicks.Add(DoubleDigit(hotpickTwo));

				userNumbers.Sort();
				userHotPicks.Sort();

				foreach (string hotpick in userHotPicks)
				{
					userNumbers.Add(hotpick);
				}

				if (reset != true)
                {
		           complete = true;
                }
			}

			return userNumbers;
		}

		// Get List of Years EuroMillions has been active
		private static List<string> GetListOfEuroMillionYears()
		{
			List<string> euroMillionYearsActive = new List<string>();

			HtmlWeb web = new HtmlWeb();
			HtmlAgilityPack.HtmlDocument doc = web.Load($"https://www.lottery.co.uk/euromillions/results/archive-2004");

			HtmlNodeCollection yearsActive = doc.DocumentNode.SelectNodes("//a[contains(@title,'EuroMillions results')]");

			foreach (HtmlNode year in yearsActive)
			{
				euroMillionYearsActive.Add(year.InnerText.ToString());
			}

			return euroMillionYearsActive;
		}

		// Get Results for every draw for the year given
		private static List<List<string>> GetEuroMillionsResultsPerYear(string euroMillionsSingleYear)
		{
			List<string> singleResult = new List<string>();
			List<List<string>> yearlyResults = new List<List<string>>();

			HtmlWeb web = new HtmlWeb();
			HtmlAgilityPack.HtmlDocument doc = web.Load($"https://www.lottery.co.uk/euromillions/results/archive-{euroMillionsSingleYear}");

			HtmlNodeCollection resultsDate = doc.DocumentNode.SelectNodes("//tr/td[1]");
			HtmlNodeCollection resultsNumbers = doc.DocumentNode.SelectNodes("//tr/td[2]");

			int i = 0;
			foreach (var date in resultsDate)
			{
				int ii = 0;
				singleResult.Add(date.InnerText);
				string[] cleanNumbers = Regex.Split(resultsNumbers[i].InnerText, @"(\d+)");

				foreach (string number in cleanNumbers)
				{

					if (ii % 2 != 0)
					{
						singleResult.Add(DoubleDigit(number));
					}
					ii++;
				}
				i++;

				// Add yearly results to File
				System.IO.File.AppendAllLines(@"C:\Users\Public\TestFolder\EuroMillions.txt", singleResult);

				yearlyResults.Add(singleResult);
				singleResult = new List<string>();
			}

			return yearlyResults;
		}
		
		// Get Results for every draw for every year active
		private static List<List<List<string>>> GetEuroMillionsResults(List<string> euroMillionsYearsActive)
		{
			List<List<List<string>>> completeEuroMillionsResults = new List<List<List<string>>>();
			System.IO.File.WriteAllText(@"C:\Users\Public\TestFolder\EuroMillions.txt", string.Empty);

			foreach (string year in euroMillionsYearsActive)
			{
				completeEuroMillionsResults.Add(GetEuroMillionsResultsPerYear(year));
			}

			return completeEuroMillionsResults;
		}

		// Compare Inputs
		private bool CompareEuroMillionsInputs(List<string> userNumbers, List<List<List<string>>> completeEuroMillionsResults)
        {
			string closestMatch = null;
			int highestNumber = 0;

			foreach (List<List<string>> yearResults in completeEuroMillionsResults)
            {
				foreach (List<string> individualDraw in yearResults)
                {
					int numberFound = 0;
					int hotPickFound = 0;

					// Check the HotPick Results
					for (int hotPickLoop = 6; hotPickLoop <= 7; hotPickLoop++)
					{
						if (individualDraw[hotPickLoop].Equals(userNumbers[hotPickLoop - 1]))
						{
							hotPickFound++;
						}
					}

					// Check the EuroMilliions main numbers
					for (int euroMainNumbers = 1; euroMainNumbers <= 5; euroMainNumbers++)
                    {
						
                        if (individualDraw[euroMainNumbers].Equals(userNumbers[euroMainNumbers - 1]))
						{
							numberFound++;

							if (numberFound > highestNumber && numberFound <= 5 && hotPickFound <=2)
							{
								highestNumber = numberFound;
								if (hotPickFound > 0)
								{
									closestMatch = $"The closest you came to a win was on {individualDraw[0]} with {highestNumber} matching numbers and {hotPickFound} hotpick(s)";
								}
                                else
                                {
									closestMatch = $"The closest you came to a win was on {individualDraw[0]} with {highestNumber} matching numbers";
								}
							}

							if (numberFound == 5 && hotPickFound == 2)
                            {
								System.IO.File.WriteAllText(@"C:\Users\Public\TestFolder\EuroMillionsResult.txt", individualDraw[0].ToString());
								MessageBox.Show($"These numbers won the EuroMillions on {individualDraw[0]}");
								return true;
							}
						}
                    }

					hotPickFound = 0;
					numberFound = 0;
				}
            }

			MessageBox.Show($"These numbers have never won the EuroMillions. {closestMatch}");
			return false;
		}

		// Validate the User Input Numbers
		private void TextBoxValidatingEuroMillionsNumbers(object sender, CancelEventArgs e)
		{
			List<string> selectedNumbers = new List<string>();

			TextBox tbValue = sender as TextBox;
				if (string.IsNullOrWhiteSpace(tbValue.Text) || Int32.Parse(tbValue.Text) < 1 || Int32.Parse(tbValue.Text) > 50)
				{
					e.Cancel = true;
					textBox1.Focus();
					errorProvider1.SetError(textBox1, "");
					MessageBox.Show("Number box cannot be left blank, less than 1 or greater than 50 or previously entered");
				}
				else
				{
					selectedNumbers.Add(tbValue.Text);
					e.Cancel = false;
					errorProvider1.SetError(textBox1, "");
				}
			
		}

		// Validate the User Input HotPicks
		private void TextBoxValidatingEuroMillionsHotPicks(object sender, CancelEventArgs e)
		{
			TextBox tbValue = sender as TextBox;
			if (string.IsNullOrWhiteSpace(tbValue.Text) || Int32.Parse(tbValue.Text) < 1 || Int32.Parse(tbValue.Text) > 12)
			{
				e.Cancel = true;
				textBox1.Focus();
				errorProvider1.SetError(textBox1, "");
				MessageBox.Show("HotPick box cannot be left blank, less than 1 or greater than 12");
			}
			else
			{
				e.Cancel = false;
				errorProvider1.SetError(textBox1, "");
			}
		}

		// Pad any single digit number (User input or Draw numbers) to a double digit
		private static string DoubleDigit(string number)
		{
			string newNumber = null;

			if (number.Length < 2)
			{
				newNumber = number.PadLeft(2, '0');
			}
			else
			{
				newNumber = number;
			}

			return newNumber;
		}

		// Clear all Text Boxes
        private void BtnClearNumbers_Click(object sender, EventArgs e)
        {
			Action<Control.ControlCollection> func = null;

			func = (controls) =>
			{
				foreach (Control control in controls)
					if (control is TextBox)
						(control as TextBox).Clear();
					else
						func(control.Controls);
			};

			func(Controls);
		}

		private void BtnGenerateDraws_Click(object sender, EventArgs e)
		{
			Random r = new Random();
			if (textBox6.Text != null)
			{
				// SetUp - create Dictionaries
				// Create Dictionary for Numbers drawn
				Dictionary<int, int> genNumbersDictionary = new Dictionary<int, int>();
				{
					for (int i = 1; i < 51; i++)
					{
						genNumbersDictionary.Add(i, 0);
					}
				}

				// Create Dictionary for BonusBall drawn
				Dictionary<int, int> genBonusballDictionary = new Dictionary<int, int>();
				{
					for (int i = 1; i < 13; i++)
					{
						genBonusballDictionary.Add(i, 0);
					}
				}

				int drawnNumberIndex;
				int drawnHotPickIndex;
				int drawnNumber;
				int drawnHotPick;

				long numberofDraws = long.Parse(textBox6.Text);
				// Gen Draws using TextBox.7 Int
				for (int i = 1; i < (numberofDraws * 12 * 4); i++)
				{

					List<int> avaliableNumbers = new List<int>();
					{
						for (int ii = 1; ii < 51; ii++)
						{
							avaliableNumbers.Add(ii);
						}
					}

					List<int> avaliableHotPicks = new List<int>();
					{
						for (int ii = 1; ii < 13; ii++)
						{
							avaliableHotPicks.Add(ii);
						}
					}

					for (int draw = 1; draw <= 5; draw++)
					{
						//RandomNumberGenerator a = new RandomNumberGenerator;
						drawnNumberIndex = r.Next(avaliableNumbers.Count);
						drawnNumber = avaliableNumbers[drawnNumberIndex];
						genNumbersDictionary[drawnNumber] += 1;
						int lastNumber = avaliableNumbers[avaliableNumbers.Count - 1];
						avaliableNumbers.Insert(drawnNumberIndex, lastNumber);
						avaliableNumbers.RemoveAt(drawnNumberIndex + 1);
						avaliableNumbers.RemoveAt(avaliableNumbers.Count - 1);
						//avaliableNumbers = avaliableNumbers;
					}

					for (int hotpick = 0; hotpick < 2; hotpick++)
					{
						//Random r = new Random();
						drawnHotPickIndex = r.Next(avaliableHotPicks.Count);
						drawnHotPick = avaliableHotPicks[drawnHotPickIndex];
						genBonusballDictionary[drawnHotPick] += 1;
					}
				}

				//var sortedNumbers = from entry in genNumbersDictionary orderby entry.Value ascending select entry;
				//var sortedBonusBall = from entry in genBonusballDictionary orderby entry.Value ascending select entry;

				var sortedNumbersOne = genNumbersDictionary.OrderBy(x => x.Value);
				Dictionary<int, int> sortedNumbers = sortedNumbersOne.ToDictionary(t => t.Key, t => t.Value);

				var sortedBonusBallOne = genBonusballDictionary.OrderBy(x => x.Value);
				Dictionary<int, int> sortedBonusBall = sortedBonusBallOne.ToDictionary(t => t.Key, t => t.Value);

				List<string> genDraw = new List<string>();
				List<string> genHotPicks = new List<string>();
				for (int iii = 0; iii < 5; iii++)
                {
					genDraw.Add(sortedNumbers.Keys.ElementAt(iii).ToString());
					genDraw.Sort();
                }
				genDraw.Sort();
				for (int iv = 0; iv < 2; iv++)
                {
					genHotPicks.Add(sortedBonusBall.Keys.ElementAt(iv).ToString());
                }
				genHotPicks.Sort();
				foreach (string hotpick in genHotPicks)
                {
					genDraw.Add(hotpick);
                }

				if (CompareEuroMillionsInputs(genDraw, GetEuroMillionsResults(GetListOfEuroMillionYears())))
                {
					MessageBox.Show($"These numbers have been drawn the least amount of time in {(numberofDraws * 12 * 4)} Draws. " +
					$"{sortedNumbers.Keys.ElementAt(0)}," +
					$"{sortedNumbers.Keys.ElementAt(1)}," +
					$"{sortedNumbers.Keys.ElementAt(2)}," +
					$"{sortedNumbers.Keys.ElementAt(3)}," +
					$"{sortedNumbers.Keys.ElementAt(4)}");
					MessageBox.Show($"This bonusball has been drawn the least amount of time  {(numberofDraws * 12 * 4)} Draws. {sortedBonusBall.Keys.ElementAt(0)}, {sortedBonusBall.Keys.ElementAt(1)}");

				}
				else
                {
					MessageBox.Show($"Numbers : " +
						$"{sortedNumbers.Keys.ElementAt(0)}," +
						$"{sortedNumbers.Keys.ElementAt(1)}," +
						$"{sortedNumbers.Keys.ElementAt(2)}," +
						$"{sortedNumbers.Keys.ElementAt(3)}," +
						$"{sortedNumbers.Keys.ElementAt(4)}," +
						$"{sortedBonusBall.Keys.ElementAt(0)}," +
						$"{sortedBonusBall.Keys.ElementAt(1)}"
						);

					BtnGenerateDraws_Click(sender, e);
				}
			}
		}

        #endregion
    }
}
