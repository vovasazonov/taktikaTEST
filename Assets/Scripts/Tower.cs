using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Enemy's demage to tower.")]
    private int _demage;
    [SerializeField]
    [Tooltip("Speed that tower attack enemys.")]
    private int _attackSpeed;

    public int Demage { get { return _demage; } set { _demage += value; } }
    public int AttackSpeed{ get { return _attackSpeed; } set { _attackSpeed += value; } }

    
}
