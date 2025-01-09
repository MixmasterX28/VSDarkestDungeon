using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickEnemy : MonoBehaviour
{
    [SerializeField] GameObject SoldierUI;
    [SerializeField] GameObject RabbleUI;
    [SerializeField] GameObject CultistUI;
    public void PressedSoldier()
    {
        if (RabbleUI.activeSelf) {
            RabbleUI.SetActive(false);  
            SoldierUI.SetActive(true);
        }
        else if (CultistUI.activeSelf) {
            CultistUI.SetActive(false);
            SoldierUI.SetActive(true);
        }
        else
        {
            SoldierUI.SetActive(true);
        }
    }
    public void PressedRabble() 
    {
        if (SoldierUI.activeSelf)
        {
            SoldierUI.SetActive(false);
            RabbleUI.SetActive(true);
        }
        else if (CultistUI.activeSelf)
        {
            CultistUI.SetActive(false);
            RabbleUI.SetActive(true);
        }
        else
        {
            RabbleUI.SetActive(true);
        }
   
    }

    public void PressedCultist()
    {
        if (RabbleUI.activeSelf)
        {
            RabbleUI.SetActive(false);
            CultistUI.SetActive(true);
        }
        else if (SoldierUI.activeSelf)
        {
            SoldierUI.SetActive(false);
            CultistUI.SetActive(true);
        }
        else
        {
            CultistUI.SetActive(true);
        }
      
    }
}
