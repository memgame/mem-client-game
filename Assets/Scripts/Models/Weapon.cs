// 
// THIS FILE HAS BEEN GENERATED AUTOMATICALLY
// DO NOT CHANGE IT MANUALLY UNLESS YOU KNOW WHAT YOU'RE DOING
// 
// GENERATED USING @colyseus/schema 0.4.29
// 

using Colyseus.Schema;

namespace Mem.Models {
	public class Weapon : Schema {
		[Type(0, "string")]
		public string id = "";

		[Type(1, "string")]
		public string type = "";

		[Type(2, "string")]
		public string slot = "";

		[Type(3, "string")]
		public string combatStyle = "";

		[Type(4, "number")]
		public float attackRange = 0;

		[Type(5, "number")]
		public float attackSpeed = 0;
	}
}
