using UnityEngine;

namespace Utilities
{
    public class DontDestroyOnLoad : MonoBehaviour
    {
        private void Awake()
        {
            var otherObject = GameObject.Find(gameObject.name);
            if (otherObject != null && otherObject != gameObject)
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
