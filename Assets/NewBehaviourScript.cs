using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform door1,door2;
    public float up,forward;
    bool ispush = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W)){
            transform.Rotate(new Vector3(0, 0, 0.8f));
        }
        if(Input.GetKey(KeyCode.A)){
            transform.Rotate(new Vector3(-0.5f, -0.5f,0));
        }
        if(Input.GetKey(KeyCode.S)){
            transform.Rotate(new Vector3(0, 0, -0.8f));
        }
        if(Input.GetKey(KeyCode.D)){
            transform.Rotate(new Vector3(0.5f, 0.5f,0));
        }                        
        //はばたく
        if(Input.GetMouseButtonDown(0)){
            float angle;
            if(ispush){
                angle = Mathf.LerpAngle(0, -60, 0.5f);
                door1.localRotation = Quaternion.Euler(0, angle, 0);
                door2.localRotation = Quaternion.Euler(0, angle, 0);                
                gameObject.GetComponent<Rigidbody>().AddForce((transform.up * up + transform.right * -forward) * 300);
            }else{
                angle = Mathf.LerpAngle(0, 60, 0.5f);                
                door1.localRotation = Quaternion.Euler(0, angle, 0);
                door2.localRotation = Quaternion.Euler(0, angle, 0);                
                gameObject.GetComponent<Rigidbody>().AddForce((transform.up * up + transform.right * -forward) * 300);
            }
            ispush = !ispush;
        }
    }
}
