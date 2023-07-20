using UnityEngine;

namespace Utilities
{
    [CreateAssetMenu(fileName = "LevelInfo", menuName = "UI/LevelInfo")]
    public class LevelInfo : ScriptableObject
    {
        public string Name;
        public string SceneName;
    }
}
