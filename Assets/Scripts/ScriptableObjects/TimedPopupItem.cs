using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "TimedPopupItem", menuName = "Popup Item/TimedPopupItem")]
    public class TimedPopupItem : PopupItem
    {
        public float timer;
    }
}
