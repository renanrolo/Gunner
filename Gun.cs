using Godot;
using System;

public partial class Gun : Node2D
{
	[Export]
	private PackedScene bulletScene;
	private float bulletSpeed = 500;
	private float bps = 15f;
	private float fireRate;
	private float timeUntilFire = 0f;
		
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		fireRate = 1 / bps;
	}

	public void Shot(double delta)
	{
		if(timeUntilFire > fireRate) {
			GoBullet();
			timeUntilFire = 0f;
		} else {
			timeUntilFire += (float)delta;
		}
	}
	
	public void GoBullet()
	{
		RigidBody2D bullet = bulletScene.Instantiate<RigidBody2D>();
		bullet.Rotation = GlobalRotation;
		bullet.GlobalPosition = GlobalPosition;
		bullet.LinearVelocity = bullet.Transform.X * bulletSpeed;
		GetTree().Root.AddChild(bullet);
	}
}
