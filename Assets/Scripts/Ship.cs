using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Ship : MonoBehaviour
{
    public string shipName;
    public int maxHealth;
    private int currentHealth;
    public Transform[] muzzles;
    public Camera Cam;
    

    public int speed;
    public int attack;
    public int handling;
    public int shootSpeed;
    public int projectileSpeed;


    public void SelectedAnimation()
    {
        StartCoroutine(SelectedAnimationRoutine());

    }
    IEnumerator SelectedAnimationRoutine()
    {
        while (true)
        {
            transform.position += transform.forward*Time.deltaTime*5;
            yield return null;
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
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Floor"))
        {
            Destroy(gameObject);
        }
    }
}

