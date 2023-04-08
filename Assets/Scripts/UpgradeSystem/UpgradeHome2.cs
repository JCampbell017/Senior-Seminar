// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using TMPro;

// public class UpgradeHome2 : MonoBehaviour
// {
//     public GameObject player;

//     // Start is called before the first frame update
//     void Start()
//     {
//         GameObject close_btn = close_button.GetComponent<Button>();
//         Button OpenMenu = OpenMenu.GetComponent<Button>();

//         OpenMenu.onClick.AddListener(TaskOnClick);
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }

//     void TaskOnClick(){
//         //make menu dissapear
//         close_button.transform.position = new Vector3(50000, 0, -50000);
//         upgrade_title.transform.position = new Vector3(50000, 0, -50000);
//         requirements.transform.position = new Vector3(50000, 0, -50000);
//         //make player visible
//         player.SetActive(true);
//     }
// }
