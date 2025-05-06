using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

public class UIPageManager : EditorWindow
{
    private List<GameObject> pages = new List<GameObject>();
    private SerializedObject serializedObject;
    private SerializedProperty pagesProperty;
    private int selectedIndex = -1;

    [MenuItem("Tools/UI Page Manager")]
    public static void ShowWindow()
    {
        GetWindow<UIPageManager>("UI Page Manager");
    }

    private void OnEnable()
    {
        // Optional: Load pages from a tag or parent if you want
    }

    private void OnGUI()
    {
        EditorGUILayout.LabelField("UI Pages", EditorStyles.boldLabel);

        int count = Mathf.Max(0, EditorGUILayout.IntField("Page Count", pages.Count));

        while (pages.Count < count)
            pages.Add(null);
        while (pages.Count > count)
            pages.RemoveAt(pages.Count - 1);

        for (int i = 0; i < pages.Count; i++)
        {
            pages[i] = (GameObject)EditorGUILayout.ObjectField($"Page {i + 1}", pages[i], typeof(GameObject), true);
        }

        EditorGUILayout.Space();

        if (GUILayout.Button("Show Selected Page"))
        {
            for (int i = 0; i < pages.Count; i++)
            {
                if (pages[i] != null)
                    pages[i].SetActive(i == selectedIndex);
            }
        }

        selectedIndex = EditorGUILayout.Popup("Select Page to Show", selectedIndex, GetPageNames());
    }

    private string[] GetPageNames()
    {
        string[] names = new string[pages.Count];
        for (int i = 0; i < pages.Count; i++)
        {
            names[i] = pages[i] != null ? pages[i].name : $"Page {i + 1}";
        }
        return names;
    }
}