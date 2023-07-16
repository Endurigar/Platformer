using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Containers;

public class WinTrigger : MonoBehaviour
{
    [SerializeField]private GameObject player;
    [SerializeField] private ParticleSystem effectOnWin;
    [SerializeField] private AudioClip audioClip;
    [Inject]private ActionContainer actionContainer;
    private int keyCounter;

    private void Start()
    {
        AddListeners();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (keyCounter == 3 && other.tag == "Player")
        {
            actionContainer.OnWin();
        }
    }

    private void AddListeners()
    {
        actionContainer.OnKey += () => KeyCheck();
        actionContainer.OnWin += () => Win();
    }
    private void KeyCheck()
    {
        keyCounter++;
    }

    private void Win()
    {
        AudioSource.PlayClipAtPoint(audioClip, gameObject.transform.position);
        ParticleSystem.Instantiate(effectOnWin, gameObject.transform.position, Quaternion.identity);
        player.SetActive(false);
    }
}
