using UnityEngine;
using UnityEngine.UI;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "PopupItem", menuName = "ScriptableObjects/Create New PopupItem")]
    public class PopupItem : ScriptableObject
    {
        public Sprite sprite;
        public string headlineText;
        public string bodyText;
    }
}
