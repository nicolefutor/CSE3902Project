namespace gameProject
{
    public class SelectStaticMovingSpriteCommand : ICommand
    {
        private Game1 game;

        public SelectStaticMovingSpriteCommand(Game1 game)
        {
            this.game = game;

        }

        public void Execute()
        {
            game.CurrentSprite = 1;
        }
    }
}