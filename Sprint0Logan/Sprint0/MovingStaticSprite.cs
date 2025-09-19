using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class MovingStaticSprite : ISprite
{
    private Texture2D texture;
    private Vector2 startPosition;
    private float amplitude; 
    private float speed;     
    private double totalTime;

    public MovingStaticSprite(Texture2D texture, Vector2 startPosition, float amplitude, float speed)
    {
        this.texture = texture;
        this.startPosition = startPosition;
        this.amplitude = amplitude;
        this.speed = speed;
        this.totalTime = 0;
    }

    public void Update(GameTime gameTime)
    {
        totalTime += gameTime.ElapsedGameTime.TotalSeconds;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        // Get center of texture
        Vector2 origin = new Vector2(texture.Width / 2f, texture.Height / 2f);
       
        // Calculate vertical movement
        float yOffset = amplitude * (float)System.Math.Sin(totalTime * speed);
        Vector2 pos = new Vector2(startPosition.X, startPosition.Y + yOffset);
        spriteBatch.Draw(texture, pos, null, Color.White, 0f, origin, 4f, SpriteEffects.None, 0f);
    }
}
