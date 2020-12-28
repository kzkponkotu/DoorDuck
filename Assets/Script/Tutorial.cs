using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class Tutorial : MonoBehaviour
{
    public GameObject duck;
    public GameObject[] steps;
    int count = 0,step = 0;
    bool start = true;

    // Start is called before the first frame update
    void Start()
    {
        if(int.Parse(Regex.Replace (ParameterManager.instance.score.text, @"[^0-9]", "")) > 0){
            gameObject.GetComponent<Tutorial>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(start && duck.GetComponent<PlayerController>().start){
            steps[count].SetActive(true);
            start = false;
        }

        if(count == 0 && Input.GetKey(KeyCode.Q)){
            StartCoroutine(NextStep());
            step = 1;
            count = -1;
        }

        if(count == 1 && Input.GetMouseButtonDown(0)){
            StartCoroutine(NextStep());
            step = 2;            
            count = -1;            
        }

        if(count == 2 && Input.GetKey(KeyCode.W)){
            StartCoroutine(NextStep());
            step = 3;            
            count = -1;
        }

        if(count == 3 && Input.GetKey(KeyCode.S)){
            StartCoroutine(NextStep());
            step = 4;            
            count = -1;            
        }

        if(count == 4 && Input.GetKey(KeyCode.A)){
            StartCoroutine(NextStep());
            step = 5;            
            count = -1;            
        }

        if(count == 5 && Input.GetKey(KeyCode.D)){
            StartCoroutine(NextStep());
            step = 6;            
            count = -1;            
        }

    }

    IEnumerator NextStep(){
        yield return new WaitForSeconds(3.0f);
        count = step-1;
        steps[count].SetActive(false);
        count++;
        if(count > 5){
            gameObject.GetComponent<Tutorial>().enabled = false;
        }else{
            steps[count].SetActive(true);
        }
    }

}
