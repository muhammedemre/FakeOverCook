public class DataManager : Manager
{
    public static DataManager instance;

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

    public override void PreGameStartProcess()
    {
        // base.StartProcess();
        // print("Data is loaded");
        GameManager.instance.gameManagerObserverOfficer.Publish(ObserverSubjects.GameStart);
    }
}
