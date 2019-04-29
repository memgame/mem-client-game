// 
// THIS FILE HAS BEEN GENERATED AUTOMATICALLY
// DO NOT CHANGE IT MANUALLY UNLESS YOU KNOW WHAT YOU'RE DOING
// 
// GENERATED USING @colyseus/schema 0.4.29
// 

using Colyseus.Schema;

namespace Mem.Models {
	public class Team : Schema {
		[Type(0, "string")]
		public string id = "";

		[Type(1, "string")]
		public string color = "";

		[Type(2, "number")]
		public float score = 0;
	}
}
