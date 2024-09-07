using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipSelector : MonoBehaviour
{
    public List<Ship> ships;
    public StatsDisplay statsDisplay;

    public int currentShipSelection{ get; private set; }
    void Start()
    {
        
    }


    public void SelectShip()
    {
        Ship ship =   ships[currentShipSelection];
        statsDisplay.SetData(ship);
        GameManager.instance.SelectedShip = currentShipSelection;
        ship.SelectedAnimation();
        StartCoroutine(Wait());
        IEnumerator Wait()
        {
            yield return new WaitForSeconds(1.3f);
            SceneManager.LoadScene("GameScene");
        }
    }
    
    public void NextShip()
    {
        currentShipSelection += 1;
        Ship ship = ships[currentShipSelection];
        statsDisplay.SetData(ship);
    }

    public void PreviousShip()
    {
        currentShipSelection -= 1;
        Ship ship = ships[currentShipSelection];
        statsDisplay.SetData(ship);
    }


    // Start is called before the first frame update
   
    // Update is called once per frame
    void Update()
    {
        
    }
}
