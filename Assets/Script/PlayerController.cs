using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Transform door1,door2;
    public GameObject duck,chicken,explosion,fire,items;
    public float power;
    bool ispush = false,crash = false,isfire = false;
    public RawImage energy;
    public Text retrytext;
    [System.NonSerialized]
    public bool kuttuki = false,phoenix = false,muscle = false;
    public bool start = false;
    public Button[] buttons;    

    void Start()
    {
        ItemControl();
    }

    // Update is called once per frame
    void Update()
    {
        if(start){
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
                if(!isfire && !phoenix){
                    energy.rectTransform.sizeDelta = new Vector2(energy.rectTransform.sizeDelta.x-2,energy.rectTransform.sizeDelta.y);
                    if(energy.rectTransform.sizeDelta.x <= 0){
                        energy.rectTransform.sizeDelta = new Vector2(0,energy.rectTransform.sizeDelta.y);
                        StartCoroutine(Fire(2,10,!phoenix));
                        isfire = true;
                    }
                }
                float angle;
                if(ispush){
                    angle = Mathf.LerpAngle(0, -60, 0.5f);
                    door1.localRotation = Quaternion.Euler(0, angle, 0);
                    door2.localRotation = Quaternion.Euler(0, angle, 0);                
                    gameObject.GetComponent<Rigidbody>().AddForce(transform.up * power);
                }else{
                    angle = Mathf.LerpAngle(0, 60, 0.5f);                
                    door1.localRotation = Quaternion.Euler(0, angle, 0);
                    door2.localRotation = Quaternion.Euler(0, angle, 0);                
                    gameObject.GetComponent<Rigidbody>().AddForce(transform.up * power);
                }
                ispush = !ispush;
            }
        }
    }

    void OnCollisionEnter(Collision col){
        if(!crash){
            if(col.gameObject.tag == "Destroy"){
                StartCoroutine(Fire(0,10,!phoenix));
                Explosion(col.contacts[0].point,15,200);
            }
        }
    }

    public void Explosion(Vector3 pos,float power,float radius){
        Instantiate(explosion,pos,Quaternion.identity);
        if(!crash){
            gameObject.GetComponent<PlayerController>().enabled = false;
            duck.tag = "Untagged";
            duck.transform.parent = null;
            for(int i=0; i<2; i++){
                GameObject tmp1 = duck.transform.GetChild(0).gameObject;
                tmp1.tag = "Untagged";
                tmp1.transform.parent = null;
                for(int j=0; j<2; j++){
                    GameObject tmp2 = tmp1.transform.GetChild(0).gameObject;
                    tmp2.AddComponent<Rigidbody>();
                    tmp2.GetComponent<Rigidbody>().AddExplosionForce(power, pos, radius, 3.0f, ForceMode.VelocityChange);
                    tmp2.tag = "Untagged";
                    tmp2.transform.parent = null;
                }
            }
            duck.SetActive(false);
            chicken.SetActive(true);
            retrytext.gameObject.SetActive(true);
            crash = true;
        }
        chicken.transform.root.GetComponent<Rigidbody>().AddExplosionForce(power, pos, radius, 3.0f, ForceMode.VelocityChange);
    }

    IEnumerator Fire(float waittime1,float waittime2,bool flag){
        yield return new WaitForSeconds(waittime1);
        fire.SetActive(true);
        if(flag){
            yield return new WaitForSeconds(waittime2);
            Explosion(transform.position,15,200);
        }
    }

    public void NormalMode(){
        items.SetActive(false);             
        start = true;
    }

    public void KuttukiMode(){
        kuttuki = true;
        ParameterManager.instance.DownPoint(3);
        items.SetActive(false);    
        start = true;        
    }

    public void PhoenixMode(){
        phoenix = true;
        energy.rectTransform.sizeDelta = new Vector2(0,energy.rectTransform.sizeDelta.y);            
        StartCoroutine(Fire(0,0,!phoenix));
        isfire = true;
        ParameterManager.instance.DownPoint(2);
        items.SetActive(false);
        start = true;
    }

    public void MuscleMode(){
        muscle = true;
        power *= 1.5f;
        ParameterManager.instance.DownPoint(1);
        items.SetActive(false);
        start = true;
    }

    void ItemControl(){
        if(ParameterManager.instance.pointnum >= 1){
            buttons[0].interactable = true;
        }
        if(ParameterManager.instance.pointnum >= 2){
            buttons[1].interactable = true;
        }
        if(ParameterManager.instance.pointnum >= 3){
            buttons[2].interactable = true;
        }
    }

}
