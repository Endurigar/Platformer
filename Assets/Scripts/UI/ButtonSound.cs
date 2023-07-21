using UnityEngine.UI;

namespace UI
{
    public class ButtonSound : Button
    {
        protected override void Start()
        {
            base.Start();
            onClick.AddListener((() => ButtonClickHandler.Instance.OnClickHandler()));
        }
    }
}
