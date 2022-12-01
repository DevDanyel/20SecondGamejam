using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    [SerializeField] private string tagName;

    public Image P2HealthBar;
    //public GameManager gm;

    public float maxHealth = 30;
    public float P2Health;

    void Start(){
        P2Health = maxHealth;
        P2HealthBar.fillAmount = 1;
    }

    public void LoseHealth(float hitPower){
        P2Health -= hitPower;
        UpdateHealth(maxHealth, P2Health);
    }

    public void UpdateHealth(float mHealth, float CHealth){
        P2HealthBar.fillAmount = CHealth / mHealth;
    }

    void Update(){
        
      /*if(Input.GetKeyDown(KeyCode.Space)){
            LoseHealth(3);
            UpdateHealth(maxHealth, P2Health);
        }*/

        if(P2Health == 0){
            Debug.Log("Deady dead dead dead");
            //gm.EndGame();
            //gm.RestartScore();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag(tagName)){
            LoseHealth(3);
            UpdateHealth(maxHealth, P2Health);
        }
    }


    

}
