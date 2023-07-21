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
        private const string PlayerPrefsKey = "instructionComplete";
        private const string MenuTitleText = "Menu";
        private const string WinTitleText = "U WIN";
        private const string LoseTitleText = "U LOSE";


        private void Start()
        {
            AddListeners();
            restart.onClick.AddListener(Restart);
            backToMainMenu.onClick.AddListener(BackToMainMenu);
            nextLevel.onClick.AddListener(NextLevel);
        }

        private void OnInvokeMenu(InputValue value)
        {
            if (PlayerPrefs.GetInt(PlayerPrefsKey) == 0)
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
                text.text = MenuTitleText;
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
            SceneManager.LoadScene(MenuTitleText);
            Time.timeScale = 1;
        }

        private void OnWin()
        {
            text.text = WinTitleText;
            nextLevel.gameObject.SetActive(true);
            restart.gameObject.SetActive(false);
            inGameMenu.SetActive(true);
        }

        private void OnLose()
        {
            text.text = LoseTitleText;
            inGameMenu.SetActive(true);
        }

        private void NextLevel()
        {
            SceneManager.LoadScene($"Level {int.Parse(levelInfo.Name) + 1}");
            Physics.gravity = new Vector3(0, -9.81F, 0);
        }
    }
}