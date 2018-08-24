using System;
using Newtonsoft.Json;
using UnityEngine;

namespace AssemblyCSharp
{
	public class CardBuilder
	{
		public static Card Build(string id) {
			if (id.Length == 0)
				return null;
			string cardAsString = SimpleIO.Read (Application.persistentDataPath, id, ".json");
			Card card = JsonConvert.DeserializeObject<Card> (cardAsString);
			return card;
		}
	}
}

