using Containers;
using UnityEngine;

namespace GameMechanics
{
    public class Trap : MonoBehaviour
    {
        [Inject] private ActionContainer actionContainer;
        [SerializeField] private AudioClip audioClip;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                AudioSource.PlayClipAtPoint(audioClip, gameObject.transform.position);
                other.gameObject.SetActive(false);
                actionContainer.OnLose();
            }
        }
    }
}
