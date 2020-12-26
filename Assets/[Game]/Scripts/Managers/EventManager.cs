using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager 
{

    public static UnityEvent OnOrderCompleted = new UnityEvent();
    public static UnityEvent OnOrderFailed = new UnityEvent();

    public static UnityEvent OnGameStarted = new UnityEvent();
    public static UnityEvent OnGameEnd= new UnityEvent();

    public static UnityEvent OnLevelReady = new UnityEvent();
    public static UnityEvent OnLevelStarted = new UnityEvent();
    public static UnityEvent OnLevelFinished = new UnityEvent();

    public static UnityEvent OnLevelItemsSelected = new UnityEvent();
    public static UnityEvent OnOrderGenerated = new UnityEvent();

    public static UnityEvent OnLevelSuccesed = new UnityEvent();
    public static UnityEvent OnLevelFailed= new UnityEvent();

    public static UnityEvent OnItemPacked = new UnityEvent();
}

public class ToDo 
{
    //HappinessBar datalarını level dataya taşı
    //DragAndDrop scriptini düzenle

}
