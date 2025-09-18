using System.Collections.Generic;
using System.Windows.Input;
using Microsoft.Xna.Framework.Input;

namespace gameProject
{
    public class KeyboardController : IController
    {
        private Dictionary<Keys, ICommand> controllerMappings;
        private ICommand quitCommand;
        private ICommand selectStaticSpriteCommand;
        private ICommand selectStaticMovingSpriteCommand;
        private ICommand selectAnimatedSpriteCommand;
        private ICommand selectAnimatedMovingSpriteCommand;


        public KeyboardController(Game1 game1)
        {
            quitCommand = new QuitCommand(game1);
            selectStaticSpriteCommand = new SelectStaticSpriteCommand(game1);
            selectStaticMovingSpriteCommand = new SelectStaticMovingSpriteCommand(game1);
            selectAnimatedSpriteCommand = new SelectAnimatedSpriteCommand(game1);
            selectAnimatedMovingSpriteCommand = new SelectAnimatedMovingSpriteCommand(game1);


            controllerMappings = new Dictionary<Keys, ICommand>
            {
                { Keys.D0, quitCommand },
                { Keys.D1, selectStaticSpriteCommand },
                { Keys.D2, selectAnimatedSpriteCommand },
                { Keys.D3, selectStaticMovingSpriteCommand },
                { Keys.D4, selectAnimatedMovingSpriteCommand },
            };
        }

        public void Update()
        {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

            foreach (Keys key in pressedKeys)
            {
                controllerMappings[key].Execute();
            }
        }
    }
}