using Godot;
using System;

public partial class CreatureRoom : Node2D
{
	public GameManager gameManager;
	public Creature creature;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        gameManager = (GameManager)GetNode("/root/GameManager");
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
