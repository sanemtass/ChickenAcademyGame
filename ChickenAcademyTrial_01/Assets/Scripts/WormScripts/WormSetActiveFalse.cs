using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormSetActiveFalse : MonoBehaviour
{
    public bool canRunAway = true;
    [SerializeField]
    float replaceTime = 5f;
    WormAnimationController wormAnimationController;

    private void Start()
    {
        wormAnimationController = GetComponentInChildren<WormAnimationController>();
    }

    private void Update()
    {
        StartCoroutine(ReplaceWorm());
    }

    IEnumerator ReplaceWorm()
    {
        while (PlayerCollision.isWormCollecting == false)
        {
            yield return new WaitForSeconds(replaceTime);

            if (canRunAway)
            {
               // wormAnimationController.Inside();
                yield return new WaitForSeconds(1.6f);
                gameObject.SetActive(false);                
            }
        }
    }
}
