using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHomePanel : MonoBehaviour
{
    public GameObject panel;
    public Button btn;

    void Start(){
        Button openMenu = btn.GetComponent<Button>();
        openMenu.onClick.AddListener(Task);
    }

    void Task(){
        // Debug.Log("Button Clicked");
        panel.SetActive(true);

    }


}
