using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameObject button;
    public GameObject tree;
    public GameObject player;
    Animator animator;
   

    void Start()
    {
     button.SetActive(false);
     animator = player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(tree != null){
            Vector3 treePosition = Camera.main.WorldToScreenPoint(tree.transform.position);
            button.transform.position = treePosition + new Vector3(0, 2.0f, 0);
        }
    }

   public void OnClick(){
        
        Debug.Log("Chopping down tree :)");
        animator.SetBool("chopTree", true);
        PlayerController plControl = player.GetComponent<PlayerController>();
        float chopTime = 5.0f;
        if(plControl.sideCollision == "left"){
            animator.SetBool("IsLeft", true);
            // Some condition that will stop animation
            // animator.SetBool("chopTree", false);
        }else{
            animator.SetBool("IsLeft", false);
            // Some condition that will stop animation
            // animator.SetBool("chopTree", false);
        }
    }
}
