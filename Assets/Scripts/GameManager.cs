using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEditor;
using System;

namespace TaktikaTest
{
    public class GameManager : MonoBehaviour
    {
        #region values.
        [SerializeField]private GameObject _uiGameOver;
        [SerializeField] private GameObject _uiGold;
        [SerializeField] private GameObject _uiHealth;

        [SerializeField]
        [Tooltip("Player's gold")]

        private int _gold;
        public int Gold
        {
            get { return _gold; }
            set
            {
                if (0 < (_gold - value))
                {
                    EventManager.Invoke(EventType.NoEnoughGold);
                }
                else
                {
                    _gold -= value;
                    // TODO: set data on ui.
                }
            }
        }

        #endregion

        // Start is called before the first frame update
        void Start()
        {
            EventManager.AddListener(EventType.GameOver, s => SetGameOver());
            EventManager.AddListener(EventType.HealthCastleUpdated, SetHealthUi);
        }


        // Update is called once per frame
        void Update()
        {

        }

        /// <summary>
        /// Show ui with information, that player won
        /// and suggest to player continue play.
        /// </summary>
        private void InformGameOver()
        {
            // TODO: inform player that there is game over.
        }

        private void SetGameOver()
        {
            // TODO: set ui game over.
        }
        private void SetHealthUi(object sender)
        {
            if (sender.GetType() == typeof(Castle))
            {
                // TODO: update health on ui ((Castle)sender).Health
            }
        }
    }
}
