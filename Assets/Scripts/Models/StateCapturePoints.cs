// 
// THIS FILE HAS BEEN GENERATED AUTOMATICALLY
// DO NOT CHANGE IT MANUALLY UNLESS YOU KNOW WHAT YOU'RE DOING
// 

using Colyseus.Schema;

public class StateCapturePoints : Schema {
	[Type("map", typeof(MapSchema<CapturePoint>))]
	public MapSchema<CapturePoint> capturePoints = new MapSchema<CapturePoint>();
}

