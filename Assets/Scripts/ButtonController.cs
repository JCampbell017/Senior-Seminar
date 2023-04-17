using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameObject button;
    public GameObject tree;
    public GameObject player;
    public GameObject home; 
    Animator animator;

    private float timer = 0.0f;
    private float chopTime = 3.0f;

    public bool isChopping = false;
   

    void Start()
    {
     button.SetActive(false);
     animator = player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(tree != null && !isChopping){
            Vector3 treePosition = Camera.main.WorldToScreenPoint(tree.transform.position);
            button.transform.position = treePosition + new Vector3(0, 4.0f, 0);
        }

        
        if(isChopping){
            
            PlayerController plControl = player.GetComponent<PlayerController>();
            timer += Time.deltaTime;
            if(timer > chopTime){
                timer = 0;
                isChopping = false;
                animator.SetBool("chopTree", false);
                // Need to destroy tree somehow
               Destroy(tree);
                Home.wood +=3;
                Debug.Log(Home.wood);

            }else{
                if(plControl.sideCollision == "left"){
                    animator.SetBool("IsLeft", true);
                }else{
                    animator.SetBool("IsLeft", false);
                }
            }
        
        }
    }

   public void OnClick(){
        Debug.Log("Chopping down tree :)");
        animator.SetBool("chopTree", true);
        isChopping = true;
        button.transform.position = new Vector3(500000,0,-500000);
    }

}
