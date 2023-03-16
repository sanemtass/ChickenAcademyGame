using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderController : MonoBehaviour
{
    public static float distance;
    public static bool onBattle = false;
    public RectTransform battlePanel;

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
            battlePanel.gameObject.SetActive(false);
        }
    }
  
    private IEnumerator UpgradePlane()
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
