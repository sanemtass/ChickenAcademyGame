using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLevelSystem : MonoBehaviour
{
    public static int _currentLevel=1;

    public int _currentExp;
    [SerializeField]
    int _requireExp;
    public static int wormStack;
    public static int wormStackLimit;
  
    void Update()
    {     
        if (Input.GetKeyDown(KeyCode.S))
        {
            GetExp();
            Debug.Log("Current Level" + _currentLevel);
            Debug.Log("Current Exp" + _currentExp);
            Debug.Log("Required Exp" + _requireExp);
        }
    }
    void GetExp()
    {
        _currentExp += 100;

        if (_currentExp >= _requireExp)
        {
            _currentLevel += 1;
            _requireExp += 150;
            _currentExp = 0;
        }
    }
}
