namespace gameProject
{
    public class SelectAnimatedMovingSpriteCommand : ICommand
    {
        private Game1 game;

        public SelectAnimatedMovingSpriteCommand(Game1 game)
        {
            this.game = game;

        }

        public void Execute()
        {
            game.CurrentSprite = 3;
        }
    }
}