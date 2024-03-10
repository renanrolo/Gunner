using Godot;
using System;

public partial class Bullet : RigidBody2D
{
	private int Spped {get;set;} = 50;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Timer timer = GetNode<Timer>("BulletTimer");
		timer.Timeout += () => QueueFree();
	}
}
