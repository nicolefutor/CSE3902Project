using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace gameProject;

public class Game1 : Game
{
    private GraphicsDeviceManager graphics;
    // Sprite attibutes
    private SpriteBatch spriteBatch;
    private Texture2D SpriteSheet;

    private ISprite staticSprite;
    private ISprite staticMovingSprite;
    private ISprite animatedSprite;
    private ISprite animatedMovingSprite;
    private List<ISprite> sprites;
    private ISprite textSprite;
    public int CurrentSprite { get; set; }
    // Controller attributes
    private IController keyboardController;
    private IController mouseController;
    private List<IController> controllers;

    public Game1()
    {
        graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        keyboardController = new KeyboardController(this);
        mouseController = new MouseController(this);
        controllers = [keyboardController, mouseController];

        base.Initialize();
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);

        SpriteSheet = Content.Load<Texture2D>("marioSpritesheet");

        Rectangle standingMarioCoordinates = new Rectangle(51, 42, 21, 39);
        staticSprite = new StaticSprite(SpriteSheet, standingMarioCoordinates, new Vector2(100, 100));

        Rectangle walkingMario1 = new Rectangle(316, 957, 30, 36);
        Rectangle walkingMario2 = new Rectangle(346, 955, 31, 37);
        List<Rectangle> walkingMarioFrames = [walkingMario1, walkingMario2];
        animatedSprite = new AnimatedSprite(SpriteSheet, walkingMarioFrames, new Vector2(500, 100));

        Rectangle movingMarioCoordinates = new Rectangle(46, 437, 30, 35);
        staticMovingSprite = new StaticMovingSprite(SpriteSheet, movingMarioCoordinates, new Vector2(100, 300), 50, 3);

        Rectangle flyingMario1 = new Rectangle(286, 1038, 39, 38);
        Rectangle flyingMario2 = new Rectangle(323, 1038, 39, 38);
        List<Rectangle> flyingMarioFrames = [flyingMario1, flyingMario2];
        animatedMovingSprite = new AnimatedMovingSprite(SpriteSheet, flyingMarioFrames, new Vector2(500, 300), 30, 3);

        // Add all sprites to sprite list
        sprites = [staticSprite, staticMovingSprite, animatedSprite, animatedMovingSprite];

        SpriteFont font = Content.Load<SpriteFont>("Arial");
        textSprite = new TextSprite(font, "Credits\n Program Made By: Nicole Futoryansky\n Sprites from: https://www.mariouniverse.com/wp-content/img/sprites/nes/smb3/mario.png", new Vector2(50, 200));

        CurrentSprite = 0;

    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        foreach (ISprite sprite in sprites)
        {
            sprite.Update(gameTime);
        }

        foreach (IController controller in controllers)
        {
            controller.Update();
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        spriteBatch.Begin();
        sprites[CurrentSprite].Draw(spriteBatch);
        textSprite.Draw(spriteBatch);
        spriteBatch.End();


        base.Draw(gameTime);
    }
}
