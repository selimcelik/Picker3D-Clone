using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using ManagerActorFramework;

public class bottomPlaneScript : Actor<LevelManager>
{
    private bool firstTouch = true;
    public static int counterInt = 0;

    public bool canControl = false;

    protected override void MB_Awake()
    {
        firstTouch = true;
        canControl = false;
    }

    private void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag == "Ball")
        {
            if (firstTouch)
            {
                StartCoroutine(levelFailedController());
                firstTouch = false;
            }
            SphereCollider[] scs = coll.gameObject.GetComponents<SphereCollider>();
            scs[0].enabled = false;
            scs[1].enabled = false;
            Destroy(coll.gameObject, 1);
            counterInt++;
        }
    }

    IEnumerator levelFailedController()
    {
        yield return new WaitForSeconds(3);
        canControl = true;
    }
}
