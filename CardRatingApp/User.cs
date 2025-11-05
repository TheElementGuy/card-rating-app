using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using MathNet.Numerics;
using MathNet.Numerics.Statistics;

namespace CardRatingApp;

public class User {

	private List<int> Ratings0;
	private List<int> Ratings1;
	private List<int> Ratings2;
	private List<int> Ratings3;
	private List<int> Ratings4;
	private List<int> Ratings5;
	private List<int> Ratings6;
	private List<int> Ratings7;
	private List<int> Ratings8;
	private List<int> Ratings9;

	private double Mean;
	private double StandardDeviation;

	private string Username;

	public User(string name) {
		
		Username = name;
		Mean = 5;
		StandardDeviation = 1;

		Ratings0 = new List<int>();
		Ratings1 = new List<int>();
		Ratings2 = new List<int>();
		Ratings3 = new List<int>();
		Ratings4 = new List<int>();
		Ratings5 = new List<int>();
		Ratings6 = new List<int>();
		Ratings7 = new List<int>();
		Ratings8 = new List<int>();
		Ratings9 = new List<int>();
		
	}

	public double GetMean() {
		return Mean;
	}

	public double GetStandardDeviation() {
		return StandardDeviation;
	}

	public List<List<int>> GetRatings() {
		return new List<List<int>>{Ratings0, Ratings1, Ratings2, Ratings3, Ratings4, Ratings5, Ratings6, Ratings7, Ratings8, Ratings9};
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
		String toWrite = JsonSerializer.Serialize(this);
		output.Write(toWrite, new JsonSerializerOptions{WriteIndented = true});
	}

	public void FillFromFile(StreamReader input) {
		String fromFile = input.ReadToEnd();
		if (JsonSerializer.Deserialize<User>(fromFile) == null) {
			System.Console.WriteLine("Could not find file.");
			return;
		}
		this.Copy(JsonSerializer.Deserialize<User>(fromFile));
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
	
}