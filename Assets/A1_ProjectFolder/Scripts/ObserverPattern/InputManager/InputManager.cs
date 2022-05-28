public class InputManager : Manager
{
    public static InputManager instance;
    public GetInputOfficer GetInputOfficer;

    public bool noInputTime = false;

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
}
