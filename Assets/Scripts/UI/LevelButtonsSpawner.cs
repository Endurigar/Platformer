using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtonsSpawner : MonoBehaviour
{
    [SerializeField] private Button levelButton;
    [SerializeField] private Transform levelMenu;
    [SerializeField] private List<LevelInfo> levelInfos;

    private void Start()
    {
        ButtonsSpawner();
    }

    private void ButtonsSpawner()
    {
        for (int i = 0; i < levelInfos.Count; i++)
        {
            Button newLevelButton = Instantiate(levelButton, levelMenu);
            newLevelButton.GetComponent<LevelMenu>().SetLevelInfo(levelInfos[i]);
        }
    }
}
