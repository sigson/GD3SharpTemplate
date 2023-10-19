using Godot;
using System;

public partial class DebuggerDelay : Node
{
    [Signal]
    public delegate void RunGameEventHandler();

    public event RunGameEventHandler RunGameEvent;
	[Export]
	public bool AutoRun;
    [Export]
    public string MainScene;
    public override void _Ready()
	{
#if !DEBUG
		AutoRun = true;
#endif
    }

	public override void _Process(float delta)
	{
		if(AutoRun)
		{
            GetTree().ChangeScene(MainScene);
            AutoRun = false;
        }
	}

    public void RunButton()
    {
        AutoRun = true;
    }
}
