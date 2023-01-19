using Godot;
using System;

public class WeaponPistol : Spatial
{
    // Declare member variables here.
    private const int DAMAGE = 15;

    private const string IDLE_ANIM_NAME = "Pistol_idle";
    private const string FIRE_ANIM_NAME = "Pistol_fire";

    private bool is_weapon_enabled = false;

    private PackedScene bullet_scene = (PackedScene)ResourceLoader.Load("Bullet_Scene.tscn");

    private Node player_node = null;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

    public void FireWeapon()
    {
        BulletScript clone = (BulletScript)bullet_scene.Instance();
        var scene_root = GetTree().Root.GetChildren()[0];
        AddChild(clone);

        clone.GlobalTransform = this.GlobalTransform;
        clone.Scale = new Vector3(4, 4, 4);
        clone.BULLET_DAMAGE = DAMAGE;
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
