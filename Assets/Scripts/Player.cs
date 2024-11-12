using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    int health = 10;
    public int Health => health; // read only property (เอาไปใช้ได้แต่ห้ามแก้)

    float strength = 10.0f;
    public float Strength => strength;

    float speed = 5.0f;
    public float Speed => speed;

    float originalSpeed;
    float SpeedBoostDuration = 0.0f; // How long the boost lasts
    float SpeedBoostTimer = 0.0f; // to track how much time has passed since the speed boost was activated
	bool IsSpeedBoostActive = false; // tracks whether the speed boost is currently active or not

	[SerializeField] TextMeshProUGUI healthTxT, strengthTxT, speedTxT;

	private void Start()
	{
        originalSpeed = speed;
        UpdateHealthText();
        UpdateSpeedText();
        UpdateStrengthText();
	}

	void Update()
	{
		UpdateSpeedBoostTimer();
	}

	void UpdateSpeedBoostTimer()
	{
		if (IsSpeedBoostActive)
		{
			SpeedBoostTimer += Time.deltaTime;
			Debug.Log("+++Speed Boost...");
			if (SpeedBoostTimer >= SpeedBoostDuration)
			{
				speed = originalSpeed;
				IsSpeedBoostActive = false;
				Debug.Log("Speed boost ended. Speed reset.");

			}
		}
	}

	public void PowerUp(int healthIncrease)
	{
		health += healthIncrease;
		Debug.Log($"Health increased by {healthIncrease}. New health: {health}");
		UpdateHealthText();
	}

	public void PowerUp(float strengthMultiplier)
	{
		strength *= strengthMultiplier;
		UpdateStrengthText() ;
		Debug.Log($"Strength  increased by {strengthMultiplier * 100}%. New Strength: {strength}");
	}
	public void PowerUp(float speedMultiplier, float duration)
	{
		if (!IsSpeedBoostActive)
		{
			speed *= speedMultiplier;
			IsSpeedBoostActive = true;
			SpeedBoostDuration = duration;
			SpeedBoostTimer = 0.0f;
			UpdateSpeedText() ;
			Debug.Log($"Speed boosted by {speedMultiplier * 100}% for {duration} seconds.");
		}
	}

	    void UpdateHealthText()
		{
			healthTxT.text = $"Health: {Health}";
		}

		void UpdateStrengthText()
		{
			strengthTxT.text = $"Strength: {Strength}";
		}

		void UpdateSpeedText()
		{
			speedTxT.text = $"Speed: {Speed}";
		}


}
