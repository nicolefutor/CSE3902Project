using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace gameProject
{
    public class StaticMovingSprite : ISprite
    {
        private Texture2D spriteSheet;
        private Rectangle sourceRectangle;
        private Vector2 position;
        private Vector2 velocity;
        private float minY;
        private float maxY;

        public StaticMovingSprite(Texture2D spriteSheet, Rectangle sourceRectangle, Vector2 startPosition, float moveRange, float speed)
        {
            this.spriteSheet = spriteSheet;
            this.sourceRectangle = sourceRectangle;
            position = startPosition;
            velocity = new Vector2(0, speed);
            minY = startPosition.Y - moveRange;
            maxY = startPosition.Y + moveRange;
        }

        public void Update(GameTime gameTime)
        {
            // Move up or down
            position += velocity;

            // Reverse direction if it goes past the limits
            if (position.Y <= minY || position.Y >= maxY)
            {
                velocity.Y *= -1;
            }
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
