using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class colliderController : MonoBehaviour
{
    public static float distance;
    public static bool onBattle = false;
    public RectTransform battlePanel;

    private void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("UpgradeZone"))
        {
       
            StartCoroutine(UpgradePlane());
        }
    }
    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("UpgradeZone"))
        {
            StartCoroutine(UpgradePlane());
        }

        if (collision.gameObject.CompareTag("Battle"))
        {            
            //onBattle = true;
            battlePanel.gameObject.SetActive(true);
        }

    }

    public void Battle()
    {
        onBattle = true;
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("UpgradeZone"))
        {
         
            StopAllCoroutines();
            UIManager.Instance.upgradeFill= 0;
            UIManager.Instance.upgradeImage.fillAmount = UIManager.Instance.upgradeFill;
            UIManager.Instance.CloseUpgradePanel();
        }

        if (collision.gameObject.CompareTag("Battle"))
        {
            //onBattle = true;
            battlePanel.gameObject.SetActive(false);
        }
    }
  
    IEnumerator UpgradePlane()
    {
        while (true)
        {
            yield return new WaitForSeconds(.1f);
            if (UIManager.Instance.upgradeFill <= 1)
            {
                UIManager.Instance.upgradeFill += 0.08f;
                UIManager.Instance.upgradeImage.fillAmount = UIManager.Instance.upgradeFill;
                if (UIManager.Instance.upgradeFill <= 1 && UIManager.Instance.upgradeFill >= 0.95f)
                {
                    UIManager.Instance.OpenUpgradePanel();
                }
            }
        }
    }  
}
