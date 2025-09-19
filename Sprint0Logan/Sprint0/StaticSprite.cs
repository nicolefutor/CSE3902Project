using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class StaticSprite : ISprite
{
    private Texture2D texture;
    private Vector2 position;
    

    public StaticSprite(Texture2D texture, Vector2 position)
    {
        this.texture = texture;
        this.position = position;
    }

    public void Update(GameTime gameTime)
    {
        
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        // Get sprite center
        Vector2 origin = new Vector2(texture.Width / 2f, texture.Height / 2f);

        spriteBatch.Draw(texture, position, null, Color.White, 0f, origin, 4f, SpriteEffects.None, 0f);
    }
}
