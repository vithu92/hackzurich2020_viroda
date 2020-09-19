using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public static class API
{
    static string username;
    static string password;
    static CredentialCache credentials;

    static string base_url;
    static string product_url;

    public static void Initialize()
    {
        username = LoadConfiguration.ApiConfig.username;
        password = LoadConfiguration.ApiConfig.password;
        base_url = LoadConfiguration.ApiConfig.base_url;
        product_url = LoadConfiguration.ApiConfig.product_url;

        credentials = new CredentialCache
        {
            { new Uri(base_url), "Basic", new NetworkCredential(username, password) }
        };
    }

    /// <summary>
    /// Gets Product by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static Product GetProduct(string id)
    {
        string url = GetUrl(product_url, id);
        string result = DownloadString(url);
        return JsonUtility.FromJson<Product>(result);
    }

    /// <summary>
    /// Download String with Webclient from given URL
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    static string DownloadString(string url)
    {
        WebClient WebClient = new WebClient
        {
            Credentials = credentials
        };

        return WebClient.DownloadString(new Uri(url));
    }

    /// <summary>
    /// Builds url with saved base_url
    /// </summary>
    /// <param name="suffix"></param>
    /// <returns></returns>
    static string GetUrl(params string[] suffixes)
    {
        string res = base_url;
        for (int i = 0; i < suffixes.Length; i++)
        {
            res = res + "/" + suffixes[i];
        }
        return res;
    }

}

/// <summary>
/// Product class
/// </summary>
[System.Serializable]
public class Product
{
    public string id;
    public string language;

    public string name;
    public string product_name;
    public string product_type;

    public string slug;
    public string short_description;
}
