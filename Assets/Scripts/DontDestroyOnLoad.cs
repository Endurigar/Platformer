using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoad : MonoBehaviour
{
    
    void Awake()
    {
        GameObject otherObject = GameObject.Find(gameObject.name);
        if (otherObject != null && otherObject != gameObject)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
