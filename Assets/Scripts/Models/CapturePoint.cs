// 
// THIS FILE HAS BEEN GENERATED AUTOMATICALLY
// DO NOT CHANGE IT MANUALLY UNLESS YOU KNOW WHAT YOU'RE DOING
// 
// GENERATED USING @colyseus/schema 0.4.29
// 

using Colyseus.Schema;

namespace Mem.Models {
	public class CapturePoint : Schema {
		[Type(0, "string")]
		public string id = "";

		[Type(1, "ref", typeof(Position))]
		public Position position = new Position();

		[Type(2, "boolean")]
		public bool isSpawn = false;

		[Type(3, "number")]
		public float radius = 0;

		[Type(4, "string")]
		public string team = "";

		[Type(5, "number")]
		public float takenTo = 0;

		[Type(6, "number")]
		public float scorePoints = 0;
	}
}
