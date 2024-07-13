using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public string shipName;
    public int maxHealth;
    private int currentHealth;

    public int speed;
    public int attack;
    public int handling;


    public void SelectedAnimation()
    {
        StartCoroutine(SelectedAnimationRoutine());

    }
    IEnumerator SelectedAnimationRoutine()
    {
        while (true)
        {
            transform.position += transform.forward;
            yield return new WaitForSeconds(0.1f);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
