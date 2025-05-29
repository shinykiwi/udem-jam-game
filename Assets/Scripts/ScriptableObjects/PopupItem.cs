using UnityEngine;
using UnityEngine.UI;

namespace ScriptableObjects
{
    public abstract class PopupItem : ScriptableObject
    {
        public Sprite sprite;
        public string headlineText;
        public string bodyText;
    }
}
