using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

public class KeyboardController : IController
{
    private KeyboardState previous;
    private readonly Dictionary<string, ICommand> commands;

    public KeyboardController(Dictionary<string, ICommand> commands)
    {
        this.commands = commands;
        previous = Keyboard.GetState();
    }

    public void Update(GameTime gameTime)
    {
        KeyboardState state = Keyboard.GetState();

        // Quit -> key 0
        if (IsKeyPressed(state, previous, Keys.D0) || IsKeyPressed(state, previous, Keys.NumPad0))
        {
            commands["quit"].Execute();
            previous = state;
            return;
        }

        // 1 -> static sprite 
        if (IsKeyPressed(state, previous, Keys.D1) || IsKeyPressed(state, previous, Keys.NumPad1))
        {
            commands["set1"].Execute();
        }

        // 2 -> animated static
        if (IsKeyPressed(state, previous, Keys.D2) || IsKeyPressed(state, previous, Keys.NumPad2))
        {
            commands["set2"].Execute();
        }

        // 3 -> moving non-animated
        if (IsKeyPressed(state, previous, Keys.D3) || IsKeyPressed(state, previous, Keys.NumPad3))
        {
            commands["set3"].Execute();
        }

        // 4 -> moving animated
        if (IsKeyPressed(state, previous, Keys.D4) || IsKeyPressed(state, previous, Keys.NumPad4))
        {
            commands["set4"].Execute();
        }

        previous = state;
    }

    private bool IsKeyPressed(KeyboardState now, KeyboardState prev, Keys key)
    {
        return now.IsKeyDown(key) && prev.IsKeyUp(key);
    }
}
