using System.Collections.Generic;

namespace CardRatingApp;

public class ThreeElementList<T> {
	
	public List<T> Data {get; set;}
	
	public ThreeElementList() {
		Data = new List<T>();
	}

	public List<T> AsList() {
		return Data;
	}

	public void Add(T toAdd) {
		if (Data.Count >= 3) {
			Data.RemoveAt(0);
		}
		Data.Add(toAdd);
	}
	
}