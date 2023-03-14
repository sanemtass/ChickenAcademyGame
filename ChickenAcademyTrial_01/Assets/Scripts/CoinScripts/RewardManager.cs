using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class RewardManager : MonoBehaviour
{
    [SerializeField] private GameObject PileOfCoinParent;
    //[SerializeField] private TextMeshProUGUI GoldCounter;
    [SerializeField] private Vector3[] InitialPos;
    [SerializeField] private Quaternion[] InitialRotation;
    [SerializeField] private int coinNo;
    public int coinValue = 1; //upgrade ile arttirilacak.
    private static RewardManager instance = null;
    public int TotalGold;
    public static RewardManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("RewardManager").AddComponent<RewardManager>();
            }
            return instance;
        }
    }
    private void OnEnable()
    {
        instance = this;
    }
    void Start()
    {
     
        InitialPos = new Vector3[coinNo];
        InitialRotation = new Quaternion[coinNo];
        //GoldCounter.text = PlayerPrefs.GetInt("CountCoin").ToString();
        


        for (int i = 0; i < PileOfCoinParent.transform.childCount; i++)
        {
            InitialPos[i] = PileOfCoinParent.transform.GetChild(i).position;
            InitialRotation[i] = PileOfCoinParent.transform.GetChild(i).rotation;
        }
    }
    public void Update()
    {
        TotalGold = PlayerPrefs.GetInt("CountCoin")+1000;
    }

    private void Reset()
    {
        for (int i = 0; i < PileOfCoinParent.transform.childCount; i++)
        {
            PileOfCoinParent.transform.GetChild(i).position = InitialPos[i];
            PileOfCoinParent.transform.GetChild(i).rotation = InitialRotation[i];
        }
    }


    public void RewardPileOfCoin(int noCoin)
    {
        Reset();

        var delay = 0f;
        PileOfCoinParent.SetActive(true);
        for (int i = 0; i < PileOfCoinParent.transform.childCount; i++)
        {
            PileOfCoinParent.transform.GetChild(i).DOScale(1f, .3f).SetDelay(delay).SetEase(Ease.OutBack);

            PileOfCoinParent.transform.GetChild(i).GetComponent<RectTransform>().DOAnchorPos(new Vector2(580f, 1420f), .5f).SetDelay(delay + .5f).SetEase(Ease.InBack);

            PileOfCoinParent.transform.GetChild(i).DORotate(Vector3.zero, .5f).SetDelay(delay + .5f).SetEase(Ease.Flash);

            PileOfCoinParent.transform.GetChild(i).DOScale(0f, .3f).SetDelay(delay + 1.8f).SetEase(Ease.OutBack);

            delay += .2f;
        }

        StartCoroutine(CountCoins(10));

    }
    IEnumerator CountCoins(int coinNo)
    {

        var timer = 0f;
        yield return new WaitForSeconds(.7f);
        for (int i = 0; i < coinNo; i++)
        {
            PlayerPrefs.SetInt("CountCoin", PlayerPrefs.GetInt("CountCoin") + coinValue);

           
            timer += .05f;
            yield return new WaitForSecondsRealtime(timer);
        }

    }

}
