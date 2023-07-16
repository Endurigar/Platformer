using System.Collections;
using System.Collections.Generic;
using Containers;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [Inject]private ActionContainer actionContainer;
    [SerializeField] private AudioClip audioClip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(audioClip, gameObject.transform.position);
            other.gameObject.SetActive(false);
            actionContainer.OnLose();
        }
    }
}
