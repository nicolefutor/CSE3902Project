using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace gameProject
{
    public class StaticSprite : ISprite
    {
        private Texture2D spriteSheet;
        private Rectangle sourceRectangle;
        private Vector2 position;

        public StaticSprite(Texture2D spriteSheet, Rectangle sourceRectangle, Vector2 position)
        {
            this.spriteSheet = spriteSheet;
            this.sourceRectangle = sourceRectangle;
            this.position = position;
        }

        public void Update(GameTime gameTime)
        {
            // Static, nothing to update here
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int width = sourceRectangle.Width;
            int height = sourceRectangle.Height;
            Rectangle DestinationRectangle = new Rectangle((int)position.X, (int)position.Y, width * 2, height * 2);

            spriteBatch.Draw(spriteSheet, DestinationRectangle, sourceRectangle, Color.White);
        }
    }
}
