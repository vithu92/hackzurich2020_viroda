using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetProduct : MonoBehaviour
{
     public string productName ="";
     public Product product;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(API.GetProduct("104400100000").id);
        //Debug.Log(API.GetProduct("104400100000").name);
        Debug.Log("Hallo Welt");
        product = API.GetProduct("104400100000");
        productName = product.name;
    }

    // Update is called once per frame
    void Update()
    {
        TextMeshPro infoPro = GetComponent<TextMeshPro>();
        string content = "";
        content += productName + "\n";
        content += product.nutrition_facts.standard.nutrients[0].quantity + " kcal";
        infoPro.SetText(content + "\n");
    }
}
