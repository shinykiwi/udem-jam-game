using TMPro;
using UnityEngine;

public class Debugger : MonoBehaviour
{
    [SerializeField] private StatsContainer sc;
    [SerializeField] private PointVariable focusPoints;
    [SerializeField] private TextMeshProUGUI textHolder;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {

            focusPoints.Value += 1;
            //PopupManager.Instance.TestPopup();
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            sc.Engagement.Value += 0.1f;
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            sc.Comprehension.Value += 0.1f;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            sc.Burnout.Value += 0.1f;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            textHolder.gameObject.SetActive(!textHolder.gameObject.activeSelf);
        }
    }
}
