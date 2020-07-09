using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TaktikaTest
{
    public class EventManager : MonoBehaviour
    {
        private Dictionary<EventType, UnityObjectEvent> _eventDictionary = null;
        static private EventManager _eventManager = null;

        static public EventManager Instance
        {
            get
            {
                if (_eventManager == null)
                {
                    Debug.LogError("Have to be one active EventManger" +
                        " script on a GameObject in your scene.");
                }

                return _eventManager;
            }
            set { }
        }


        void Awake()
        {
            if (_eventManager == null)
            {
                _eventManager = this;
                _eventManager.Initialize();

                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(this);
            }
        }

        private void Initialize()
        {
            if (_eventDictionary == null)
            {
                _eventDictionary = new Dictionary<EventType, UnityObjectEvent>();
            }
        }

        public static void AddListener(EventType eventType, UnityAction<object> listener)
        {
            UnityObjectEvent thisEvent = null;
            if (Instance._eventDictionary.TryGetValue(eventType, out thisEvent))
            {
                thisEvent.AddListener(listener);
            }
            else
            {
                thisEvent = new UnityObjectEvent();
                thisEvent.AddListener(listener);
                Instance._eventDictionary.Add(eventType, thisEvent);
            }
        }

        public static void RemoveListener(EventType eventType, UnityAction<object> listener)
        {
            if (_eventManager == null) return;
            UnityObjectEvent thisEvent = null;
            if (Instance._eventDictionary.TryGetValue(eventType, out thisEvent))
            {
                thisEvent.RemoveListener(listener);
            }
        }

        public static void Invoke(EventType eventType, object argument = null)
        {
            UnityObjectEvent thisEvent = null;
            if (Instance._eventDictionary.TryGetValue(eventType, out thisEvent))
            {
                thisEvent.Invoke(argument);
            }
        }

    }
}