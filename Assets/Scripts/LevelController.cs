using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LevelController : MonoBehaviour
{
    private class LevelSettings
    {
        public bool[] AllowedSprites;
        public int LevelID;
        public string LevelName;
        public string LevelDesc;
        public int[,] LevelLayout;
    }
    private void Start()
    {
        LevelSettings lvlSettings = new LevelSettings();
        lvlSettings.LevelID = 0;
        lvlSettings.LevelName = "Sandbox";
        lvlSettings.LevelDesc = "Testing ground";
        lvlSettings.AllowedSprites = new bool[CoolGUICreator.SpriteCount];
        lvlSettings.LevelLayout = new int[6, 4];

    }
}
