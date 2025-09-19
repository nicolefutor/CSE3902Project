using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

public class MouseController : IController
{
    private MouseState previous;
    private readonly Dictionary<string, ICommand> commands;
    private readonly Rectangle screenBounds;

    public MouseController(Dictionary<string, ICommand> commands, Rectangle screenBounds)
    {
        this.commands = commands;
        this.screenBounds = screenBounds;
        previous = Mouse.GetState();
    }

    public void Update(GameTime gameTime)
    {
        MouseState ms = Mouse.GetState();

        // Right click -> quit (on pressed)
        if (ms.RightButton == ButtonState.Pressed && previous.RightButton == ButtonState.Released)
        {
            commands["quit"].Execute();
            previous = ms;
            return;
        }

        // Left click -> quadrant detection
        if (ms.LeftButton == ButtonState.Pressed && previous.LeftButton == ButtonState.Released)
        {
            Point p = ms.Position;
            bool top = p.Y < screenBounds.Height / 2;
            bool left = p.X < screenBounds.Width / 2;

            if (top && left) // Top left 
                commands["set1"].Execute();
            else if (top && !left) // Top right
                commands["set2"].Execute();
            else if (!top && left) // Bottom left
                commands["set3"].Execute();
            else // Bottom right
                commands["set4"].Execute();
        }

        previous = ms;
    }
}
