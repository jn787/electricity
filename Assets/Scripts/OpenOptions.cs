using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenOptions : MonoBehaviour
{
    [SerializeField]
    public GameObject Panel;

    public void TogglePanel()
    {
        bool PanelState = Panel.activeSelf;
        Panel.SetActive(!PanelState);
    }
}
