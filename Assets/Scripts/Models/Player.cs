// 
// THIS FILE HAS BEEN GENERATED AUTOMATICALLY
// DO NOT CHANGE IT MANUALLY UNLESS YOU KNOW WHAT YOU'RE DOING
// 
// GENERATED USING @colyseus/schema 0.4.29
// 

using Colyseus.Schema;

namespace Mem.Models {
	public class Player : Schema {
		[Type(0, "string")]
		public string id = "";

		[Type(1, "string")]
		public string name = "";

		[Type(2, "string")]
		public string team = "";

		[Type(3, "string")]
		public string unitId = "";
	}
}
