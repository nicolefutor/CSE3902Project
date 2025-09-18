using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace gameProject
{
    public class MouseController : IController
    {
        private Game1 game;
        private ICommand quitCommand;
        private ICommand selectStaticSpriteCommand;
        private ICommand selectStaticMovingSpriteCommand;
        private ICommand selectAnimatedSpriteCommand;
        private ICommand selectAnimatedMovingSpriteCommand;

        private MouseState previousMouseState;

        public MouseController(Game1 game)
        {
            this.game = game;

            quitCommand = new QuitCommand(game);
            selectStaticSpriteCommand = new SelectStaticSpriteCommand(game);
            selectStaticMovingSpriteCommand = new SelectStaticMovingSpriteCommand(game);
            selectAnimatedSpriteCommand = new SelectAnimatedSpriteCommand(game);
            selectAnimatedMovingSpriteCommand = new SelectAnimatedMovingSpriteCommand(game);

            previousMouseState = Mouse.GetState();
        }

        public void Update()
        {
            MouseState currentMouseState = Mouse.GetState();

            // Only trigger on fresh clicks (button pressed this frame, not held)
            bool leftClicked = currentMouseState.LeftButton == ButtonState.Pressed &&
                               previousMouseState.LeftButton == ButtonState.Released;
            bool rightClicked = currentMouseState.RightButton == ButtonState.Pressed &&
                                previousMouseState.RightButton == ButtonState.Released;

            if (leftClicked)
            {
                int screenWidth = game.GraphicsDevice.Viewport.Width;
                int screenHeight = game.GraphicsDevice.Viewport.Height;

                int mouseX = currentMouseState.X;
                int mouseY = currentMouseState.Y;

                bool topHalf = mouseY < screenHeight / 2;
                bool leftHalf = mouseX < screenWidth / 2;

                if (topHalf && leftHalf)
                {
                    // Top left quadrant
                    selectStaticSpriteCommand.Execute();
                }
                else if (topHalf && !leftHalf)
                {
                    // Top right quadrant
                    selectAnimatedSpriteCommand.Execute();
                }
                else if (!topHalf && leftHalf)
                {
                    // Bottom left quadrant
                    selectStaticMovingSpriteCommand.Execute();
                }
                else
                {
                    // Bottom right quadrant
                    selectAnimatedMovingSpriteCommand.Execute();
                }
            }

            if (rightClicked)
            {
                quitCommand.Execute();
            }

            previousMouseState = currentMouseState;
        }
    }
}
