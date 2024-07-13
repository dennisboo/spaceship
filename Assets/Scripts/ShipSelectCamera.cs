using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSelectCamera : MonoBehaviour
{
    private bool isMoving;
    public ShipSelector selector;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && !isMoving && selector.currentShipSelection < selector.ships.Count)
        {
            Debug.Log(selector.currentShipSelection);
            StopAllCoroutines();
            StartCoroutine(MoveCameraRoutine(-10));
            selector.NextShip();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && !isMoving && selector.currentShipSelection > 0)
        {
            StopAllCoroutines();
            StartCoroutine(MoveCameraRoutine(10));
            selector.PreviousShip();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            selector.SelectShip();
        }
    }


    IEnumerator MoveCameraRoutine(int xMove)
    {
        isMoving = true;
        Vector3 targetLocation = transform.position;
        targetLocation.x += xMove;

        while (Vector3.Distance(transform.position, targetLocation) > 0.001f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetLocation, 20 * Time.deltaTime);
            yield return null;
           
        }
        isMoving = false;
    }
}
