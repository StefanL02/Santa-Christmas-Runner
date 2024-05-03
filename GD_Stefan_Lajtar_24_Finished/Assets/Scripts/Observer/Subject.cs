using Assets.Scripts.Observer;
using System.Collections.Generic;
using UnityEngine;

public abstract class Subject<T> : MonoBehaviour
    where T : IObserver 
{
    private readonly List<T> _observers = new List<T>();

    public void AddObserver(T observer)
    {
        _observers.Add(observer);
    }

    public void RemoveObserver(T observer)
    {
        _observers.Remove(observer);
    }

    protected void NotifyObservers()
    {
        _observers.ForEach((_observers) =>
        {
            _observers.OnNotify();
        });
    }
}
