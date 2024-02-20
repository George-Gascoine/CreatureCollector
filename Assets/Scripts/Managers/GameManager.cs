using Godot;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using static Creature;

public partial class GameManager : Node2D
{
	[Export]
	public PackedScene baseCreature;

	public Biome currentBiome;

	[Export]
	public Json creatureJSON;
	public List<CreatureData> creatureList;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		currentBiome = (Biome)GetNode("/root/Biome");
		ReadJSON();
		CreatureData creatureData = creatureList.First(creature => creature.id == 0);
		AddCreature(creatureData);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void ReadJSON()
	{
        //Creature Data Parse
        JObject creatures = JObject.Parse(creatureJSON.Data.ToString());
        List<JToken> jCreatures = creatures["creature"].Children().ToList();
        creatureList = jCreatures.Select(creature => creature.ToObject<CreatureData>()).ToList();
    }

	public void AddCreature(CreatureData creature)
	{
		Creature addThis = (Creature)baseCreature.Instantiate();
		addThis.data = creature;
		currentBiome.AddChild(addThis);
		addThis.GlobalPosition = new Vector2(100, 100);
    }
}
