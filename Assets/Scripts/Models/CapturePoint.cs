// 
// THIS FILE HAS BEEN GENERATED AUTOMATICALLY
// DO NOT CHANGE IT MANUALLY UNLESS YOU KNOW WHAT YOU'RE DOING
// 

using Colyseus.Schema;

public class CapturePoint : Schema {
	[Type("string")]
	public string id = "";

	[Type("ref", typeof(Position))]
	public Position position = new Position();

	[Type("boolean")]
	public bool isSpawn = false;

	[Type("number")]
	public float radius = 0;

	[Type("string")]
	public string team = "";

	[Type("number")]
	public float takenTo = 0;

	[Type("number")]
	public float scorePoints = 0;
}

