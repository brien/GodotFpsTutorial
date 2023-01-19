using Godot;
using System;

public class BulletScript : Spatial
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    [Export]
    public float BULLET_SPEED = 70;
    public float BULLET_DAMAGE = 15;

    private const float KILL_TIMER = 4;
    private float timer = 0;

    private bool hit_something = false;

    private Area _area;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _area = GetNode<Area>("Area");
        _area.Connect("body_entered", this, "collided");
    }

    public override void _PhysicsProcess(float delta)
    {
        var forward_dir = GlobalTransform.basis.z.Normalized();
        GlobalTranslate(forward_dir * BULLET_SPEED * delta);

        timer += delta;

        if (timer >= KILL_TIMER)
            QueueFree();
    }
    
    public void Collided(Node body)
    {
        if (hit_something == false)
        {
            if (body is Player player)
            {
                // player.BulletHit(BULLET_DAMAGE, GlobalTransform);
            }
        }

        hit_something = true;
        QueueFree();
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
