using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterInRoom : ObjectInRoom
{
    float health;
    public float healthMax = 1;
    public Slider healthBar;
    bool engaged = false;
    bool alive = true;
    PlayerAttackScript player;
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponentInParent<PlayerAttackScript>();
        healthBar.maxValue = healthMax;
        health = healthMax;
    }

    // On click
    public override void OnClick()
    {
        Debug.Log("Clicked on monster in the room!");
        LogAction("Clicked on monster in the room!");
        float damageFromPlayer = player.AttackDamage();

        if (damageFromPlayer > 0)
        {
            if (!engaged)
                engaged = true;
            health -= damageFromPlayer;
            LogAction("Dealt "+damageFromPlayer.ToString()+" damage.");
            UpdateHealthBar();
            if (health <= 0)
            {
                alive = false;
                LogAction("Monster is killed!");
                Destroy(gameObject);
            }
        }
    }

    void UpdateHealthBar()
    {
        healthBar.value = health;
        healthBar.gameObject.SetActive(engaged);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
