using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using System.Collections.Generic;

namespace TaktikaTest
{
    //[RequireComponent(typeof(NavMeshAgent))]
    public class BotWalk : MonoBehaviour
    {

        [SerializeField]
        private List<Transform> _points;
        [SerializeField]
        private float _rotationSpeed = 5;
        [SerializeField]
        private float _walkSpeed = 5;
        [SerializeField]
        private float _radiusPoint = 0.1f;
        private Vector3 _endPosition;
        private bool _isNoPoints;

        void Start()
        {
            if (_points.Count > 0)
            {
                _isNoPoints = false;
                _endPosition = _points[0].position;
                SetRotation(_endPosition);
            }
            else
            {
                _isNoPoints = true;
            }
        }

        void SetRotation(Vector3 lookAt)
        {
            Vector3 lookPos = lookAt - transform.position;
            lookPos.y = 0;
            Quaternion rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, _rotationSpeed * Time.deltaTime);
        }

        void Update()
        {
            if (_isNoPoints)
            {
                return;
            }

            transform.position = Vector3.MoveTowards(transform.position, _endPosition, Time.deltaTime * _walkSpeed);

            

            if(Vector3.Distance(transform.position, _endPosition) < _radiusPoint)
            {
                _points.RemoveAt(0);
                if (_points.Count > 0)
                {
                    _endPosition = _points[0].position;
                    SetRotation(_endPosition);
                }
                else
                {
                    _isNoPoints = true;
                }
            }


        }

    }
}

