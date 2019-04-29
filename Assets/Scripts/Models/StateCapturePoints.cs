// 
// THIS FILE HAS BEEN GENERATED AUTOMATICALLY
// DO NOT CHANGE IT MANUALLY UNLESS YOU KNOW WHAT YOU'RE DOING
// 
// GENERATED USING @colyseus/schema 0.4.29
// 

using Colyseus.Schema;

namespace Mem.Models {
	public class StateCapturePoints : Schema {
		[Type(0, "map", typeof(MapSchema<CapturePoint>))]
		public MapSchema<CapturePoint> capturePoints = new MapSchema<CapturePoint>();
	}
}
