using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryButton : MonoBehaviour
{
    public GameObject invButton;
    public GameObject invCanvas;
    public GameObject invClose;


    public void onInvButtonClick(){
        invCanvas.SetActive(true);
    }
    public void onInvCloseClick(){
        invCanvas.SetActive(false);
    }
}
