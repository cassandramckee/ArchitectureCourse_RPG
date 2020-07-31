using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemComponent : MonoBehaviour
{
    protected float _nextUseTime; // Defaults to 0

    public bool CanUse => Time.time >= _nextUseTime;
    
    public abstract void Use();
}