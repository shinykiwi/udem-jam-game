using UnityEngine;
using UnityEngine.UI;

public class Tab : MonoBehaviour
{

    [SerializeField] private Page page;
    public string tabName;
    public string frenchName;
    public string description;
    public string frenchDescription;

    private Button button;

    public void Awake()
    {
        togglePage(0);
    }
    public void Start()
    {
        button = GetComponent<Button>();
        //button.onClick.AddListener(() => InfoManager.instance.displayInfo(this));
        
    }
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

        if (val)
            InfoManager.instance.displayInfo(this);
        page.gameObject.SetActive(val);
    }
}
