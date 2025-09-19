using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Sprint0
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        
        //Interface declerations
        private ISprite currentSprite;
        private IController keyboardController;
        private IController mouseController;

        // Declaring sprite for text and variables for screen width and height
        private TextSprite infoText;
        int screenCenterWidth;
        int screenCenterHeight;

        // Controls what current sprite is
        public void SetCurrentSprite(ISprite sprite)
        {
            currentSprite = sprite;
        }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


        protected override void Initialize()
        {
            base.Initialize();
            this.IsMouseVisible = true;

        }

        // Textures and fonts loaded for sprites
        Texture2D staticLuigi;         
        Texture2D luigiRunSheet;       
        Texture2D deadLuigi;           
        SpriteFont font;               

        // Sprite instances
        private ISprite staticSprite;
        private ISprite animatedStaticSprite;
        private ISprite movingStaticSprite;
        private ISprite movingAnimatedSprite;

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
            //Load sprites
            staticLuigi = Content.Load<Texture2D>("staticLuigi");
            luigiRunSheet = Content.Load<Texture2D>("luigiRunning");
            deadLuigi = Content.Load<Texture2D>("deadLuigi");
            font = Content.Load<SpriteFont>("textFont");
            
            // Declare variables to find center of screen 
            screenCenterWidth = GraphicsDevice.Viewport.Width / 2;
            screenCenterHeight = GraphicsDevice.Viewport.Height / 2;

            // Declare screen bounds
            Rectangle screenBounds = GraphicsDevice.Viewport.Bounds;

            // Static non-animated (one frame) at fixed position
            staticSprite = new StaticSprite(staticLuigi, new Vector2(screenCenterWidth, screenCenterHeight));

            // Non-moving but animated (frames from sheet), same position
            animatedStaticSprite = new AnimatedStaticSprite(luigiRunSheet, frameWidth: luigiRunSheet.Width / 4, frameHeight: luigiRunSheet.Height, frames: 4, frameTime: 100, position: new Vector2(screenCenterWidth, screenCenterHeight));

            // Moving non-animated (floating up/down)
            movingStaticSprite = new MovingStaticSprite(deadLuigi, startPosition: new Vector2(screenCenterWidth, screenCenterHeight), amplitude: 30f, speed: 2f);

            // Moving & animated (moving left/right)
            movingAnimatedSprite = new MovingAnimatedSprite(luigiRunSheet, frameWidth: luigiRunSheet.Width / 4, frameHeight: luigiRunSheet.Height, frames: 4, frameTime: 100, startPosition: new Vector2(screenCenterWidth, screenCenterHeight), horizontalSpeed: 200f, screenBounds: screenBounds);

            // Info Text sprite
            infoText = new TextSprite(font, $"Credits\n Program made by: Logan Costa\n Sprites from: https://www.mariouniverse.com/sprites/", new Vector2(screenCenterWidth, screenCenterHeight*1.5f));

            // Setup commands and controllers
            var commands = new Dictionary<string, ICommand>
        {
            { "quit", new QuitCommand(this) },
            { "set1", new SetSpriteCommand(this, staticSprite) },
            { "set2", new SetSpriteCommand(this, animatedStaticSprite) },
            { "set3", new SetSpriteCommand(this, movingStaticSprite) },
            { "set4", new SetSpriteCommand(this, movingAnimatedSprite) }
        };

            keyboardController = new KeyboardController(commands);
            mouseController = new MouseController(commands, screenBounds);

            // Initial state: sprite 1
            SetCurrentSprite(staticSprite);
        }

        protected override void UnloadContent()
        {
            // Unload as needed
        }

        protected override void Update(GameTime gameTime)
        {

            // Update controllers 
            keyboardController.Update(gameTime);
            mouseController.Update(gameTime);

            // Update current sprite 
            currentSprite.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            // Draw current sprite 
            currentSprite.Draw(spriteBatch);

            // Draw info text at bottom
            infoText.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }

        public void Quit()
        {
            Exit();
        }
    }
}
