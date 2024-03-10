# Gunner
> made with Godot 4.2

Exemple project to show how to create elements (bullets) and make them move in the mouse direction.

## The Key Points are

1. The scene `Gun` is not within the `Player`'s position, it is a little to the right. That position will move alongside the `Player` and after the bullet is Instanciated, the bullet will not hit the player.

2. The bullet moves only by the X axis, but the `Rotation` put the bullet in the right direction.
``` c#
bullet.LinearVelocity = bullet.Transform.X * bulletSpeed;
bullet.Rotation = GlobalRotation;
```

3. The `Bullet`'s position is the same as the `Gun`'s position, but the `Gun` is just a scene without colition properties.
``` c#
bullet.GlobalPosition = GlobalPosition;
```

4. I like the simplicity to calculate the Fire Rate
``` c#
float bps = 15f;
float fireRate = 1 / bps;
```

5. I also like this way to get the `Player`'s velocity:
``` c#
public override void _PhysicsProcess(double delta)
{
    Vector2 inputMovment = Input.GetVector("move_left", "move_right", "move_up", "move_down");
    this.Velocity = inputMovment * this.Speed * (float)delta;
    MoveAndSlide();
}
```