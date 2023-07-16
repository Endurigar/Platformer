using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Containers;

public class Key : MonoBehaviour
{
    [Inject] private ActionContainer actionContainer;
    [SerializeField] private ParticleSystem effectOnKey;
    [SerializeField] private AudioClip audioClip;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(audioClip, gameObject.transform.position);
            Instantiate(effectOnKey, gameObject.transform.position, Quaternion.identity);
            actionContainer.OnKey();
            gameObject.SetActive(false);   
        }
    }
}
