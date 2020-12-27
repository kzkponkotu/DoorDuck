using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;

public class ParameterManager : MonoBehaviour {

    static public ParameterManager instance;
    public Text score,count,point;
    public int pointnum = 1;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void DownCount()
    {
        int countnum = int.Parse(Regex.Replace (count.text, @"[^0-9]", ""));
        count.text = "Count: " + (countnum - 1);
        if(countnum-1 <= 0)SceneManager.LoadScene("GameOver");
        else SceneManager.LoadScene("Stage");

    }

    public void AddScore(int _point)
    {
        score.text = "Score: " + (_point + int.Parse(Regex.Replace (score.text, @"[^0-9]", "")));
        pointnum++;
    }

    public void DownPoint(int _point)
    {
        pointnum-=_point;
    }

}