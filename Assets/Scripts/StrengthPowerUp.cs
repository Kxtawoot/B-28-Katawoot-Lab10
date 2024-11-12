using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrengthPowerUp : PowerUp
{
	float strengthMutiplire = 2f;

	public override void ApplyPowerUp(Player player)
	{
		player.PowerUp(strengthMutiplire);
	}
}
