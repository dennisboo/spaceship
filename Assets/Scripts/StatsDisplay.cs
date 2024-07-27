using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsDisplay : MonoBehaviour
{
    public TextMeshProUGUI shipNameText;
    public Transform healthBar;
    public Transform attackBar;
    public Transform speedBar;
    public Transform handlingBar;


    public void SetData(Ship ship)
    {
        shipNameText.SetText(ship.shipName);
        healthBar.localScale = new Vector3(ship.maxHealth * 0.01f, 1, 1);
        attackBar.localScale = new Vector3(ship.attack * 0.01f, 1, 1);
        speedBar.localScale = new Vector3(ship.speed * 0.01f, 1, 1);
        handlingBar.localScale = new Vector3(ship.handling * 0.01f, 1, 1);
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
