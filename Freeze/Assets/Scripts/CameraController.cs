using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject target;

    private Vector3 positionOffset;

    // Start is called before the first frame update
    void Start()
    {
        positionOffset = new Vector3(transform.position.x - target.transform.position.x, transform.position.y, -10f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.transform.position.x, 0, 0) + positionOffset;
    }
}
