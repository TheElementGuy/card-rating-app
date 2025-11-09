using System;
using System.Collections.Generic;
using System.IO;

namespace CardRatingApp;

public class CardTranslations {

	public static string GetTranslation(string original) {
		List<string> cards = new List<string>();

		using (StreamReader cardReader = new("cards.txt")) {
			string line;
			while ((line = cardReader.ReadLine()) != null) {
				cards.Add(line);
			}
		}
		
		List<string> translations = new List<string>();

		using (StreamReader cardReader = new("cardtrans.txt")) {
			string line;
			while ((line = cardReader.ReadLine()) != null) {
				translations.Add(line);
			}
		}

		return translations[cards.FindIndex((s => {return s.Equals(original);}))];
	}

}