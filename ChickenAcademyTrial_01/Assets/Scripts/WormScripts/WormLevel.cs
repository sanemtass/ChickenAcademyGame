using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormLevel : MonoBehaviour
{
    public  int wormLevel;
    public TextMesh text;

    void Start()
    {
        text.text = wormLevel.ToString();
    }
}
