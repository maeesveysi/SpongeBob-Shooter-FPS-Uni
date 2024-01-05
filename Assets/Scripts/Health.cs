using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
public class Health : MonoBehaviour
{
    public int health;
    [Header ("UI")]
    public TextMeshProUGUI healthTxt;
    [PunRPC]
    public void TakeDamage(int _damage)
    {
        healthTxt.text = health.ToString();
        health -= -_damage;
        if (health <=0)
        {
            Destroy(gameObject);
        }
    }
}
