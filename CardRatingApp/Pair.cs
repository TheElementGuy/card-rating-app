namespace CardRatingApp;

public class Pair<T, S> {

	public T First {get; set;}
	public S Second {get; set;}
	
	public Pair(T first, S second) {
		First = first;
		Second = second;
	}

}