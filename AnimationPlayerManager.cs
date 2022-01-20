using Godot;
using System;

public class AnimationPlayerManager : AnimationPlayer
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	// Structure -> Animation name :[Connecting Animation states]
	Godot.Collections.Dictionary<String, String[]> states = new Godot.Collections.Dictionary<String, String[]>() {
		{"Idle_unarmed", new String[] {"Knife_equip", "Pistol_equip", "Rifle_equip", "Idle_unarmed"} },
		{"Pistol_equip", new String[] {"Pistol_idle"} },
		{"Pistol_fire", new String[] {"Pistol_idle"} },
		{"Pistol_idle", new String[] {"Pistol_fire", "Pistol_reload", "Pistol_unequip", "Pistol_idle"} },
		{"Pistol_reload", new String[] {"Pistol_idle"} },
		{"Pistol_unequip", new String[] {"Idle_unarmed"} },

		{"Rifle_equip", new String[] {"Rifle_idle"} },
		{"Rifle_fire", new String[] {"Rifle_idle"} },
		{"Rifle_idle", new String[] {"Rifle_fire", "Rifle_reload", "Rifle_unequip", "Rifle_idle"} },
		{"Rifle_reload", new String[] {"Rifle_idle"} },
		{"Rifle_unequip", new String[] {"Idle_unarmed"} },

		{"Knife_equip", new String[] {"Knife_idle"} },
		{"Knife_fire", new String[] {"Knife_idle"} },
		{"Knife_idle", new String[] {"Knife_fire", "Knife_unequip", "Knife_idle"} },
		{"Knife_unequip", new String[] {"Idle_unarmed"} },
	};

	Godot.Collections.Dictionary<String, double>  animation_speeds = new Godot.Collections.Dictionary<String, double>() {
	{"Idle_unarmed", 1},

	{"Pistol_equip", 1.4},
	{"Pistol_fire", 1.8},
	{"Pistol_idle", 1},
	{"Pistol_reload", 1},
	{"Pistol_unequip", 1.4},

	{"Rifle_equip", 2},
	{"Rifle_fire", 6},
	{"Rifle_idle", 1},
	{"Rifle_reload", 1.45},
	{"Rifle_unequip", 2},

	{"Knife_equip", 1},
	{"Knife_fire", 1.35},
	{"Knife_idle", 1},
	{"Knife_unequip", 1}
};

	string currentState;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		SetAnimation("Idle_unarmed");
		
	}
	
	private bool SetAnimation(string animationName)
	{
		if (animationName == currentState)
		{
			GD.Print("AnimationPlayer_Manager.gd -- WARNING: animation is already ", animationName);
			return true;
		}
		
		if (HasAnimation(animationName))
		{
			if (currentState != null)
			{
				var possibleAnimations = states[currentState];
			}
		}
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
