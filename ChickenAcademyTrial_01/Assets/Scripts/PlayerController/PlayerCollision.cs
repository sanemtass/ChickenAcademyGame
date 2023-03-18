using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public static bool isWormCollecting = false;

    public static float targetProgress;

    public EggStackManager eggStackManager;

    public Animator animator;
    public int wormLimit;
    public bool ate;
    public bool eatAnim;
    public GameObject mouth;
    public GameObject wormHimself;

    private Rigidbody rb;
    private bool eat;
    private float distance;
    private float _distance;

    private void Start()
    {
        eat = false;
        rb = GetComponent<Rigidbody>();
        mouth = GameObject.Find("Mouth");
        animator = GetComponent<Animator>();
        wormHimself = null;
        ate = false;
    }

    public void Update()
    {
        wormLimit = UIManager.Instance.playerWormStackLimit;

        if (!ate)
        {
            PlayerMovement.speed = 350;
        }

        WormCatch();
        EatAnimTrue();
    }

    private void WormCatch()
    {
        if (ate && wormHimself != null)
        {
            distance = Vector3.Distance(transform.position, wormHimself.transform.position);
            gameObject.transform.LookAt(wormHimself.transform);
        }
        if (distance >= 4 && wormHimself != null)
        {
            try
            {
                mouth.transform.Find("Head").gameObject.transform.parent = wormHimself.transform.Find("Worm_Rig_bake_v1").gameObject.transform.Find("Armature").
                gameObject.transform.Find("SplinIK_3").gameObject.transform.Find("body").
                gameObject.transform;
                wormHimself.SetActive(false);
                wormHimself = null;
                var obj = ObjectPooling.Instance.GetPoolObject(4).gameObject;
                obj.transform.parent = mouth.transform;
                obj.transform.position = mouth.transform.position;
                gameObject.transform.Rotate(Vector3.zero);
                ate = false;
                distance = 0;
                targetProgress++;
                eatAnim = false;
            }
            catch
            {

            }
            PlayerMovement.speed = 350;
        }
    }

    private void EatAnimTrue()
    {
        eatAnim = true;
    }

    private void LateUpdate()
    {
        if (wormHimself != null)
        {
            _distance = Vector3.Distance(transform.position * 1000, wormHimself.transform.position * 1000);

            if (_distance > distance * 1000)
            {
                PlayerMovement.speed = 100;
            }
            if (distance * 1000 > _distance)
            {
                PlayerMovement.speed = 350;
            }
        }
        else
        {
            PlayerMovement.speed = 350;
        }
        if (eat)
        {
            animator.SetTrigger("eat");
            eat = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Worm") && targetProgress <= wormLimit)
        {
            eat = true;
        }

        if (other.gameObject.CompareTag("WormHead") && !ate && eatAnim)
        {
            wormHimself = other.gameObject.GetComponentInParent<WormLevel>().gameObject;

            if (wormHimself.GetComponent<WormLevel>().wormLevel <= CharacterLevelSystem._currentLevel && !ate)
            {
                if (targetProgress <= wormLimit)
                {
                    wormHimself.GetComponent<WormSetActiveFalse>().canRunAway = false;
                    other.gameObject.transform.parent = mouth.transform;
                    ate = true;
                    animator.SetTrigger("idle");
                    eatAnim = false;
                }

                else
                {
                    wormHimself = null;
                    PlayerMovement.speed = 350;
                }
            }

            else
            {
                PlayerMovement.speed = 350;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Worm") && targetProgress <= wormLimit)
        {
            eat = true;
        }
        if (other.CompareTag("WormHead") && wormHimself != null)
        {
            if (wormHimself.GetComponent<WormLevel>().wormLevel > CharacterLevelSystem._currentLevel)
            {
                wormHimself.transform.Find("Worm_Rig_bake_v1").gameObject.GetComponent<WormAnimationController>().Attack();
                new WaitForSeconds(1.5f);
                rb.AddForce(Vector3.back * 1000f * Time.deltaTime, ForceMode.Impulse);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isWormCollecting = false;

        if (other.CompareTag("WormHead"))
        {
            PlayerMovement.speed = 350;
            eatAnim = false;
        }
        if (other.CompareTag("Worm"))
        {
            PlayerMovement.speed = 350;
            eat = false;
            animator.SetTrigger("idle");
        }
    }

    public static void IncreaseTargetProgress()
    {
        targetProgress++;
    }
}
