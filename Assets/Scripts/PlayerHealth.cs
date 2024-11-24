using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float healthMax;
    public Image healthBar;

    private bool isDead;
    public GameManagerScript gameManager;
    // Start is called before the first frame update
    void Start()
    {
        healthMax = health;
    
    }
    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / healthMax,0, 1);

        if(health <= 0 && !isDead)  
        {
            gameObject.SetActive(false);
            isDead = true;
            gameManager.gameOver();
        } 
    }
}
