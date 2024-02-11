using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{

    public Text score;
    void Start()
    {

    }
    public void ModifyScore(float value)
    {
        score.text = value.ToString();
    }

}
