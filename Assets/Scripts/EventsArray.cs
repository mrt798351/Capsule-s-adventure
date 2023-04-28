using UnityEngine;
using UnityEngine.Events;

public class EventsArray : MonoBehaviour
{
    [SerializeField] private UnityEvent[] _events;
    public void StartEvent(int eventIndex)
    {
        _events[eventIndex].Invoke();
    }
}
