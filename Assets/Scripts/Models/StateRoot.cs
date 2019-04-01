// 
// THIS FILE HAS BEEN GENERATED AUTOMATICALLY
// DO NOT CHANGE IT MANUALLY UNLESS YOU KNOW WHAT YOU'RE DOING
// 

using Colyseus.Schema;

public class StateRoot : Schema {
	[Type("ref", typeof(StatePlayers))]
	public StatePlayers statePlayers = new StatePlayers();

	[Type("ref", typeof(StateTeams))]
	public StateTeams stateTeams = new StateTeams();

	[Type("ref", typeof(StateCapturePoints))]
	public StateCapturePoints stateCapturePoints = new StateCapturePoints();

	[Type("ref", typeof(StateCounter))]
	public StateCounter stateCounter = new StateCounter();
}

