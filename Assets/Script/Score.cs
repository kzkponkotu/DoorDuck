using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public int point;
    public float counttime;
    float _counttime;
    bool flag = true;

    void Start(){
        _counttime = counttime; 
    }

    void OnTriggerStay(Collider other){
        if(other.gameObject.tag == "Player"){
            if(other.transform.root.GetComponent<PlayerController>().kuttuki){
                other.transform.root.GetComponent<Rigidbody>().velocity = Vector3.zero;
                other.transform.root.GetComponent<PlayerController>().enabled = false;
            }
            _counttime -= Time.deltaTime;
            if(flag && _counttime < 0){
                ParameterManager.instance.AddScore(point);
                flag = false;
                StartCoroutine("Next");
            }
        }else{
            _counttime = counttime;
        }
    }

    private IEnumerator Next(){
        yield return new WaitForSeconds(1.0f);
        ParameterManager.instance.DownCount();        
    }
}
