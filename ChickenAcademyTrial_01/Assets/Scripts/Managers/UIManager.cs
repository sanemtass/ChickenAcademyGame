using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Pathfinding;

public class UIManager : MonoBehaviour
{
    public float workerChickenSpeed;
    public int playerSpeedParameter;

    public int playerEggStackLimit;
    public int playerWormStackLimit;

    public int incubatorSpawnTime;
    public int incubatorEggLimit;

    public int workerChickenStackCount;

    [Header("MainUI")]
    public Button hapticButton;
    public TextMeshProUGUI goldCounterText;
    public TextMeshProUGUI eggCounterText;
    public TextMeshProUGUI wormCounterText;

    [Header("UpgradeUI")]

    public Button characterUpgradeActive;
    public Button chickenUpgradeActive;
    public Button incubationUpgradeActive;
    public Button characterUpgradeDeactive;
    public Button chickenUpgradeDeactive;
    public Button incubationUpgradeDeactive;

    [Header("WeaponUpgradeButtons")]
    public GameObject ak47UpgradeButton;
    public GameObject bazookaUpgradeButton;
    public GameObject weaponMax;

    [Header("WorkerChickenUpgradeButtons")]
    public GameObject workerChickenSpeedButton;
    public GameObject workerChickenSpeedMax;
    public GameObject workerChickenStackButton;
    public GameObject workerChickenStackMax;
 

    [Header("IncomeUpgradeeButtons")]
    public GameObject incomeUpgradeButton;
    public GameObject incomeMax;

    [Header("PlayerUpgradeButtons")]
    public GameObject playerSpeedUpgradeButton;
    public GameObject playerSpeedUpgradeMax;

    public GameObject playerStackUpgradeButton;
    public GameObject playerStackUpgradeMax;

    [Header("IncubatorUpgradeButtons")]
    public GameObject incubatorSpeedUpgradeButton;
    public GameObject incubatorSpeedUpgradeMax;
    public GameObject incubatorStackUpgradeButton;
    public GameObject incubatorStackUpgradeMax;

    [Header("Panels")]
    public GameObject characterUpgradePanel;
    public GameObject chickenUpgradePanel;
    public GameObject incubationUpgradePanel;

    public GameObject characterButtonActive;
    public GameObject chickenButtonActive;
    public GameObject incubationButtonActive;

    public GameObject characterButtonDeactive;
    public GameObject chickenButtonDeactive;
    public GameObject incubationButtonDeactive;

    public bool ak47Activated = false;
    public bool bazookaActivated;

    [Header("UpgradeBuilding")]
    public Image upgradeImage;
    public float upgradeFill;
    public GameObject upgradePanel;
    public GameObject notEnoughGoldImage;

    private static UIManager instance = null;
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("uiManager").AddComponent<UIManager>();
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
        //PlayerPrefs.GetInt("ChickenSpeedUpg")


