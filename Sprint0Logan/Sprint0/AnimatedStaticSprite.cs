using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class AnimatedStaticSprite : ISprite
{
    private Texture2D sheet;
    private int frameWidth, frameHeight, frames;
    private int currentFrame;
    private double timePerFrame;
    private double accumulator;
    private Vector2 position;

    public AnimatedStaticSprite(Texture2D sheet, int frameWidth, int frameHeight, int frames, int frameTime, Vector2 position)
    {
        this.sheet = sheet;
        this.frameWidth = frameWidth;
        this.frameHeight = frameHeight;
        this.frames = frames;
        this.position = position;
        this.currentFrame = 0;
        this.timePerFrame = frameTime;
        this.accumulator = 0.0;
    }

    public void Update(GameTime gameTime)
    {
        accumulator += gameTime.ElapsedGameTime.TotalMilliseconds;
        if (accumulator >= timePerFrame)
        {
            accumulator -= timePerFrame;
            currentFrame = (currentFrame + 1) % frames;
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {

        Rectangle source = new Rectangle(currentFrame * frameWidth, 0, frameWidth, frameHeight);
        Vector2 origin = new Vector2(frameWidth / 2f, frameHeight / 2f);
        spriteBatch.Draw(sheet, position, source, Color.White, 0f, origin, 4f, SpriteEffects.None, 0f);
    }
}
