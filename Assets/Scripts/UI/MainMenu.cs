using Containers;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button playButton;
        [SerializeField] private GameObject mainMenu;
        [SerializeField] private GameObject levelMenu;
        [SerializeField] private Button exitButton;
        [Inject] private ActionContainer actionContainer;

        private void Start()
        {
            exitButton.onClick.AddListener(ButtonExitClicked);
            playButton.onClick.AddListener(ButtonPlayClicked);
        }

        private void ButtonPlayClicked()
        {
            mainMenu.SetActive(false);
            levelMenu.SetActive(true);
        }

        private static void ButtonExitClicked()
        {
            Application.Quit();
        }
    }
}
