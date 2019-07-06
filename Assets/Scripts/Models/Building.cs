// 
// THIS FILE HAS BEEN GENERATED AUTOMATICALLY
// DO NOT CHANGE IT MANUALLY UNLESS YOU KNOW WHAT YOU'RE DOING
// 
// GENERATED USING @colyseus/schema 0.4.29
// 

using Colyseus.Schema;

namespace Mem.Models {
	public class Building : BaseEntity {
		[Type(2, "ref", typeof(Position))]
		public Position position = new Position();

		[Type(3, "number")]
		public float size = 0;

		[Type(4, "string")]
		public string buildingType = "";
	}
}
