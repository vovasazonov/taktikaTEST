using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TaktikaTest
{
    public class Castle : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Castle's health")]
        private int _health;
     
        public int Health
        {
            get
            {
                return _health;
            }
            set
            {
                if (0 < _health - value)
                {
                    EventManager.Invoke(EventType.GameOver);
                }
                else
                {
                    _health -= value;
                    EventManager.Invoke(EventType.HealthCastleUpdated, this);
                }
            }
        }
    }
}
