using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EggSpawnSlider : MonoBehaviour
{
    public Slider slider;

  
    void Update()
    {
        slider.value = SpawnEgg.stackCount / 4;
    }
}
