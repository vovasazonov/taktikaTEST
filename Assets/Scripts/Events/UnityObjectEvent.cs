using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TaktikaTest
{
    /// <summary>
    /// Overide event. 
    /// Where object - the object that send event.
    /// </summary>
    [Serializable]
    public class UnityObjectEvent : UnityEvent<object> { }
}