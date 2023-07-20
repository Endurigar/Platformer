using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UI
{
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

        private IEnumerator PanelTime()
        {
            yield return new WaitForSeconds(4);
            gameObject.SetActive(false);
            PlayerPrefs.SetInt("instructionComplete", 1);
        }
    }
}