        workerChickenSpeed = PlayerPrefs.GetInt("WorkerChickenSpeed") + 4;
        playerSpeedParameter = PlayerPrefs.GetInt("PlayerSpeed") + 5;
        playerWormStackLimit = PlayerPrefs.GetInt("PlayerStackUpgraded") + 4;
        playerEggStackLimit = PlayerPrefs.GetInt("PlayerStackUpgraded") + 3;
        incubatorSpawnTime = PlayerPrefs.GetInt("IncubatorSpeedUpgraded") + 2;
        incubatorEggLimit = PlayerPrefs.GetInt("IncubatorStackUpgraded") + 3;
        workerChickenStackCount = PlayerPrefs.GetInt("StackUpgraded") + 3;
        Debug.Log(playerWormStackLimit);
        upgradePanel.SetActive(false);
        upgradeFill = 0;
        bazookaUpgradeButton.SetActive(false);
        ak47UpgradeButton.SetActive(true);
        weaponMax.SetActive(false);
        workerChickenSpeedMax.SetActive(false);
        notEnoughGoldImage.SetActive(false);
        upgradePanel.SetActive(false);
    }

    void Update()
    {
        UpgradeControl();
        //upgradeImage.fillAmount = upgradeFill;
        wormCounterText.text = PlayerCollision.targetProgress.ToString();
        goldCounterText.text = RewardManager.Instance.TotalGold.ToString();

    }

    private void UpgradeControl()
    {
        if (PlayerPrefs.GetInt("ChickenSpeedUpgraded") == 1)
        {
            workerChickenSpeedButton.SetActive(false);
            workerChickenSpeedMax.SetActive(true);
        }
        if (PlayerPrefs.GetInt("AK47Upgraded") == 1)
        {
            ak47UpgradeButton.SetActive(false);
            bazookaUpgradeButton.SetActive(true);
        }
        if (PlayerPrefs.GetInt("BazookaUpgraded") == 1)
        {
            bazookaUpgradeButton.SetActive(false);
            weaponMax.SetActive(true);
        }
        if (PlayerPrefs.GetInt("PlayerSpeedUpgraded") == 1)
        {
            playerSpeedUpgradeButton.SetActive(false);
            playerSpeedUpgradeMax.SetActive(true);
        }
        if (PlayerPrefs.GetInt("IncomeUpgraded") == 1)
        {
            incomeUpgradeButton.SetActive(false);
            incomeMax.SetActive(true);
        }
        if (PlayerPrefs.GetInt("PlayerStackUpgraded") == 1)
        {
            playerStackUpgradeButton.SetActive(false);
            playerStackUpgradeMax.SetActive(true);
        }
        if (PlayerPrefs.GetInt("IncubatorSpeedUpgraded") == 1)
        {
            incubatorSpeedUpgradeButton.SetActive(false);
            incubatorSpeedUpgradeMax.SetActive(true);
        }
        if (PlayerPrefs.GetInt("StackUpgraded") == 1)
        {
            workerChickenStackButton.SetActive(false);
            workerChickenStackMax.SetActive(true);
        }
        
    }
    public void CharacterUpgradePanelOpen()
    {

        characterUpgradePanel.SetActive(true);
        chickenUpgradePanel.SetActive(false);
        incubationUpgradePanel.SetActive(false);

        characterButtonActive.SetActive(true);
        characterButtonDeactive.SetActive(false);

        chickenButtonActive.SetActive(false);
        chickenButtonDeactive.SetActive(true);

        incubationButtonActive.SetActive(false);
        incubationButtonDeactive.SetActive(true);


    }
    public void ChickenUpgradePanelOpen()
    {

        characterUpgradePanel.SetActive(false);
        chickenUpgradePanel.SetActive(true);
        incubationUpgradePanel.SetActive(false);

        characterButtonActive.SetActive(false);
        characterButtonDeactive.SetActive(true);

        chickenButtonActive.SetActive(true);
        chickenButtonDeactive.SetActive(false);

        incubationButtonActive.SetActive(false);
        incubationButtonDeactive.SetActive(true);


    }
    public void IncubationUpgradePanelOpen()
    {

        characterUpgradePanel.SetActive(false);
        chickenUpgradePanel.SetActive(false);
        incubationUpgradePanel.SetActive(true);

        characterButtonActive.SetActive(false);
        characterButtonDeactive.SetActive(true);

        chickenButtonActive.SetActive(false);
        chickenButtonDeactive.SetActive(true);

        incubationButtonActive.SetActive(true);
        incubationButtonDeactive.SetActive(false);
    }
    public void OpenUpgradePanel()
    {
        upgradePanel.SetActive(true);
    }
    public void CloseUpgradePanel()
    {

        upgradePanel.SetActive(false);
    }
    public void CharacterSpeedUpgrade()
    {
        if (RewardManager.Instance.TotalGold > 143)
        {
            playerSpeedParameter += 2;
            playerSpeedUpgradeButton.SetActive(false);
            playerSpeedUpgradeMax.SetActive(true);
            PlayerPrefs.SetInt("PlayerSpeedUpgraded", 1);
            RewardManager.Instance.TotalGold = PlayerPrefs.GetInt("CountCoin") - 143;
            PlayerPrefs.SetInt("CountCoin", PlayerPrefs.GetInt("CountCoin") - 143);
            PlayerPrefs.SetInt("PlayerSpeed", (int)playerSpeedParameter);
            Debug.Log(playerSpeedParameter);
        }
        else
        {
            StartCoroutine(NotEnoughGold());
        }
    }
    public void IncomeUpgrade()
    {
        if (RewardManager.Instance.TotalGold > 143)
        {
            Debug.Log("Income tetiklendi");
            RewardManager.Instance.coinValue += 1;
            incomeUpgradeButton.SetActive(false);
            incomeMax.SetActive(true);
            PlayerPrefs.SetInt("IncomeUpgraded", 1);
            RewardManager.Instance.TotalGold = PlayerPrefs.GetInt("CountCoin") - 143;
            PlayerPrefs.SetInt("CountCoin", PlayerPrefs.GetInt("CountCoin") - 143);
            PlayerPrefs.SetInt("Income", RewardManager.Instance.coinValue);
        }
        else
        {
            StartCoroutine(NotEnoughGold());
        }
    }
    public void Ak47Upgrade()
    {
        if (RewardManager.Instance.TotalGold > 143)
        {
            ak47Activated = true;
            ak47UpgradeButton.SetActive(false);
            bazookaUpgradeButton.SetActive(true);
            PlayerPrefs.SetInt("AK47Upgraded", 1);
            RewardManager.Instance.TotalGold = PlayerPrefs.GetInt("CountCoin") - 143;
            PlayerPrefs.SetInt("CountCoin", PlayerPrefs.GetInt("CountCoin") - 143);
        }
        else
        {
            StartCoroutine(NotEnoughGold());
        }

    }
    public void BazookaUpgrade()
    {
        if (RewardManager.Instance.TotalGold > 143)
        {
            bazookaActivated = true;
            bazookaUpgradeButton.SetActive(false);
            weaponMax.SetActive(true);
            PlayerPrefs.GetInt("BazookaUpgraded", 1);
            RewardManager.Instance.TotalGold = PlayerPrefs.GetInt("CountCoin") - 143;
            PlayerPrefs.SetInt("CountCoin", PlayerPrefs.GetInt("CountCoin") - 143);
        }
        else
        {
            StartCoroutine(NotEnoughGold());
        }
    }
    public void WorkerChickenSpeedUpgrade()
    {
        if (RewardManager.Instance.TotalGold > 143)
        {
            workerChickenSpeed += 20;
            workerChickenSpeedButton.SetActive(false);
            workerChickenSpeedMax.SetActive(true);
            PlayerPrefs.SetInt("ChickenSpeedUpgraded", 1);
            RewardManager.Instance.TotalGold = PlayerPrefs.GetInt("CountCoin") - 143;
            PlayerPrefs.SetInt("CountCoin", PlayerPrefs.GetInt("CountCoin") - 143);
            PlayerPrefs.SetInt("WorkerChickenSpeed", (int)workerChickenSpeed);
        }
        else
        {
            StartCoroutine(NotEnoughGold());
        }
    }
    public void WorkerChickenStackUpgrade()
    {
        if (RewardManager.Instance.TotalGold > 143)
        {
            workerChickenStackCount++;
            workerChickenStackButton.SetActive(false);
            workerChickenStackMax.SetActive(true);
            PlayerPrefs.SetInt("StackUpgraded",1);
            RewardManager.Instance.TotalGold = PlayerPrefs.GetInt("CountCoin") - 143;
            PlayerPrefs.SetInt("CountCoin", PlayerPrefs.GetInt("CountCoin") - 143);
            PlayerPrefs.SetInt("StackUpgraded", workerChickenStackCount);
        }
    }
    public void PlayerStackUpgrade()
    {
        if (RewardManager.Instance.TotalGold > 143)
        {
            playerEggStackLimit++;
            playerWormStackLimit++;
            playerStackUpgradeButton.SetActive(false);
            playerStackUpgradeMax.SetActive(true);
            PlayerPrefs.SetInt("PlayerStackUpgraded", 1);
            RewardManager.Instance.TotalGold = PlayerPrefs.GetInt("CountCoin") - 143;
            PlayerPrefs.SetInt("CountCoin", PlayerPrefs.GetInt("CountCoin") - 143);
            PlayerPrefs.SetInt("PlayerStackUpgraded", playerEggStackLimit);

        }
        else
        {
            StartCoroutine(NotEnoughGold());
        }
    }
    public void IncubatorsSpeedUpgrade()
    {
        if (RewardManager.Instance.TotalGold > 143)
        {
            incubatorSpawnTime--;
            incubatorSpeedUpgradeButton.SetActive(false);
            incubatorSpeedUpgradeMax.SetActive(true);
            PlayerPrefs.SetInt("IncubatorSpeedUpgraded", 1);
            RewardManager.Instance.TotalGold = PlayerPrefs.GetInt("CountCoin") - 143;
            PlayerPrefs.SetInt("CountCoin", PlayerPrefs.GetInt("CountCoin") - 143);
            PlayerPrefs.SetInt("IncubatorSpeedUpgraded", incubatorSpawnTime);

        }
        else
        {
            StartCoroutine(NotEnoughGold());
        }
    }
    public void IncubatorsStackUpgrade()
    {
        if (RewardManager.Instance.TotalGold > 143)
        {
            incubatorEggLimit++;
            incubatorStackUpgradeButton.SetActive(false);
            incubatorStackUpgradeMax.SetActive(true);
            PlayerPrefs.SetInt("IncubatorStackUpgraded", 1);
            RewardManager.Instance.TotalGold = PlayerPrefs.GetInt("CountCoin") - 143;
            PlayerPrefs.SetInt("CountCoin", PlayerPrefs.GetInt("CountCoin") - 143);
            PlayerPrefs.SetInt("IncubatorStackUpgraded", incubatorEggLimit);
        }
        else
        {
            StartCoroutine(NotEnoughGold());
        }
    }

    IEnumerator NotEnoughGold()
    {
        notEnoughGoldImage.SetActive(true);
        yield return new WaitForSeconds(1f);
        notEnoughGoldImage.SetActive(false);
    }
}
