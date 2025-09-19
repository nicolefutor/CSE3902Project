using Sprint0;

public class SetSpriteCommand : ICommand
{
    private Game1 game;
    private ISprite sprite;
    public SetSpriteCommand(Game1 game, ISprite sprite)
    {
        this.game = game;
        this.sprite = sprite;
    }
    public void Execute()
    {
        game.SetCurrentSprite(sprite);
    }
}
