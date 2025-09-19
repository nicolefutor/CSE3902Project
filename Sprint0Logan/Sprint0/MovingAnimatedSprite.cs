using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class MovingAnimatedSprite : ISprite
{
    private Texture2D sheet;
    private int frameWidth, frameHeight, frames;
    private int currentFrame;
    private double timePerFrame;
    private double accumulator;

    private Vector2 position;
    private float horizontalSpeed; 
    private Rectangle screenBounds;

    public MovingAnimatedSprite(Texture2D sheet, int frameWidth, int frameHeight, int frames, int frameTime, Vector2 startPosition, float horizontalSpeed, Rectangle screenBounds)
    {
        this.sheet = sheet;
        this.frameWidth = frameWidth;
        this.frameHeight = frameHeight;
        this.frames = frames;
        this.position = startPosition;
        this.horizontalSpeed = horizontalSpeed;
        this.screenBounds = screenBounds;
        this.timePerFrame = frameTime;
        this.accumulator = 0.0;
        this.currentFrame = 0;
    }

    public void Update(GameTime gameTime)
    {
        // Animate
        accumulator += gameTime.ElapsedGameTime.TotalMilliseconds;
        if (accumulator >= timePerFrame)
        {
            accumulator -= timePerFrame;
            currentFrame = (currentFrame + 1) % frames;
        }

        // Move horizontally right
        float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
        position.X += horizontalSpeed * elapsed;

        if (position.X > screenBounds.Right)
        {
            // wrap to left
            position.X = -frameWidth;
        }
        
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        Rectangle src = new Rectangle(currentFrame * frameWidth, 0, frameWidth, frameHeight);
        Vector2 origin = new Vector2(frameWidth / 2f, frameHeight / 2f);
        spriteBatch.Draw(sheet, position, src, Color.White, 0f, origin, 4f, SpriteEffects.None, 0f);
    }
}
