using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public const float Speed = 30000.0f;
	public Gun gun;

	public override void _Ready()
	{
		gun = GetNode<Gun>("Gun");
	}
	
	public override void _Process(double delta)
	{
		if(Input.IsActionPressed("click"))
		{
			gun.Shot(delta);
		}
	}
	
	public override void _PhysicsProcess(double delta)
	{
		LookAt(GetGlobalMousePosition());
		
		var inputMovment = Input.GetVector("move_left", "move_right", "move_up", "move_down");
		Velocity = inputMovment * Speed * (float)delta;
		MoveAndSlide();
	}
	
	public void Start(Vector2 position)
	{
		Position = position;
	}
}
