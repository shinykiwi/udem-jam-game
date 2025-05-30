using UnityEngine;

[CreateAssetMenu(fileName = "StatsContainer", menuName = "Scriptable Objects/Create new StatsContainer")]
public class StatsContainer : ScriptableObject
{
    public StatVariable Engagement;
    public StatVariable Comprehension;
    public StatVariable Burnout;
    
}
