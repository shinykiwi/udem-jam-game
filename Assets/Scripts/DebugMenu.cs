using TMPro;
using UnityEngine;

public class DebugMenu : MonoBehaviour
{
    TextMeshProUGUI textMesh;
    void Start()
    {
        
        gameObject.SetActive(GameManager.Instance.debuggerMode);
        textMesh = GetComponent<TextMeshProUGUI>();   
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            textMesh.enabled = !textMesh.enabled;
            GameManager.Instance.debuggerMode = !GameManager.Instance.debuggerMode;
        }
    }
}
