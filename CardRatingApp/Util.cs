using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CardRatingApp;

public class Util {
	public static string ToLines(List<string> strings) {
		StringBuilder toReturn = new StringBuilder();
		foreach (string s in strings) {
			toReturn.Append(s + "\n");
		}

		return toReturn.ToString();
	}

	public static List<int> Unwrap(List<List<int>> list) {
		List<int> toReturn = new List<int>();
		foreach (List<int> l in list) {
			foreach (int o in l) {
				toReturn.Add(o);
			}
		}

		return toReturn;
	}

	public static bool DoesFileExist(string fileName) {
		return File.Exists(fileName);
	}

	public static List<double> IntListToDoubleList(List<int> input) {
		return input.ConvertAll(Convert.ToDouble);
	}

	public static double AverageDoubleList(List<double> input) {
		return input.Average();
	}

	public static double Recontextualize(double initialRating) {
		return Math.Round(100 / (1 + Math.Pow(Math.E, -0.7 * initialRating)), 2);
	}
	
}