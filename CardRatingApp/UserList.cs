using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace CardRatingApp;

public class UserList {
	
	public List<string> UserNames {get; set;}

	public UserList() {
		
	}

	public void FillFromFile() {
		using (StreamReader reader = new StreamReader("users.json")) {
			this.Copy(JsonSerializer.Deserialize<UserList>(reader.ReadToEnd()));
		}
	}

	public void Copy(UserList copyingFrom) {
		this.UserNames = copyingFrom.UserNames;
	}

	public void AddUser(string newUser) {
		UserNames.Add(newUser);
	}

	private void WriteToFile() {
		using (StreamWriter writer = new StreamWriter("users.json")) {
			writer.Write(JsonSerializer.Serialize(this));
		}
	}

	public List<User> GetUsers() {
		List<User> toReturn = new List<User>();
		foreach (string s in UserNames) {
			User toAdd = new User();
			using (StreamReader reader = new StreamReader(s + ".json")) {
				toAdd.FillFromFile(reader);
			}
			toReturn.Add(toAdd);
		}

		return toReturn;
	}
	
}