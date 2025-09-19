using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class TextSprite : ISprite
{
    private SpriteFont font;
    private string text;
    private Vector2 position;

    public TextSprite(SpriteFont font, string text, Vector2 position)
    {
        this.font = font;
        this.text = text;
        this.position = position;
    }

    public void Update(GameTime gameTime)
    {
        
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        Vector2 textSize = font.MeasureString(text);
        Vector2 origin = textSize / 2f;

        spriteBatch.DrawString(font, text, position, Color.Black, 0f, origin, 1f, SpriteEffects.None, 0f);
    }
}
