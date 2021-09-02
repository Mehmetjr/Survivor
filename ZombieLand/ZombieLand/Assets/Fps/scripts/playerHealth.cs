using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{

    float LastAttackTime = 0;
    float Attackcooldown = 2;
    float health = 100.0f;
    public float currHealth = 100.0f;
    //public float damage;
    public GameObject gameOverMenu;
    public Image healthBar;
    public GameObject cube;
    public GameObject cube1;
    public GameObject cube2;
    public GameObject cube3;
    public GameObject cube4;
    public GameObject cube5;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Hips")
        {

            if (Time.time - LastAttackTime >= Attackcooldown)
            {
                LastAttackTime = Time.time;
                currHealth -= 10;
                healthBar.fillAmount = currHealth / health;
                Debug.Log(currHealth);
                if (currHealth <= 0)
                {
                    Time.timeScale = 0;
                    Debug.Log("Game Over");
                    gameOverMenu.SetActive(true);

                }
            }

        }

        if (collision.gameObject.name == "HealthBox")
        {
            if (currHealth != 100)
            {
                currHealth += 10;
                healthBar.fillAmount = currHealth / health;
                Destroy(cube);
            }


        }
        if (collision.gameObject.name == "HealthBoxOne")
        {
            if (currHealth != 100)
            {
                currHealth += 10;
                healthBar.fillAmount = currHealth / health;
                Destroy(cube1);
            }


        }
        if (collision.gameObject.name == "HealthBoxTwo")
        {
            if (currHealth != 100)
            {
                currHealth += 10;
                healthBar.fillAmount = currHealth / health;
                Destroy(cube2);
            }


        }
        if (collision.gameObject.name == "HealthBoxThree")
        {
            if (currHealth != 100)
            {
                currHealth += 10;
                healthBar.fillAmount = currHealth / health;
                Destroy(cube3);
            }


        }
        if (collision.gameObject.name == "HealthBoxFour")
        {
            if (currHealth != 100)
            {
                currHealth += 10;
                healthBar.fillAmount = currHealth / health;
                Destroy(cube4);
            }


        }
        if (collision.gameObject.name == "HealthBoxFive")
        {
            if (currHealth != 100)
            {
                currHealth += 10;
                healthBar.fillAmount = currHealth / health;
                Destroy(cube5);
            }


        }
    }
}
