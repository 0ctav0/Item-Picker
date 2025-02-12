using System.Collections;

public interface IManager
{
    ManagerStatus Status { get; }
    IEnumerator Startup();
}

public enum ManagerStatus
{
    Shutdown,
    Initializing,
    Started,
}