using UnityEngine.Events;
public static class EventManager
{
    public static UnityEvent OnTapRelease = new UnityEvent();
    public static UnityEvent OnGameStart = new UnityEvent();
    public static UnityEvent OnGameOver = new UnityEvent();
    public static UnityEvent OnTapStart = new UnityEvent();


}
