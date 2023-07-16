using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
using Containers;

public class GravityController : MonoBehaviour
{
    [Inject]private ActionContainer actionContainer;
    private Vector3 cameraDownStartPosition;
    private Vector3 cameraUpStartPosition;


    private void Start()
    {
        AddListeners();
    }

    private void GravityChanger()
    {
        Physics.gravity *= -1;
    }
    public void OnChangeGravity(InputValue value)
    {
        GravityChanger();
    }

    private void AddListeners()
    {
        actionContainer.OnLose += () => GravityChanger();
    }
}
