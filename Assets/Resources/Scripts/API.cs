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
        string response = DownloadString(url);
        var result = JsonUtility.FromJson<Product>(response);

        // Calculate CO2 Score, Spoofed for PoC values
        // Risotto Rice
        if (result.id =="104400100000") result.co2_score = 30;
        // Jasmine Rice
        if (result.id == "104402400000") result.co2_score = 50;
        // Cooking Chocolate 
        if (result.id == "100100500000") result.co2_score = 70;
        // else use pseudo-calculation
        if (result.co2_score == null) result.co2_score = result.calculate_co2();

        return result;
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

        WebClient.Headers.Add("accept-language", "de");

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
    public string[]  gtin;

    public string name;
    public string product_name;
    public string product_type;

    public string slug;
    public string short_description;
    public string regulated_description;

    public ProductPrice price;

    public NutritionFactMap nutrition_facts;

    public Origins origins;

    public Label[] labels;

    // CO2 Score
    // Value from 0 to 100
    public int? co2_score;

    // Based on calculation methodology presented by Galaxus
    // https://www.galaxus.ch/de/page/unser-klima-kompensationsmodell-16329
    // but change "product group intensity" to "country of origin CO2 intensity"
    // https://en.wikipedia.org/wiki/Emission_intensity#cite_note-eia_carbon_intensity_data-12
    public int calculate_co2() 
    {
        // get from EIA Data
        var factor_origin_intensity = 25;

        // calculate distance from 0 (local), to 100 (furthest away)
        var factor_distance_origin = 40;

        // calculate factor for "sustainable" labels (10000 -> UTZ ID)
        double factor_label = 1;
        if (Array.Exists(this.labels, elem => elem.id == "10000")) factor_label = 0.9;

        var result = (factor_origin_intensity + factor_distance_origin) * factor_label;

        if (result > 100) result  = 100;
        return (int)Math.Floor(result);
    }
}

/// <summary>
/// ProductPrice class
/// </summary>
[System.Serializable]
public class ProductPrice
{
    //public PriceQuantityUnit base;
}

/// <summary>
/// PriceQuantityUnit class
/// </summary>
[System.Serializable]
public class PriceQuantityUnit
{
    public float price;
    public float quantity;
    public string unit;
    public string display_quantity;
}

/// <summary>
/// NutritionFactMap class
/// </summary>
[System.Serializable]
public class NutritionFactMap
{
    public NutrientCollection standard;
    public NutrientCollection portion;
}

/// <summary>
/// NutrientCollection class
/// </summary>
[System.Serializable]
public class NutrientCollection
{
    public string base_description;
    public float base_quantity;
    public string base_quantity_description;
    public string base_precision;
    public string base_unit;

    public string package_type;
    public string portions_per_package;
    public string portions_per_package_precision;

    public string serving_description;
    public string service_size_description;
    public string consumption_hint;
    public string preparation_state;

    public Nutrient[] nutrients;
}

/// <summary>
/// Nutrient class
/// </summary>
[System.Serializable]
public class Nutrient
{
    public string code;
    public string name;
    public string category;
    public float quantity;

    public float rda_percent;
    public string rda_percent_operator;

    public string nutrition_operator;
    public string quantity_unit;
}

/// <summary>
/// Origins class
/// </summary>
[System.Serializable]
public class Origins
{
    public string producing_country;
    public string supplier_country;
    public string country_of_origin;
}

/// <summary>
/// Label class
/// </summary>
[System.Serializable]
public class Label
{
    public string id;
    public string name;
    public string slug;

    public bool Equals(Label other) {
        return this.id == other.id;
    }
}

