using Cinemachine;
using Containers;
using UnityEngine;

namespace Utilities
{
    public class CameraOnHold : MonoBehaviour
    {
        [Inject] private ActionContainer actionContainer;
        private CinemachineVirtualCamera cameraOnLose;

        private void Start()
        {
            cameraOnLose = GetComponent<CinemachineVirtualCamera>();
            AddListeners();
        }

        private void AddListeners()
        {
            actionContainer.OnWin += () => { cameraOnLose.Priority = 20; };
            actionContainer.OnLose += () => { cameraOnLose.Priority = 20; };
        }
    }
}
