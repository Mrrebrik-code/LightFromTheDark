using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    //Максимальное время заряда
    [SerializeField] private float _maxEnergyTime;
    [SerializeField] private PlayerController _playerContr;

    //Текущее время заряда 
    public float EnergyTime { get; private set; }
    public float EnergyTimePercents 
    { 
        get{ return EnergyTime / _maxEnergyTime * 100f; }
    }

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
            {
                _playerContr.Death();
            }
        }
    }

    public void AddEnergy(float energy)
    {
        EnergyTime += energy;
        if (EnergyTime > _maxEnergyTime)
            EnergyTime = _maxEnergyTime;
    }
}
