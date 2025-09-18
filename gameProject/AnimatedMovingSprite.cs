using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace gameProject
{
    public class AnimatedMovingSprite : ISprite
    {
        private Texture2D spriteSheet;
        private List<Rectangle> frames;  // all animation frames
        private int currentFrame;
        private double secondsPerFrame;
        private double timer;

        private Vector2 position;
        private Vector2 velocity;
        private float minY;
        private float maxY;

        public AnimatedMovingSprite(Texture2D spriteSheet, List<Rectangle> frames, Vector2 startPosition, float moveRange, float speed, double fps = 8.0)
        {
            this.spriteSheet = spriteSheet;
            this.frames = frames;
            this.position = startPosition;

            velocity = new Vector2(0, speed);
            minY = startPosition.Y - moveRange;
            maxY = startPosition.Y + moveRange;

            currentFrame = 0;
            timer = 0;

            secondsPerFrame = 1.0 / fps;
        }

        public void Update(GameTime gameTime)
        {
            timer += gameTime.ElapsedGameTime.TotalSeconds;

            if (timer >= secondsPerFrame)
            {
                currentFrame = (currentFrame + 1) % frames.Count; // loop back around
                timer -= secondsPerFrame;
            }

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
            int width = frames[currentFrame].Width;
            int height = frames[currentFrame].Height;
            Rectangle DestinationRectangle = new Rectangle((int)position.X, (int)position.Y, width * 2, height * 2);

            spriteBatch.Draw(spriteSheet, DestinationRectangle, frames[currentFrame], Color.White);
        }
    }
}
