using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetup : MonoBehaviour
{
   public PlayerMovement movement;
   public GameObject camera;

  public void islocalplayer ()
  {
    movement.enabled = true;
    camera.SetActive(true);
  }
}