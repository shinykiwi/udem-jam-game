using UnityEngine;

public class Tab : MonoBehaviour
{

    [SerializeField] private Page page;
    public string tabName;
    public string description;
    
    
    public void togglePage(int state = -1)
    {
        bool val;
        switch (state)
        {
            case 0:
                val = false;
                break;
            case 1:
                val = true;
                break;
            default:
                val = !page.gameObject.activeSelf;
                break;
        }
        
        page.gameObject.SetActive(val);
    }
}
