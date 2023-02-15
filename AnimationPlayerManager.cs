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

	Godot.Collections.Dictionary<String, float>  animation_speeds = new Godot.Collections.Dictionary<String, float>() {
	{"Idle_unarmed", 1},

	{"Pistol_equip", 1.4f},
	{"Pistol_fire", 1.8f},
	{"Pistol_idle", 1},
	{"Pistol_reload", 1},
	{"Pistol_unequip", 1.4f},

	{"Rifle_equip", 2},
	{"Rifle_fire", 6},
	{"Rifle_idle", 1},
	{"Rifle_reload", 1.45f},
	{"Rifle_unequip", 2},

	{"Knife_equip", 1},
	{"Knife_fire", 1.35f},
	{"Knife_idle", 1},
	{"Knife_unequip", 1}
};

	public string currentState;
	FuncRef callbackFunction;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		SetAnimation("Idle_unarmed");
		Connect("animation_finished", this, "animation_ended");
	}
	
	private bool SetAnimation(string animationName)
	{
		if (animationName == currentState)
		{
			GD.Print("AnimationPlayerManager.cs -- WARNING: animation is already ", animationName);
			return true;
		}
		
		if (HasAnimation(animationName))
		{
			if (currentState != null)
			{
				var possibleAnimations = states[currentState];

				if (Array.Exists(possibleAnimations, element => element == animationName))
				{
					currentState = animationName;
					Play(animationName, -1, animation_speeds[animationName]);
					return true;
				}
				else
				{
					GD.Print("AnimationPlayer_Manager.gd -- WARNING: Cannot change to ", animationName, " from ", currentState);
					return false;
				}
			}
			else
			{
				currentState = animationName;
				Play(animationName, -1, animation_speeds[animationName]);
				return true;
			}
		}
		return false;
	}

	void AnimationEnded(string animationName)
	{
		// UNARMED transitions
		if (currentState == "Idle_unarmed")
			return;
		// KNIFE transitions
		else if (currentState == "Knife_equip")
			SetAnimation("Knife_idle");
		else if (currentState == "Knife_idle")
			return;
		else if (currentState == "Knife_fire")
			SetAnimation("Knife_idle");
		else if (currentState == "Knife_unequip")
			SetAnimation("Idle_unarmed");
		// PISTOL transitions
		else if (currentState == "Pistol_equip")
			SetAnimation("Pistol_idle");
		else if (currentState == "Pistol_idle")
			return;
		else if (currentState == "Pistol_fire")
			SetAnimation("Pistol_idle");
		else if (currentState == "Pistol_unequip")
			SetAnimation("Idle_unarmed");
		else if (currentState == "Pistol_reload")
			SetAnimation("Pistol_idle");
		// RIFLE transitions
		else if (currentState == "Rifle_equip")
			SetAnimation("Rifle_idle");
		else if (currentState == "Rifle_idle")
			return;
		else if (currentState == "Rifle_fire")
			SetAnimation("Rifle_idle");
		else if (currentState == "Rifle_unequip")
			SetAnimation("Idle_unarmed");
		else if (currentState == "Rifle_reload")
			SetAnimation("Rifle_idle");
	}

	public void AnimationCallback()
	{
		if (callbackFunction == null)
			GD.Print("AnimationPlayer_Manager.gd -- WARNING: No callback function for the animation to call!");
		else
			callbackFunction.CallFunc();
	}


//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
