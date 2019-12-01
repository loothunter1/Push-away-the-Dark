using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttackScript : MonoBehaviour
{
    public float energy = 0;
    public float energyMax = 1;
    public float energyRecoverRate = .1f;
    public float energyCostAttack = 1f;
    public float energyCostMove = 1f;
    public Slider energyBar;

    public float health = 10;
    public float healthMax = 10;
    public Slider healthBar;

    public float damage = 1;
    // Start is called before the first frame update
    void Start()
    {
        energyBar.minValue = 0;
        energyBar.maxValue = energyMax;

        healthBar.minValue = 0;
        healthBar.maxValue = healthMax;
    }

    // Update is called once per frame
    void Update()
    {
        if (energy < energyMax)
        {
            energy += energyRecoverRate * Time.deltaTime;
        }
        energyBar.value = energy;
        healthBar.value = health;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            health -= other.GetComponent<MonsterAttackScript>().damage;
            if (health <= 0)
                GameObject.FindGameObjectWithTag("GameController").GetComponent<GameOverScript>().GameOver();
        }
    }

    public float AttackDamage()
    {
        if (energy >= energyMax)
        {
            energy = 0;
            return damage;
        }
        else
        {
            return 0;
        }
    }
}
