using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TaktikaTest
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Enemy's health")]
        private int _health;
        [SerializeField]
        [Tooltip("Amount of gold that enemy give to player after die.")]
        private int _gold;
        [SerializeField]
        [Tooltip("Enemy's demage to tower.")]
        private int _demage;

        public int Health
        {
            get { return _health; }
            set
            {
                _health -= value;

                if (_health < 0)
                {
                    EventManager.Invoke(EventType.ReawardPlayer, this);
                }
            }
        }
        public int Gold { get { return _gold; } set { } }
        public int Demage { get { return _demage; } set { } }

        // Start is called before the first frame update.
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
