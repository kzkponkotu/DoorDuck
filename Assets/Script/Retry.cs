using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Retry : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)){
            if(gameObject.GetComponent<PlayerController>().start)ParameterManager.instance.DownCount();       
        }        
    }
}
