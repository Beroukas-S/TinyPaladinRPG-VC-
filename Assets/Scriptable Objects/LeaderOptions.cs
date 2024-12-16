using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LeaderOptions : ScriptableObject
{
    [TextArea]
    public string firstMessage;
    [TextArea]
    public string secondMessage;
    [TextArea]
    public string thirdMessage;
    [TextArea]
    public string fourthMessage;
}
