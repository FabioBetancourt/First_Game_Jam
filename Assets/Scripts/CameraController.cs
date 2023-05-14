using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    private Vector3 offset = new Vector3(6,2,0);
    // Start is called before the first frame update
  

    // Update is called once per frame
    private void LateUpdate()
    {
        var playerPositionOffset = player.transform.position + offset;
        transform.position = new Vector3(transform.position.x, playerPositionOffset.y, playerPositionOffset.z);
    }
    }


