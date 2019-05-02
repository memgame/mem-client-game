// 
// THIS FILE HAS BEEN GENERATED AUTOMATICALLY
// DO NOT CHANGE IT MANUALLY UNLESS YOU KNOW WHAT YOU'RE DOING
// 
// GENERATED USING @colyseus/schema 0.4.29
// 

using Colyseus.Schema;

namespace Mem.Models {
	public class Player : Schema {
		[Type(0, "string")]
		public string id = "";

		[Type(1, "string")]
		public string name = "";

		[Type(2, "string")]
		public string team = "";

		[Type(3, "boolean")]
		public bool isAlive = false;

		[Type(4, "ref", typeof(Position))]
		public Position position = new Position();

		[Type(5, "number")]
		public float moveSpeed = 0;

		[Type(6, "number")]
		public float rotation = 0;

		[Type(7, "number")]
		public float locomationAnimationSpeedPercent = 0;

		[Type(8, "number")]
		public float healthMax = 0;

		[Type(9, "number")]
		public float health = 0;

		[Type(10, "number")]
		public float energy = 0;

		[Type(11, "number")]
		public float energyMax = 0;

		[Type(12, "number")]
		public float attackRange = 0;

		[Type(13, "number")]
		public float attackDamage = 0;

		[Type(14, "number")]
		public float attackSpeed = 0;

		[Type(15, "number")]
		public float attackSpeedPercent = 0;

		[Type(16, "number")]
		public float critChancePercent = 0;

		[Type(17, "number")]
		public float critBonusPercent = 0;

		[Type(18, "number")]
		public float abilityPower = 0;

		[Type(19, "number")]
		public float cooldownReductionPercent = 0;

		[Type(20, "number")]
		public float armor = 0;

		[Type(21, "number")]
		public float magicResistance = 0;

		[Type(22, "number")]
		public float lifestealPercent = 0;

		[Type(23, "number")]
		public float spellvampPercent = 0;
	}
}
