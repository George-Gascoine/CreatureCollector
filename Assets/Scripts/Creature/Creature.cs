using Godot;
using System;
using static Godot.WebSocketPeer;

public partial class Creature : Node2D
{
    public GameManager gameManager;
    public class CreatureData
    {
        public int id;
        public string name;
        public string description;
        public string type;
        public string mood;
        public bool hungry;
        public string state;
        public int loyalty;
        public int[] gifts;
        public int[][] lootTable;
    }

    public CreatureData data;
    public Sprite2D sprite;
    public AnimationPlayer animPlayer;
    public int speed;
    public Timer creatureTimer;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        gameManager = (GameManager)GetNode("/root/GameManager");
        sprite = GetNode<Sprite2D>("Sprite2D");
        animPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
        creatureTimer = GetNode<Timer>("CreatureTimer");
        CreatureSetup();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {

    }

    public void OnInputEvent(Node viewport, InputEvent @event, int shapeIdx)
    {
        if (@event is InputEventMouseButton eventMouseButton && eventMouseButton.ButtonIndex == MouseButton.Left && eventMouseButton.Pressed)
        {
            GD.Print("CLICK");
            StateChange("Happy");
        }
    }

    public void CreatureSetup()
    {
        string spriteFolder = "res://Assets/Sprites/Creatures/";
        Texture2D spriteTexture = (Texture2D)ResourceLoader.Load(spriteFolder + data.name + ".png");
        sprite.Texture = spriteTexture;
        StateChange("Idle");
        creatureTimer.WaitTime = 5.0f;
        creatureTimer.Timeout += () =>
        {
            animPlayer.Play("Sleeping");
        };
        creatureTimer.Start();
    }

    public void StateChange(string state)
    {
        switch (state)
        {
            case "Idle":
                animPlayer.Play("Idle");
                break;
            case "Happy":
                animPlayer.Play("Happy");
                break;
        }
    }

    public void UpdateMood()
    {

    }

    public void UpdateHunger()
    {

    }
    public void UpdateLoyalty()
    {

    }
    public void GiftCheck()
    {

    }
    public void DropLoot()
    {

    }

    public void OnAnimationEnd(string animation)
    {
        switch (animation)
        {
            case "Idle":
                //animPlayer.Play("RESET");
                break;
            case "Happy":
                animPlayer.Play("Idle");
                break;
        }
    }
}
