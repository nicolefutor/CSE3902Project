namespace gameProject
{
    public class SelectStaticSpriteCommand : ICommand
    {
        private Game1 game;

        public SelectStaticSpriteCommand(Game1 game)
        {
            this.game = game;

        }

        public void Execute()
        {
            game.CurrentSprite = 0;
        }
    }
}