using UnityEngine;
using Unity.Cinemachine;


public class ThirdPersonController : MonoBehaviour
{
    [SerializeField] private CinemachineCamera aimCamera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
     void Update()
    {
        if (Input.GetButton("Fire2"))
        {
            aimCamera.gameObject.SetActive(true);
        }
        else
        {
            aimCamera.gameObject.SetActive(false);
        }
    }
}

