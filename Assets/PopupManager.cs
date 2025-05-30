using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupManager : MonoBehaviour
{
    public static PopupManager Instance;
    [SerializeField] private Popup popupPrefab;
    [SerializeField] private PopupItem testPopup;
    private Popup currentPopup;

    private List<TimedPopupItem> timedPopups = new();
    private Dictionary<string, EventPopupItem> eventPopups = new();
    
    [SerializeField] private List<TimedPopupItem> _timedPopups;
    [SerializeField] private List<EventPopupItem> _eventPopups;
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        InitializeEventPopups();
        InitializeTimedPopups();

        StartCoroutine(runTimedPopups());
    }

    private void InitializeEventPopups()
    {
        foreach (var eventPopup in _eventPopups)
        {
            eventPopups.Add(eventPopup.key, eventPopup);   
        }
    }

    private void InitializeTimedPopups()
    {
        timedPopups = _timedPopups;
        timedPopups.Sort((a,b) => a.timer.CompareTo(b.timer));
    }

    private IEnumerator runTimedPopups()
    {
        foreach (var timedPopup in timedPopups)
        {
            float time_diff = timedPopup.timer - Time.time;
            if (time_diff > 0)
            {
                yield return new WaitForSeconds(time_diff);
            }
            CreatePopup(timedPopup);
        }
    }

    public void runEventPopup(string eventKey)
    {
        if (eventPopups.ContainsKey(eventKey))
        {
            CreatePopup(eventPopups[eventKey]);
            eventPopups.Remove(eventKey);
        }
    }

    private void CreatePopup(PopupItem popupItem)
    {
        StartCoroutine(_waitForPopup());
        currentPopup = Instantiate(popupPrefab, transform);
        currentPopup.setPopup(popupItem);
    }

    private IEnumerator _waitForPopup()
    {
        while (currentPopup)
        {
            yield return new WaitForSeconds(1);
        }
    }

    
}
