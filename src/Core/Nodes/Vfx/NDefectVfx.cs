using Godot;
using MegaCrit.Sts2.Core.Bindings.MegaSpine;

public partial class NDefectVfx : Node
{
	private MegaSprite _megaSprite;

	private GpuParticles2D _sparkParticlesLeft;

	private GpuParticles2D _sparkParticlesRight;

	public override void _Ready()
	{
		_megaSprite = new MegaSprite(GetParent<Node2D>());
		_megaSprite.ConnectAnimationEvent(Callable.From<GodotObject, GodotObject, GodotObject, GodotObject>(OnAnimationEvent));
		_sparkParticlesLeft = GetNode<GpuParticles2D>("../SparkSlot/SparkLeftParticles");
		_sparkParticlesLeft.OneShot = true;
		_sparkParticlesLeft.Emitting = false;
		_sparkParticlesRight = GetNode<GpuParticles2D>("../SparkSlot/SparkRightParticles");
		_sparkParticlesRight.OneShot = true;
		_sparkParticlesRight.Emitting = false;
	}

	private void OnAnimationEvent(GodotObject _, GodotObject __, GodotObject ___, GodotObject spineEvent)
	{
		string eventName = new MegaEvent(spineEvent).GetData().GetEventName();
		if (!(eventName == "fire_sparks_left"))
		{
			if (eventName == "fire_sparks_right")
			{
				OnFireRightParticles();
			}
		}
		else
		{
			OnFireLeftParticles();
		}
	}

	private void OnFireLeftParticles()
	{
		_sparkParticlesLeft.Restart();
	}

	private void OnFireRightParticles()
	{
		_sparkParticlesRight.Restart();
	}
}
