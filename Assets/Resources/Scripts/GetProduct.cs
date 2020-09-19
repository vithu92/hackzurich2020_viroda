using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GetProduct : MonoBehaviour
{
     public string productID = "";
     private Product product;

    GameObject energie;
    GameObject fett;
    GameObject kohlenhydrat;
    GameObject eiweiss;
    
    // Start is called before the first frame update
    void Start()
    {
        energie = GameObject.Find("Nährwert_Energie_value"); 
        fett = GameObject.Find("Nährwert_Fett_value"); 
        kohlenhydrat = GameObject.Find("Nährwert_Kohlenhydrat_value"); 
        eiweiss = GameObject.Find("Nährwert_Eiweiss_value"); 
        //Debug.Log(API.GetProduct("104400100000").id);
        //Debug.Log(API.GetProduct("104400100000").name);
        Debug.Log("Hallo Welt");
        product = API.GetProduct(productID);
        Debug.Log(energie.name);
    }

    // Update is called once per frame
    void Update()
    {
        //Energie
        energie.GetComponent<Text>().text = product.nutrition_facts.standard.nutrients[0].quantity + " kcal";
        
        //Fett
        //TextMeshPro text_field1 = fett.GetComponent<TextMeshPro>();
        fett.GetComponent<Text>().text = product.nutrition_facts.standard.nutrients[1].quantity + " g";

        //kohlenhydrat
        //TextMeshPro text_field2 = kohlenhydrat.GetComponent<TextMeshPro>();
        kohlenhydrat.GetComponent<Text>().text = product.nutrition_facts.standard.nutrients[3].quantity + " g";

        //eiweiss
        //TextMeshPro text_field3 = eiweiss.GetComponent<TextMeshPro>();
        eiweiss.GetComponent<Text>().text = product.nutrition_facts.standard.nutrients[6].quantity + " g";
    }
}
