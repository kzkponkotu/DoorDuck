using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    public Text result;

    // Start is called before the first frame update
    void Start()
    {
        
        ParameterManager.instance.count.enabled = false;
        result.text = ParameterManager.instance.score.text;
        ParameterManager.instance.score.enabled = false;        
        Destroy(ParameterManager.instance.gameObject.transform.root.gameObject);
    }
}
