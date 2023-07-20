using Containers;
using UnityEngine;

namespace GameMechanics
{
    public class WinTrigger : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        [SerializeField] private ParticleSystem effectOnWin;
        [SerializeField] private AudioClip audioClip;
        [Inject] private ActionContainer actionContainer;
        private int keyCounter;

        private void Start()
        {
            AddListeners();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (keyCounter == 3 && other.CompareTag("Player"))
            {
                actionContainer.OnWin();
            }
        }

        private void AddListeners()
        {
            actionContainer.OnKey += KeyCheck;
            actionContainer.OnWin += Win;
        }

        private void KeyCheck()
        {
            keyCounter++;
        }

        private void Win()
        {
            var position = gameObject.transform.position;
            AudioSource.PlayClipAtPoint(audioClip, position);
            Instantiate(effectOnWin, position, Quaternion.identity);
            player.SetActive(false);
        }
    }
}
