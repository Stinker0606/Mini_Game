using UnityEngine;
using Unity.Cinemachine;


public class ThirdPersonController : MonoBehaviour
{
    [SerializeField] private CinemachineCamera aimCamera;

    // Verweis auf das PlayerShooting-Skript
    public PlayerShooting playerShootingScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
     void Update()
    {
        if (Input.GetMouseButton(1))
        {
            aimCamera.gameObject.SetActive(true);
            if (playerShootingScript != null)
            {
                playerShootingScript.isAiming = true;
            }
        }
        else
        {
            aimCamera.gameObject.SetActive(false);
            if (playerShootingScript != null)
            {
                playerShootingScript.isAiming = false;
            }
        }
    }
}

