using Godot;
using System;

public class Player : KinematicBody
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    [Export]
    public float Gravity = -24.8f;
    [Export]
    public float MaxSpeed = 20.0f;
    [Export]
    public float JumpSpeed = 18.0f;
    [Export]
    public float Accel = 4.5f;
    [Export]
    public float Deaccel = 16.0f;
    [Export]
    public float MaxSlopeAngle = 40.0f;
    [Export]
    public float MouseSensitivity = 0.05f;

    private Vector3 _vel = new Vector3();
    private Vector3 _dir = new Vector3();

    private Camera _camera;
    private Spatial _rotationHelper;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _camera = GetNode<Camera>("Rotation_Helper/Camera");
        _rotationHelper = GetNode<Spatial>("Rotation_Helper");

        Input.SetMouseMode(Input.MouseMode.Captured);
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
