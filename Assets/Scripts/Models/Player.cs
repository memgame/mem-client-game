// 
// THIS FILE HAS BEEN GENERATED AUTOMATICALLY
// DO NOT CHANGE IT MANUALLY UNLESS YOU KNOW WHAT YOU'RE DOING
// 

using Colyseus.Schema;

public class Player : Schema {
	[Type("string")]
	public string id = "";

	[Type("string")]
	public string name = "";

	[Type("string")]
	public string team = "";

	[Type("boolean")]
	public bool isAlive = false;

	[Type("ref", typeof(Position))]
	public Position position = new Position();

	[Type("number")]
	public float moveSpeed = 0;

	[Type("number")]
	public float rotation = 0;

	[Type("number")]
	public float locomationAnimationSpeedPercent = 0;

	[Type("number")]
	public float healthMax = 0;

	[Type("number")]
	public float health = 0;

	[Type("number")]
	public float energy = 0;

	[Type("number")]
	public float attackDamage = 0;

	[Type("number")]
	public float attackSpeed = 0;

	[Type("number")]
	public float attackSpeedPercent = 0;

	[Type("number")]
	public float critChancePercent = 0;

	[Type("number")]
	public float critBonusPercent = 0;

	[Type("number")]
	public float abilityPower = 0;

	[Type("number")]
	public float cooldownReductionPercent = 0;

	[Type("number")]
	public float armor = 0;

	[Type("number")]
	public float magicResistance = 0;

	[Type("number")]
	public float lifestealPercent = 0;

	[Type("number")]
	public float spellvampPercent = 0;
}

