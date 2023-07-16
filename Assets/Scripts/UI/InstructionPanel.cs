using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InstructionPanel : MonoBehaviour
{
    private void Start()
    {
        if (PlayerPrefs.GetInt("instructionComplete") != 1)
        {
            StartCoroutine(PanelTime());
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void OnInvokeMenu(InputValue value)
    {
        gameObject.SetActive(false);
    }
    IEnumerator PanelTime()
    {
        yield return new WaitForSeconds(4);
        gameObject.SetActive(false);
        PlayerPrefs.SetInt("instructionComplete", 1);
    }
}
