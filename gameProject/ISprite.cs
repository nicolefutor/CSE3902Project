using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace gameProject
{
    public interface ISprite
    {
        // Called once per frame to update the movement or animation frame
        void Update(GameTime gameTime);

        // Called once per frame to draw the sprite
        void Draw(SpriteBatch spriteBatch);
    }
}