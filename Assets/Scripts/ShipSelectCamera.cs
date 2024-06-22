using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSelectCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            StopAllCoroutines();
            StartCoroutine(MoveCameraRoutine(10));
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            StopAllCoroutines();
            StartCoroutine(MoveCameraRoutine(-10));
        }
    }


    IEnumerator MoveCameraRoutine(int xMove)
    {
        Vector3 targetLocation = transform.position;
        targetLocation.x += xMove;

        while (Vector3.Distance(transform.position, targetLocation) > 0.001f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetLocation, 20 * Time.deltaTime);
            yield return null;
        }
    }
}
