using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchPlace : MonoBehaviour
{
    public GameObject building;
    public GameObject player;
    public GameObject home;
    public GameObject button;
    Animator animator;

    public float timer = 0.0f;
    public float searchTime = 8.0f;
    public bool isSearching = false;

    // Start is called before the first frame update
    void Start()
    {
        button.SetActive(false);
        animator = player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
