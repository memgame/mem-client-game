// 
// THIS FILE HAS BEEN GENERATED AUTOMATICALLY
// DO NOT CHANGE IT MANUALLY UNLESS YOU KNOW WHAT YOU'RE DOING
// 
// GENERATED USING @colyseus/schema 0.4.29
// 

using Colyseus.Schema;

namespace Mem.Models {
	public class StateRoot : Schema {
		[Type(0, "ref", typeof(StatePlayers))]
		public StatePlayers statePlayers = new StatePlayers();

		[Type(1, "ref", typeof(StateTeams))]
		public StateTeams stateTeams = new StateTeams();

		[Type(2, "ref", typeof(StateCapturePoints))]
		public StateCapturePoints stateCapturePoints = new StateCapturePoints();

		[Type(3, "ref", typeof(StateCounter))]
		public StateCounter stateCounter = new StateCounter();
	}
}
