using System.Collections.Generic;
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
}