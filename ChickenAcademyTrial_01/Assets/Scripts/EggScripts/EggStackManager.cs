using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggStackManager : MonoBehaviour
{
    public static int pickUpedEggs = 0;
    public static EggStackManager instance;

    private float distanceObject;
    [SerializeField] private Transform eggObject;
    [SerializeField] private Transform eggParent;
    [SerializeField] private float distanceYObject;

    public List<GameObject> eggObjects;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        distanceObject = eggObject.localScale.y + distanceYObject; //y mesafesi kadar olmalı
    }

    public void PickUp(GameObject pickedObject, bool needTag = false, string tag = null, bool downOrUp = true)
    {
        eggObjects.Add(pickedObject);
        if (needTag)
        {
            pickedObject.tag = tag;
        }
        pickUpedEggs++;
        pickedObject.transform.parent = eggParent;
        Vector3 desPos = eggObject.localPosition;
        desPos.y += downOrUp ? distanceObject : -distanceObject;
        pickedObject.transform.localPosition = desPos;
        eggObject = pickedObject.transform;
    }
}