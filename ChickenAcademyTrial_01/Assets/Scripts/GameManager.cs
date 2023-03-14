using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameObject enemyGroup;
    public int xPos, zPos;
    public int enemyCount;
    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        while (enemyCount < 4)
        {
            xPos = Random.Range(-28, 27);
            zPos = Random.Range(18, 28);
            Vector3 rot = transform.eulerAngles + new Vector3(0, 180, 0);
            Instantiate(enemyGroup, new Vector3(xPos, 0, zPos), Quaternion.Euler(rot));
            yield return new WaitForSeconds(0.1f);
            enemyCount += 1;
        }
    }
}
