using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{
    [Header("TP AREA")]
    public Transform tujuanPosisi; 


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (tujuanPosisi != null)
            {

                other.transform.position = tujuanPosisi.position;
            }

        }
    }
}