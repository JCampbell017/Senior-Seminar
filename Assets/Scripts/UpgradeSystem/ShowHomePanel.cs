using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHomePanel : MonoBehaviour
{
    public GameObject panel;
    public Button btn;
    public GameObject btn2;
    public GameObject btn3;

    void Start(){
        Button openMenu = btn.GetComponent<Button>();
        openMenu.onClick.AddListener(Task);
    }

    void Task(){
        // Debug.Log("Button Clicked");
        panel.SetActive(true);
        panel.transform.position = new Vector3(1000, 400, 0);
        btn2.transform.position = new Vector3(675, 550, 0);
        btn3.transform.position = new Vector3(675, 450, 0);
    }


}
