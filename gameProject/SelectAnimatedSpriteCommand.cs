namespace gameProject
{
    public class SelectAnimatedSpriteCommand : ICommand
    {
        private Game1 game;

        public SelectAnimatedSpriteCommand(Game1 game)
        {
            this.game = game;

        }

        public void Execute()
        {
            game.CurrentSprite = 2;
        }
    }
}