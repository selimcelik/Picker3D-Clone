using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollowScript : MonoBehaviour
{
    private GameObject player;
    public Vector3 offset;

    public static bool searchPlayer = false;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(searchPlayer)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            //searchPlayer = false;
        }

        if (!playerMovement.dragToStartBool)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x + offset.x, player.transform.position.y + offset.y, player.transform.position.z + offset.z), 10000 * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x + offset.x, player.transform.position.y + offset.y, player.transform.position.z + offset.z), 80 * Time.deltaTime);
        }

    }
}
