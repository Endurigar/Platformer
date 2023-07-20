using Cinemachine;
using Containers;
using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class GravityController : MonoBehaviour
    {
        [Inject] private ActionContainer actionContainer;
        [SerializeField] private CinemachineFreeLook cinemachineFreeLook;
        private const float CameraYAxisUp = 0;
        private const float CameraYAxisDown = 0.5f;
        private const float DoVirtualDuration = 1;

        private void Start()
        {
            AddListeners();
        }

        private void GravityChanger()
        {
            Physics.gravity *= -1;
            switch (cinemachineFreeLook.m_YAxis.Value)
            {
                case 0:
                    DOVirtual.Float(cinemachineFreeLook.m_YAxis.Value, CameraYAxisDown, DoVirtualDuration,
                        v => cinemachineFreeLook.m_YAxis.Value = v);
                    break;
                case 0.5f:
                    DOVirtual.Float(cinemachineFreeLook.m_YAxis.Value, CameraYAxisUp, DoVirtualDuration,
                        v => cinemachineFreeLook.m_YAxis.Value = v);
                    break;
            }
        }

        public void OnChangeGravity(InputValue value)
        {
            GravityChanger();
        }

        private void AddListeners()
        {
            actionContainer.OnLose += GravityChanger;
        }
    }
}
