using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

namespace UI
{
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
            foreach (var t in levelInfos)
            {
                var newLevelButton = Instantiate(levelButton, levelMenu);
                newLevelButton.GetComponent<LevelMenu>().SetLevelInfo(t);
            }
        }
    }
}
