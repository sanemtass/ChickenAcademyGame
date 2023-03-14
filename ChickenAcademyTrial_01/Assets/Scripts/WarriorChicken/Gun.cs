using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    //bullet force
    public float shootForce; 

    public Transform attackPoint;

    [SerializeField] LayerMask layerMask;

    public ParticleSystem muzzleFlash;


    [SerializeField] private float fireDistance;
    public RaycastHit hitInfo;

    private void Start()
    {
        muzzleFlash.Stop();
    }

    public void Shoot()
    {
        muzzleFlash.Play();

        Ray ray = new Ray(attackPoint.position, attackPoint.TransformDirection(Vector3.forward));

        //int layerMask = LayerMask.GetMask("Enemy");
        if(Physics.Raycast(ray, out hitInfo, 100, layerMask, QueryTriggerInteraction.Ignore))
        {
            //print("We hit: " + hit.transform.gameObject.tag);
            Debug.DrawRay(attackPoint.position, attackPoint.TransformDirection(Vector3.forward) * hitInfo.distance, Color.red);
            if (hitInfo.transform.gameObject.CompareTag("Enemy"))
            {
                hitInfo.transform.gameObject.GetComponent<EnemyHealthBehaviour>().EnemyTakeDamage(10);
                hitInfo.transform.gameObject.GetComponent<EnemyHealthBehaviour>().EnemyDie(hitInfo.transform.gameObject);
            }
            if (hitInfo.collider.transform.gameObject.CompareTag("WarriorChicken"))
            {
                hitInfo.transform.gameObject.GetComponent<WarriorChickenHealth>().ChickenTakeDamage(10);
                //Debug.Log(GameManager.Instance.chickenHealth.Health);
                hitInfo.transform.gameObject.GetComponent<WarriorChickenHealth>().ChickenDie(hitInfo.transform.gameObject);
            }
            if (hitInfo.transform.gameObject.CompareTag("Player"))
            {
                hitInfo.transform.gameObject.GetComponent<PlayerHealthBehaviour>().PlayerTakeDamage(10);
                //Debug.Log(GameManager.Instance.playerHealth.Health);
                hitInfo.transform.gameObject.GetComponent<PlayerHealthBehaviour>().PlayerRespawn();
            }

        }
        else
        {
            Debug.DrawRay(attackPoint.position, attackPoint.TransformDirection(Vector3.forward) * 100f, Color.green); 
        }


        //instanciate bullet
        //GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity);


        //GameObject currentBullet = ObjectPooling.Instance.GetPoolObject(6);
        //Vector3 position = attackPoint.position;
        //currentBullet.transform.position = position;


        //currentBullet.transform.forward = directionWithSpread.normalized;

        //add forces to bullet

        //currentBullet.GetComponent<Rigidbody>().AddForce(transform.forward * shootForce, ForceMode.Impulse);

        //currentBullet.GetComponent<Rigidbody>().AddForce(fpsCam.transform.up * upwardForce, ForceMode.Impulse); // merminin ziplamasini istiyorsan upwardForce,cokta gerek yok

       // StartCoroutine(DestroyBullet(currentBullet));

        //if (muzzleFlash != null)
        //{
        //    Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);
        //}

    }


}
