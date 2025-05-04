using UnityEngine;

public class TabManager : MonoBehaviour
{

    public static TabManager instance;
    [SerializeField] private Tab currentTab;
    private Tab firstTab;

    public void Awake()
    {
        instance = this;
        firstTab = currentTab;
        
    }

    void Start()
    {
        firstTab.togglePage(1);
    }

    public void SwitchTab(Tab tab)
    {
        if (tab == currentTab) return;
        if (currentTab != null)
        {
            currentTab.togglePage();
        }
        currentTab = tab;
        currentTab.togglePage();
        
    }

    public void resetTab()
    {
        SwitchTab(firstTab);
    }
}
