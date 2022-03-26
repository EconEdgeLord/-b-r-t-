using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32 (1, 1, 1, 1);
    [SerializeField] Color32 hasPackageColor2 = new Color32(1, 2, 1, 2);
    [SerializeField] float destroySpeed;

    bool hasPackage;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("A whitty message");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package has been picked up.");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject,  destroySpeed);
            
        }
        if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Package has been delivered.");
            hasPackage = false;
            spriteRenderer.color = hasPackageColor2;
        }
    }
}