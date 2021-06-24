using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private bool holding = false;
    public static bool canGo = true;
    private float speedModifier;

    private float speedOnZAxis = 30f;
    private float xLimitL=-22.3f;
    private float xLimitR=22.3f;


    public static bool dragToStartBool = false;
    // Start is called before the first frame update
    void Awake()
    {
        dragToStartBool = false;
        holding = false;
        canGo = true;
    }
    void Start()
    {
        speedModifier = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            holding = true;
            dragToStartBool = true;
            cameraFollowScript.searchPlayer = false;

        }
        if (holding && canGo)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x + Input.mousePosition.normalized.x * speedModifier,xLimitL,xLimitR), transform.position.y, transform.position.z);
        }
        if (Input.GetMouseButtonUp(0))
        {
            holding = false;
        }
        
    }

    void FixedUpdate()
    {
        if (canGo && dragToStartBool)
        {
            transform.position += new Vector3(0, 0, 1f) * Time.deltaTime * speedOnZAxis;

        }
        //speedOnZAxis += Time.deltaTime / 20;
    }

    private void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag == "topPlaneEnd")
        {
            BoxCollider[] bcs = coll.gameObject.GetComponents<BoxCollider>();
            bcs[0].enabled = false;
            bcs[1].enabled = false;
            canGo = false;
        }

        if (coll.gameObject.tag == "topPlaneStart")
        {
            BoxCollider[] bcs = coll.gameObject.GetComponents<BoxCollider>();
            bcs[0].enabled = false;
            bcs[1].enabled = false;
            bottomPlaneScript.counterInt = 0;
        }
    }
}
