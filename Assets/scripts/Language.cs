using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class Language 
{
    public enum LanguageType
    {
        Deutsch,
        English
    }

    [SerializeField]
    LanguageType type = LanguageType.Deutsch;
    [SerializeField]
    public Dictionary<string,string> ids = new Dictionary<string, string>();


    public string GetStringWithId(string id)
    {
        return ids[id];
    }
    public void LoadFile()
    {
        string json = File.ReadAllText(Application.streamingAssetsPath + "/Json/Language.json");
        Languages l = JsonConvert.DeserializeObject<Languages>(json);
        Languages.current = l;
    }

    public void LoadLanguage(LanguageType type, GameManager gm)
    {
        Language language = Languages.current.languages[type];
        gm.Language = language;
    }
}


[System.Serializable]
public class Languages
{
    public static Languages current;

    [SerializeField]
    public Dictionary<Language.LanguageType, Language> languages = new Dictionary<Language.LanguageType,Language>();
    

}
