using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickHandler : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private AudioSource audioSource;
    public static ButtonClickHandler Instance;

    private void Start()
    {
        Instance = this;
    }

    public void OnClickHandler()
    {
        audioSource.PlayOneShot(audioClip);
    }
}
