using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.UI;
using Photon.Pun;
using TMPro;
public class Health : MonoBehaviour
{
    public int health;
    // public RectTransform healthbar;
    // private float OrriginalhealthbarSize;
    // public bool islocalplayer;

    [Header ("UI")]
    public TextMeshProUGUI healthTxt;
    // private void Start() 
    // {
    //     OrriginalhealthbarSize = healthbar.size    
    // }
    [PunRPC]
    public void TakeDamage(int _damage)
    {
        healthTxt.text = health.ToString();
        health -= _damage;
        if (health <=0)
        {
            // if (islocalplayer)
                // RoomManager.instance.Respawnplayer();
            Destroy(gameObject);
        }
    }
}
