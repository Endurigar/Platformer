using System;
using System.Collections;
using System.Collections.Generic;
using Containers;
using UnityEngine;

public class EffectSpawner : MonoBehaviour
{
    [SerializeField] private ParticleSystem effectOnLose;
    [Inject] private ActionContainer actionContainer;

    private void Start()
    {
        AddListeners();
    }

    private void AddListeners()
    {
        actionContainer.OnLose += () => SpawnEffectOnLose();
    }

    private void SpawnEffectOnLose()
    {
        Instantiate(effectOnLose, gameObject.transform.position, Quaternion.identity);
    }
}
