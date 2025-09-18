using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace gameProject
{
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
            // No animation needed for static text
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, text, position, Color.White);
        }
    }
}
