using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideShowPanel : MonoBehaviour
{
    GameObject panel;
    private Button thisButton;

    bool hidden = true;
    // Start is called before the first frame update
    void Start()
    {
        panel = GameObject.Find("UIPanel");
        thisButton = GetComponent<Button>();
        thisButton.onClick.AddListener(OnClick);
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnClick()
    {
        if(hidden)
        {
            panel.SetActive(true);
            hidden = false;
        }
        else
        {
            panel.SetActive(false);
            hidden = true;
        }
    }
}
