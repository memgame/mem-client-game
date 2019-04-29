// 
// THIS FILE HAS BEEN GENERATED AUTOMATICALLY
// DO NOT CHANGE IT MANUALLY UNLESS YOU KNOW WHAT YOU'RE DOING
// 
// GENERATED USING @colyseus/schema 0.4.29
// 

using Colyseus.Schema;

namespace Mem.Models {
	public class StatePlayers : Schema {
		[Type(0, "map", typeof(MapSchema<Player>))]
		public MapSchema<Player> players = new MapSchema<Player>();
	}
}
