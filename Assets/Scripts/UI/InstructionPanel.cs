using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UI
{
    public class InstructionPanel : MonoBehaviour
    {
        private const string PlayerPrefsKey = "instructionComplete";
        private const int TimeForInstruction = 4;
        private void Start()
        {
            if (PlayerPrefs.GetInt(PlayerPrefsKey) != 1)
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

        private IEnumerator PanelTime()
        {
            yield return new WaitForSeconds(TimeForInstruction);
            gameObject.SetActive(false);
            PlayerPrefs.SetInt(PlayerPrefsKey, 1);
        }
    }
}
