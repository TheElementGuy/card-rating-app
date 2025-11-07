using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using MathNet.Numerics.Statistics;

namespace CardRatingApp;

public class User {
	public ThreeElementList<int> Ratings0 {get; set;}
	public ThreeElementList<int> Ratings1 {get; set;}
	public ThreeElementList<int> Ratings2 {get; set;}
	public ThreeElementList<int> Ratings3 {get; set;}
	public ThreeElementList<int> Ratings4 {get; set;}
	public ThreeElementList<int> Ratings5 {get; set;}
	public ThreeElementList<int> Ratings6 {get; set;}
	public ThreeElementList<int> Ratings7 {get; set;}
	public ThreeElementList<int> Ratings8 {get; set;}
	public ThreeElementList<int> Ratings9 {get; set;}

	public double Mean {get; set;}
	public double StandardDeviation {get; set;}

	public string Username {get; set;}

	public User(string name) {
		Username = name;
		Mean = 5;
		StandardDeviation = 1;

		Ratings0 = new ThreeElementList<int>();
		Ratings1 = new ThreeElementList<int>();
		Ratings2 = new ThreeElementList<int>();
		Ratings3 = new ThreeElementList<int>();
		Ratings4 = new ThreeElementList<int>();
		Ratings5 = new ThreeElementList<int>();
		Ratings6 = new ThreeElementList<int>();
		Ratings7 = new ThreeElementList<int>();
		Ratings8 = new ThreeElementList<int>();
		Ratings9 = new ThreeElementList<int>();
	}

	public User() {
		Username = "jrand";
		Mean = 5;
		StandardDeviation = 1;

		Ratings0 = new ThreeElementList<int>();
		Ratings1 = new ThreeElementList<int>();
		Ratings2 = new ThreeElementList<int>();
		Ratings3 = new ThreeElementList<int>();
		Ratings4 = new ThreeElementList<int>();
		Ratings5 = new ThreeElementList<int>();
		Ratings6 = new ThreeElementList<int>();
		Ratings7 = new ThreeElementList<int>();
		Ratings8 = new ThreeElementList<int>();
		Ratings9 = new ThreeElementList<int>();
	}

	public double GetMean() {
		return Mean;
	}

	public double GetStandardDeviation() {
		return StandardDeviation;
	}

	public List<List<int>> GetRatings() {
		return new List<List<int>> {
			Ratings0.AsList(), Ratings1.AsList(), Ratings2.AsList(), Ratings3.AsList(), Ratings4.AsList(),
			Ratings5.AsList(), Ratings6.AsList(), Ratings7.AsList(), Ratings8.AsList(), Ratings9.AsList()
		};
	}

	public List<int> GetRatingsAt(int index) {
		return GetRatings()[index];
	}

	public double CalculateMean() {
		Mean = Util.Unwrap(GetRatings()).Average();
		return GetMean();
	}

	public double CalculateStandardDeviation() {
		StandardDeviation = ArrayStatistics.StandardDeviation(Util.Unwrap(GetRatings()).ToArray());
		return GetStandardDeviation();
	}

	public void WriteToFile(StreamWriter output) {
		String toWrite = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
		output.Write(toWrite);
	}

	public void FillFromFile(StreamReader input) {
		String fromFile = input.ReadToEnd();
		User? toCopy = JsonSerializer.Deserialize<User>(fromFile);
		if (toCopy is not null) {
			this.Copy(toCopy);
		} else {
			throw new FileNotFoundException("Could not find file: " + (input.BaseStream as FileStream)?.Name);
		}
	}

	public void Copy(User toCopy) {
		this.Username = toCopy.Username;
		this.Mean = toCopy.Mean;
		this.StandardDeviation = toCopy.StandardDeviation;
		this.Ratings0 = toCopy.Ratings0;
		this.Ratings1 = toCopy.Ratings1;
		this.Ratings2 = toCopy.Ratings2;
		this.Ratings3 = toCopy.Ratings3;
		this.Ratings4 = toCopy.Ratings4;
		this.Ratings5 = toCopy.Ratings5;
		this.Ratings6 = toCopy.Ratings6;
		this.Ratings7 = toCopy.Ratings7;
		this.Ratings8 = toCopy.Ratings8;
		this.Ratings9 = toCopy.Ratings9;
	}

	public void AddRating(int rating, int index) {
		switch (index) {
			case 0: {
				Ratings0.Add(rating);
				break;
			}
			case 1: {
				Ratings1.Add(rating);
				break;
			}
			case 2: {
				Ratings2.Add(rating);
				break;
			}
			case 3: {
				Ratings3.Add(rating);
				break;
			}
			case 4: {
				Ratings4.Add(rating);
				break;
			}
			case 5: {
				Ratings5.Add(rating);
				break;
			}
			case 6: {
				Ratings6.Add(rating);
				break;
			}
			case 7: {
				Ratings7.Add(rating);
				break;
			}
			case 8: {
				Ratings8.Add(rating);
				break;
			}
			case 9: {
				Ratings9.Add(rating);
				break;
			}
			default: {
				throw new IndexOutOfRangeException("Index is not OK for adding rating.");
			}
		}

		CalculateMean();
		CalculateStandardDeviation();
	}

	public List<double> GetNormalizedAveragedRatings() {
		CalculateMean();
		CalculateStandardDeviation();
		List<List<double>> toReturn = GetRatings().ConvertAll(Util.IntListToDoubleList);
		toReturn.ForEach((list => {list.ForEach(rating => {rating = (rating - Mean) / StandardDeviation;});}));
		return toReturn.ConvertAll(Util.AverageDoubleList);
	}

	public List<double> GetRecontextualizedNormalizedAveragedRatings() {
		List<double> toReturn = GetNormalizedAveragedRatings();
		toReturn.ForEach(d => {d = Util.Recontextualize(d);});
		return toReturn;
	}
	
}