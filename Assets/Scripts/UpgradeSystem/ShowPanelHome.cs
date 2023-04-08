using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPanelHome : MonoBehaviour
{
    public GameObject panel;
    public GameObject player;
    public Button button1;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = button1.GetComponent<Button>();
        Vector3 newPos = new Vector3(-500, -500, 0);
        btn.transform.position = newPos;
        panel.SetActive(false);
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick(){
        panel.SetActive(true);
    }
}