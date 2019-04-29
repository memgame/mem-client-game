// 
// THIS FILE HAS BEEN GENERATED AUTOMATICALLY
// DO NOT CHANGE IT MANUALLY UNLESS YOU KNOW WHAT YOU'RE DOING
// 
// GENERATED USING @colyseus/schema 0.4.29
// 

using Colyseus.Schema;

namespace Mem.Models {
	public class StateTeams : Schema {
		[Type(0, "map", typeof(MapSchema<Team>))]
		public MapSchema<Team> teams = new MapSchema<Team>();
	}
}
