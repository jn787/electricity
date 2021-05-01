using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CoolGUICreator : MonoBehaviour
{
    [SerializeField]
    private Transform SpawnPoint = null;

    [SerializeField]
    private GameObject item = null;

    [SerializeField]
    private RectTransform content = null;

    [System.NonSerialized]
    private ToolSprite[] myToolSprite = null;

    [System.NonSerialized]
    private Sprite[] spriteArray;

    public const int SpriteCount = 23;

    public enum toolCategory
    {
        Wire,
        Battery,
        Capacitor,
        Resistor,
        Switch
    }

    [SerializeField]
    private toolCategory ToolType;

    [System.NonSerialized]
    private Button[] ButtonArray = null;

    [SerializeField]
    BuildManager tileSetter;

    [SerializeField]
    private TileData MyTileData;

    //This has to be placed in a function because handling it like the other button array things will make them all look at the same variable addr
    //placing it in a function gives them local copies of values to use for their listeners
    void AssignButtonClickListener(Button[] buttonA, int iteration, int value)
    {
        //buttonA[iteration].onClick.AddListener(() => tileSetter.SetSelection(value));
        buttonA[iteration].onClick.AddListener(delegate { tileSetter.SetSelection(value); });
    }

    //These are not exactly lightweight operations, but since it only happens once per scene load, it should be fine
    void Start()
    {
        spriteArray = Resources.LoadAll<Sprite>("ElecComponent");
        myToolSprite = new ToolSprite[SpriteCount];
        ButtonArray = new Button[SpriteCount];

        int toolSearchHit = 0;

        for (int i = 0; i < SpriteCount; i++)
        {
            if (spriteArray[i].ToString().Contains(ToolType.ToString()) == true) 
            {
                // 100 width of item
                float spawnY = toolSearchHit * 100;
                //newSpawn Position
                Vector3 pos = new Vector3(0, -spawnY, 0);
                //instantiate item
                GameObject SpawnedItem = Instantiate(item, pos, SpawnPoint.rotation);
                //setParent
                SpawnedItem.transform.SetParent(SpawnPoint, false);
                //get prefab's item details
                myToolSprite[toolSearchHit] = SpawnedItem.GetComponent<ToolSprite>();
                ButtonArray[toolSearchHit] = SpawnedItem.GetComponent<Button>();
                AssignButtonClickListener(ButtonArray, toolSearchHit, i);
                myToolSprite[toolSearchHit].toolSprite.sprite = spriteArray[i];
                int strlen = spriteArray[i].ToString().Length - 21;
                string str1 = spriteArray[i].ToString().Replace(" (UnityEngine.Sprite)", "");
                MyTileData.SetSwitchType(i, str1[strlen-1]-48);
                MyTileData.SetRotation(i, str1[strlen - 2] - 48);
                myToolSprite[toolSearchHit].toolDisplayName.text = str1.Remove(strlen - 2);
                toolSearchHit++;
                content.sizeDelta = new Vector2(0, toolSearchHit * 100);
            }
        }
    }
}