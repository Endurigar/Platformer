using Containers;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utilities;

namespace UI
{
    public class InGameMenu : MonoBehaviour
    {
        [SerializeField] private GameObject inGameMenu;
        [SerializeField] private Button restart;
        [SerializeField] private Button backToMainMenu;
        [SerializeField] private Button nextLevel;
        [SerializeField] private TMP_Text text;
        [SerializeField] private LevelInfo levelInfo;
        [Inject] private ActionContainer actionContainer;


        private void Start()
        {
            AddListeners();
            restart.onClick.AddListener(Restart);
            backToMainMenu.onClick.AddListener(BackToMainMenu);
            nextLevel.onClick.AddListener(NextLevel);
        }

        private void OnInvokeMenu(InputValue value)
        {
            if (PlayerPrefs.GetInt("instructionComplete") == 0)
            {
                return;
            }

            if (inGameMenu.activeInHierarchy)
            {
                inGameMenu.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                inGameMenu.SetActive(true);
                text.text = "MENU";
                Time.timeScale = 0;
            }
        }

        private void AddListeners()
        {
            actionContainer.OnWin += OnWin;
            actionContainer.OnLose += OnLose;
        }

        private static void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Physics.gravity = new Vector3(0, -9.81F, 0);
            Time.timeScale = 1;
        }

        private static void BackToMainMenu()
        {
            SceneManager.LoadScene("Menu");
            Time.timeScale = 1;
        }

        private void OnWin()
        {
            text.text = "U WIN";
            nextLevel.gameObject.SetActive(true);
            restart.gameObject.SetActive(false);
            inGameMenu.SetActive(true);
        }

        private void OnLose()
        {
            text.text = "U LOSE";
            inGameMenu.SetActive(true);
        }

        private void NextLevel()
        {
            SceneManager.LoadScene($"Level {int.Parse(levelInfo.Name) + 1}");
            Physics.gravity = new Vector3(0, -9.81F, 0);
        }
    }
}