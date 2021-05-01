using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//used to manage the active toolbox
//only one can be active at a time
public class TabSelector : MonoBehaviour
{
    [SerializeField]
    private Button Wires_Button, Batteries_Button, Capacitors_Button, Resistors_Button, Switches_Button;

    [SerializeField]
    private GameObject[] Toolboxes = new GameObject[5];

    int currentToolbox;

    void openToolBox(CoolGUICreator.toolCategory toolType)
    {
        currentToolbox = (int)toolType;
        for(int i = 0; i<5;i++)
            Toolboxes[i].SetActive(false);
        Toolboxes[currentToolbox].SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        Wires_Button.onClick.AddListener(delegate { openToolBox(CoolGUICreator.toolCategory.Wire); });
        Batteries_Button.onClick.AddListener(delegate { openToolBox(CoolGUICreator.toolCategory.Battery); });
        Capacitors_Button.onClick.AddListener(delegate { openToolBox(CoolGUICreator.toolCategory.Capacitor); });
        Resistors_Button.onClick.AddListener(delegate { openToolBox(CoolGUICreator.toolCategory.Resistor); });
        Switches_Button.onClick.AddListener(delegate { openToolBox(CoolGUICreator.toolCategory.Switch); });
    }
}
