using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSliderController : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] Transform Player;
    [SerializeField] Transform Finish;

   public float startPos;
    public float TotalDistance;
    public float moveddistance;
    public float slidervalue;

    void Start()
    {
        startPos = Player.position.x;
        TotalDistance = Finish.position.x - Player.position.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveddistance = Player.position.x - startPos  ;
        slidervalue = moveddistance/ TotalDistance ;
        slider.value = slidervalue;
    }
}
