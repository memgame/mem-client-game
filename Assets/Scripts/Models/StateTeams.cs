// 
// THIS FILE HAS BEEN GENERATED AUTOMATICALLY
// DO NOT CHANGE IT MANUALLY UNLESS YOU KNOW WHAT YOU'RE DOING
// 

using Colyseus.Schema;

public class StateTeams : Schema {
	[Type("map", typeof(MapSchema<Team>))]
	public MapSchema<Team> teams = new MapSchema<Team>();
}

