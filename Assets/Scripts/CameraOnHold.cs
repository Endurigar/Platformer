using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Containers;
using UnityEngine;

public class CameraOnHold : MonoBehaviour
{
    private CinemachineVirtualCamera cameraOnLose;
    [Inject] private ActionContainer actionContainer;

    private void Start()
    {
        cameraOnLose = GetComponent<CinemachineVirtualCamera>();
        AddListeners();
    }

    private void AddListeners()
    {
        actionContainer.OnWin += () => { cameraOnLose.Priority = 20; };
        actionContainer.OnLose += () => { cameraOnLose.Priority = 20; };
    }
}
