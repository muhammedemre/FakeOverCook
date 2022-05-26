public interface ISubject
{
    void Subscribe(IObserver observer);
    void NotifyObservers();
}
