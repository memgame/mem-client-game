// 
// THIS FILE HAS BEEN GENERATED AUTOMATICALLY
// DO NOT CHANGE IT MANUALLY UNLESS YOU KNOW WHAT YOU'RE DOING
// 
// GENERATED USING @colyseus/schema 0.4.29
// 

using Colyseus.Schema;

namespace Mem.Models {
	public class StateRoot : Schema {
		[Type(0, "ref", typeof(StateUnits))]
		public StateUnits stateUnits = new StateUnits();

		[Type(1, "ref", typeof(StatePlayers))]
		public StatePlayers statePlayers = new StatePlayers();

		[Type(2, "ref", typeof(StateTeams))]
		public StateTeams stateTeams = new StateTeams();

		[Type(3, "ref", typeof(StateCapturePoints))]
		public StateCapturePoints stateCapturePoints = new StateCapturePoints();

		[Type(4, "ref", typeof(StateCounter))]
		public StateCounter stateCounter = new StateCounter();
	}
}
