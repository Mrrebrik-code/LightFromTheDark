using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    //Максимальное время заряда
    [SerializeField] private float _maxEnergyTime;
    //Текущее время заряда 
    public float EnergyTime;

    private void Awake()
    {
        EnergyTime = _maxEnergyTime;
    }

    private void Update()
    {
        if(EnergyTime > 0.0f)
        {
            EnergyTime -= Time.deltaTime;
            if (EnergyTime < 0.0f)
                EnergyTime = 0.0f;
        }
    }

    public void AddEnergy(float energy)
    {
        EnergyTime += energy;
        if (EnergyTime > _maxEnergyTime)
            EnergyTime = _maxEnergyTime;
    }
}
