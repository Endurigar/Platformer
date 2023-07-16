using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    [SerializeField]private TMP_Text levelName;
    [SerializeField]private Button levelButton;
    private LevelInfo levelInfo;
    
    private void Start()
    {
        levelButton.onClick.AddListener(LevelButtonClicked);
    }

    private void LevelButtonClicked()
    {
        SceneManager.LoadScene(levelInfo.SceneName);
    }

    public void SetLevelInfo(LevelInfo levelInfo)
    {
        this.levelInfo = levelInfo;
        levelName.text = this.levelInfo.Name;
    }
}
