using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RealtimeBindable :MonoBehaviour
{
  
  protected virtual void Start()
    {
      DIContainer.Instance.RealtimeBind(this);
    }
   
}
