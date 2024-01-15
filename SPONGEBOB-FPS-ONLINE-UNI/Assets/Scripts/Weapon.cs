using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using Photon.Pun;
using TMPro;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("VFX")]
    public GameObject hitVFX;
    public int damage;
    public float fireRate;
    private float nextFire;
    public Camera camera;

    [Header ("Amoo")]
    public int mag = 5;
    public int ammo = 20;
    public int magaAmoo = 20;
    [Header ("UI")]
    public TextMeshProUGUI magtext;
    public TextMeshProUGUI ammotext;

    void Start ()
    {
        magtext.text = mag.ToString();
        ammotext.text = ammo + "/" + magaAmoo;
    }

    // Update is called once per frame
    void Update()
    {
        if (nextFire >0)
            nextFire -= Time.deltaTime;
        if (Input.GetButton("Fire1") && nextFire <=0 && ammo > 0  )
        {
            nextFire = 1/ fireRate;
            ammo--;

            magtext.text = mag.ToString();
            ammotext.text = ammo + "/" + magaAmoo;

            Fire();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }
    void Reload ()
    {
        
        if (mag > 0)
        {
            mag--;
            ammo = magaAmoo;
        }
        magtext.text = mag.ToString();
        ammotext.text = ammo + "/" + magaAmoo;
    }
    void Fire ()
    {
        Ray ray = new Ray(camera.transform.position, camera.transform.forward);

        RaycastHit hit;

        if (Physics.Raycast(ray.origin , ray.direction, out hit, 100f))
        {
            PhotonNetwork.Instantiate(hitVFX.name, hit.point,Quaternion.identity);
            if  (hit.transform.gameObject.GetComponent<Health>())
            {
                hit.transform.gameObject.GetComponent<PhotonView>().RPC("TakeDamage" , RpcTarget.All, damage);
            }
        }
    }
}
