public class MenuManager : Manager
{
    public static MenuManager instance;

    public MenuActor MenuActor;

    private void Awake()
    {
        StaticCheck();
    }
    
    void StaticCheck()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
    }

    public override void MenuProcess()
    {
        GameManager.instance.currentGameState = GameStates.Menu;
        MenuActor.MenuPreparetion();
    }
}
