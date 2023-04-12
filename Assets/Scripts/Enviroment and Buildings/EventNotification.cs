using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventNotification : MonoBehaviour
{

    [SerializeField]public TMPro.TextMeshProUGUI event_text = new TMPro.TextMeshProUGUI();
    
    // Start is called before the first frame update
    void Start()
    {
        event_text.text = "";
    }
}
