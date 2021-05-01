using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolSprite : MonoBehaviour
{
    //attaches to button prefab
    //exposes gameobjects to modify text and images of through CoolGUICreator.cs
    [SerializeField]
    public Text toolDisplayName;

    [SerializeField]
    public Image toolSprite;
}
