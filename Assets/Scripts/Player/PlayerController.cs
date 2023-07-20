using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float maxSpeed;
        private new Rigidbody rigidbody;
        private Vector2 input;
        private Vector3 direction;
        private bool gravityState;

        private void Start()
        {
            rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (rigidbody.velocity.magnitude > maxSpeed)
            {
                rigidbody.velocity = rigidbody.velocity.normalized * maxSpeed;
            }

            rigidbody.AddForce(direction * speed);
        }

        private void OnMove(InputValue value)
        {
            input = value.Get<Vector2>();
            direction = input.y * Camera.main.transform.forward + input.x * Camera.main.transform.right;
            Debug.Log(rigidbody.velocity.magnitude);
        }
    }
}
