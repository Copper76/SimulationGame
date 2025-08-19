using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityUtils;

public class VillagerController : Singleton<VillagerController>
{
    private List<Villager> villagers = new List<Villager>();

    [SerializeField] private float villagerActionInterval = 1.0f;
    [SerializeField] private float villagerActionIntervalVariance = 0.2f;

    private float minVillagerActionIntervalVariance;
    private float maxVillagerActionIntervalVariance;

    protected override void Setup()
    {
        base.Setup();
        minVillagerActionIntervalVariance = Mathf.Max(0.0f, 1.0f - villagerActionIntervalVariance);
        maxVillagerActionIntervalVariance = 1.0f + villagerActionIntervalVariance;
    }

    public void RegisterVillager(Villager villager)
    {
        villagers.Add(villager);
    }

    private void Update()
    {
        float deltaTime = Time.deltaTime;
        foreach (Villager villager in villagers)
        {
            if (villager.AdvanceTimeStep(deltaTime))
            {
                villager.DetermineActionType();
                villager.Act();
                villager.SetNextActionTime(villagerActionInterval * Random.Range(minVillagerActionIntervalVariance, maxVillagerActionIntervalVariance));
            }
        }
    }
}
