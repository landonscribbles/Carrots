﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sillyharvestbuttonscript : MonoBehaviour
{

    public Dropdown actionDropdown;


    //bad, hardcoded harvest call. This is written as if all each farmer does each round is harvest.
    public void TriggerHarvest()
    {
        foreach(GameObject farmer in GameObject.FindGameObjectsWithTag("Player"))
        {
            List<CascadiaSkill> temp = farmer.GetComponent<SkillSheet>().mySkills;

            CS_Harvesting temp_harvest = (CS_Harvesting)temp.Find(c => c.skillName == "Harvesting");
            CascadiaSkill botany = temp.Find(c => c.skillName == "Botany");
            CascadiaSkill carrots = temp.Find(c => c.skillName == "Carrots");
            CascadiaSkill foodBearing = temp.Find(c => c.skillName == "Food Bearing");
            CascadiaSkill shrubs = temp.Find(c => c.skillName == "Shrubs");
            CascadiaSkill rootVegetables = temp.Find(c => c.skillName == "Root Vegetables");

            int maxCarrots = farmer.GetComponent<Farmer>().currentPlot.GetComponent<Plot>().localCarrots;
            int harvestedCarrots = temp_harvest.HarvestCarrots(carrots.skillValue, rootVegetables.skillValue, foodBearing.skillValue, shrubs.skillValue, botany.skillValue, maxCarrots);
            farmer.GetComponent<Farmer>().currentPlot.GetComponent<Plot>().localCarrots -= harvestedCarrots;
            Debug.Log("Carrots before harvest: " + GlobalVars.carrotStockpile);
            GlobalVars.carrotStockpile += harvestedCarrots;
            Debug.Log("Carrots after harvest: " + GlobalVars.carrotStockpile);
        }
       

        
    }


    //  When the GO button is pressed, determine which action is selected and go from there.
    // This only runs once. Need to update it to run for each Farmer.
    public void TriggerAction()
    {
        switch (actionDropdown.value)
        {
            case 0:
                TriggerHarvest();
                Rabbits.Breed();
                Rabbits.Feed();
                GlobalVars.currentTurn += 1;
                break;
            case 1:
                Debug.Log("Plant stub");
                break;
            case 2:
                Debug.Log("Gather Seed stub");
                break;
            case 3:
                Debug.Log("Inspect stub");
                break;

            default:
                Debug.Log("No action detected in the dropdown.");
                break;
        }
    }
}
