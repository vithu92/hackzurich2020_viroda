using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LoadConfiguration {
    
    public static ApiConfig ApiConfig;

    /// <summary>
    /// Load API config from json file
    /// </summary>
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void LoadAPIConfig()
    {
        Debug.Log("Loading api config");
        var Result = (TextAsset)Resources.Load("Configuration/configuration_api");
        ApiConfig = JsonUtility.FromJson<ApiConfig>(Result.text);

        API.Initialize();

        // TESTING
        Debug.Log(API.GetProduct("120267000000").nutrition_facts.standard.nutrients[0].name);
        Debug.Log(API.GetProduct("120267000000").origins.producing_country);
    }


}

[System.Serializable]
public class ApiConfig
{
    public string username;
    public string password;
    public string base_url;
    public string product_url;
    public string discount_url;
}
