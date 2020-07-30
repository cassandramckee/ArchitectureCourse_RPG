using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemComponent : MonoBehaviour
{
    protected float _nextUseTime; // Defaults to 0

    private bool CanUse => Time.time >= _nextUseTime;
    
    protected abstract void Use();


    private void Update()
    {
        if (CanUse && Input.GetKeyDown(KeyCode.Space))
        {
            Use();
            // adsasd
            _nextUseTime = Time.time + 1f;
        }
    }
}