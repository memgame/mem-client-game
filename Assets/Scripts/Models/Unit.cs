// 
// THIS FILE HAS BEEN GENERATED AUTOMATICALLY
// DO NOT CHANGE IT MANUALLY UNLESS YOU KNOW WHAT YOU'RE DOING
// 
// GENERATED USING @colyseus/schema 0.4.29
// 

using Colyseus.Schema;

namespace Mem.Models {
	public class Unit : BaseEntity {
		[Type(2, "string")]
		public string name = "";

		[Type(3, "ref", typeof(Position))]
		public Position position = new Position();

		[Type(4, "number")]
		public float moveSpeed = 0;

		[Type(5, "number")]
		public float rotation = 0;

		[Type(6, "number")]
		public float locomationAnimationSpeedPercent = 0;

		[Type(7, "boolean")]
		public bool isAlive = false;

		[Type(8, "ref", typeof(Bar))]
		public Bar health = new Bar();

		[Type(9, "ref", typeof(Bar))]
		public Bar energy = new Bar();

		[Type(10, "ref", typeof(Attributes))]
		public Attributes attributes = new Attributes();

		[Type(11, "ref", typeof(Weapon))]
		public Weapon mainHand = new Weapon();

		[Type(12, "ref", typeof(Weapon))]
		public Weapon offHand = new Weapon();

		[Type(13, "string")]
		public string team = "";
	}
}
