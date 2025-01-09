using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickEnemy : MonoBehaviour
{
    [SerializeField] GameObject SoldierUI;
    [SerializeField] GameObject RabbleUI;
    [SerializeField] GameObject CultistUI;

    private void OnMouseOver()
    {
        SoldierUI.SetActive(true);
    }
    //public void PressedSoldier() //Als je op de skelly clicked dan komt de monstermanual
    //{
    //    if (RabbleUI.activeSelf) {
    //        RabbleUI.SetActive(false);
    //        SoldierUI.SetActive(true);
    //    }
    //    else if (CultistUI.activeSelf) {
    //        CultistUI.SetActive(false);
    //        SoldierUI.SetActive(true);
    //    }
    //    else
    //    {
    //        SoldierUI.SetActive(true);
    //    }
    //}
    //public void PressedRabble() //Als je op de skelly clicked dan komt de monstermanual
    //{
    //    if (SoldierUI.activeSelf)
    //    {
    //        SoldierUI.SetActive(false);
    //        RabbleUI.SetActive(true);
    //    }
    //    else if (CultistUI.activeSelf)
    //    {
    //        CultistUI.SetActive(false);
    //        RabbleUI.SetActive(true);
    //    }
    //    else
    //    {
    //        RabbleUI.SetActive(true);
    //    }
   
    //}

    //public void PressedCultist() //Als je op de cultist clicked dan komt de monstermanual
    //{
    //    if (RabbleUI.activeSelf)
    //    {
    //        RabbleUI.SetActive(false);
    //        CultistUI.SetActive(true);
    //    }
    //    else if (SoldierUI.activeSelf)
    //    {
    //        SoldierUI.SetActive(false);
    //        CultistUI.SetActive(true);
    //    }
    //    else
    //    {
    //        CultistUI.SetActive(true);
    //    }
      
    //}
}
