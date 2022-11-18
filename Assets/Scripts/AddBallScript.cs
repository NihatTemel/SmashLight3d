using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AddBallScript : MonoBehaviour
{
    public int BallValue;
    [SerializeField] TMP_Text ValueText;
    void Start()
    {
        ValueText.text = "+" + BallValue;
    }

    
}
