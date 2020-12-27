using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Miss : MonoBehaviour
{
    public float counttime;
    float _counttime;
    bool flag = true;

    void Start(){
        _counttime = counttime; 
    }

    void OnTriggerStay(Collider other){
        if(other.gameObject.tag == "Player"){
            _counttime -= Time.deltaTime;
            if(flag && _counttime < 0){
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
