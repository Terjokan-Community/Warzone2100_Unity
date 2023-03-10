using System;
using System.Collections.Generic;
using UnityEngine;
using Mods.ModCore;
using System.IO;

public class GameManager : MonoBehaviour
{
    #region Singelton
    private static GameManager _singleton;
    public static GameManager Singleton
    {
        get => _singleton;
        private set
        {
            if (_singleton == null)
                _singleton = value;
            else if (_singleton != value)
            {
                Debug.Log($"{nameof(Data)} instance already exists, destroying duplicate!");
                Destroy(value);
            }
        }
    }
    private void Awake()
    {
        Singleton = this;
        Language = new Language();
        Language.LoadFile();
        Language.LoadLanguage(Language.LanguageType.Deutsch, this);
    }
    #endregion


    public Data CurrentGameData;
    public Data Data;
    public Data ReserchedData;

    public Language Language;
    public ModManager modManager;
    public BuildingSystem buildingSystem;
    public UIManager UIManager;


    private void Start()
    {

        if (!Directory.Exists(Application.persistentDataPath + "/mods"))
            Directory.CreateDirectory(Application.persistentDataPath + "/mods");
        modManager = new ModManager(Application.persistentDataPath + "/mods");

        buildingSystem.GenerateGrid(100, 100, 2, "TestMap");
    }
}

