using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : PowerUp
{
    public int HealthIncrease;

    void Start()
    {
        HealthIncrease = 20;
    }

	public override void ApplyPowerUp(Player player)
	{
		player.PowerUp(HealthIncrease);
	}
}
