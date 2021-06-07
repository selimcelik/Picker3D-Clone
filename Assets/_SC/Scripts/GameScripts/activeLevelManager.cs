using ManagerActorFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class activeLevelManager : Actor<LevelManager>
{
    public GameObject[] bottomPlaneParrents;

    public GameObject topPlane;
    public GameObject bottomPlaneToUp;
    public GameObject topPlane1;
    public GameObject bottomPlaneToUp1;
    public GameObject topPlane2;
    public GameObject bottomPlaneToUp2;

    public RawImage toLevel1, toLevel2, toLevel3;
    public Text counterText, counterText1, counterText2, dragToStartText;

    private bool firstStep = true;
    private bool secondStep = false;
    private bool thirdStep = false;

    private bool levelEnd = false;
    private bool levelFailed = false;
    // Start is called before the first frame update
    protected override void MB_Awake()
    {
        bottomPlaneScript.counterInt = 0;
        levelEnd = false;
        levelFailed = false;
        firstStep = true;
        secondStep = false;
        thirdStep = false;
    }

    // Update is called once per frame
    protected override void MB_Update()
    {
        if (levelEnd)
        {
            Push(ManagerEvents.FinishLevel, true);
            levelEnd = false;
        }
        if (levelFailed)
        {
            Push(ManagerEvents.FinishLevel, false);
            levelFailed = false;
        }
        if (playerMovement.dragToStartBool)
        {
            dragToStartText.enabled = false;
        }

        if (bottomPlaneParrents[0].GetComponent<bottomPlaneScript>().canControl && firstStep &&bottomPlaneScript.counterInt <= LevelManager.Instance.levelActor.ballGoals[0])
        {
            levelFailed = true;
        }
        if (bottomPlaneParrents[1].GetComponent<bottomPlaneScript>().canControl && secondStep && bottomPlaneScript.counterInt <= LevelManager.Instance.levelActor.ballGoals[1])
        {
            levelFailed = true;
        }
        if (bottomPlaneParrents[2].GetComponent<bottomPlaneScript>().canControl && thirdStep && bottomPlaneScript.counterInt <= LevelManager.Instance.levelActor.ballGoals[2])
        {
            levelFailed = true;
        }

        if (firstStep && bottomPlaneScript.counterInt >= LevelManager.Instance.levelActor.ballGoals[0])
        {
            MeshCollider[] mcs = bottomPlaneToUp.transform.parent.gameObject.GetComponents<MeshCollider>();
            mcs[0].enabled = false;
            mcs[1].enabled = false;
            bottomPlaneToUp.SetActive(true);
            bottomPlaneToUp.transform.parent = topPlane.transform;
            bottomPlaneToUp.transform.DOMoveY(-0.1f, 1);
            //bottomPlaneScript.counterInt = 0;
            playerMovement.canGo = true;
            toLevel1.color = new Color32(57, 255, 0, 255);
            firstStep = false;
            secondStep = true;
        }
        if (secondStep && bottomPlaneScript.counterInt >= LevelManager.Instance.levelActor.ballGoals[1])
        {
            MeshCollider[] mcs = bottomPlaneToUp1.transform.parent.gameObject.GetComponents<MeshCollider>();
            mcs[0].enabled = false;
            mcs[1].enabled = false;
            bottomPlaneToUp1.SetActive(true);
            bottomPlaneToUp1.transform.parent = topPlane1.transform;
            bottomPlaneToUp1.transform.DOMoveY(-0.1f, 1);
            //bottomPlaneScript.counterInt = 0;
            playerMovement.canGo = true;
            toLevel2.color = new Color32(57, 255, 0, 255);
            secondStep = false;
            thirdStep = true;

        }
        if (thirdStep && bottomPlaneScript.counterInt >= LevelManager.Instance.levelActor.ballGoals[2])
        {
            MeshCollider[] mcs = bottomPlaneToUp2.transform.parent.gameObject.GetComponents<MeshCollider>();
            mcs[0].enabled = false;
            mcs[1].enabled = false;
            bottomPlaneToUp2.SetActive(true);
            bottomPlaneToUp2.transform.parent = topPlane2.transform;
            bottomPlaneToUp2.transform.DOMoveY(-0.1f, 1);
            //bottomPlaneScript.counterInt = 0;
            playerMovement.canGo = true;
            toLevel3.color = new Color32(57, 255, 0, 255);
            thirdStep = false;
            playerMovement.canGo = false;
            levelEnd = true;

        }
        counterText.text = bottomPlaneScript.counterInt.ToString() + "/" + LevelManager.Instance.levelActor.ballGoals[0].ToString();
        counterText1.text = bottomPlaneScript.counterInt.ToString() + "/" + LevelManager.Instance.levelActor.ballGoals[1].ToString();
        counterText2.text = bottomPlaneScript.counterInt.ToString() + "/" + LevelManager.Instance.levelActor.ballGoals[2].ToString();
    }
}
