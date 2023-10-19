using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasBluePackageColor = new Color32 (1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 hasRedPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 hasGreenPackageColor = new Color32(1, 1, 1, 1);


    [SerializeField] float destroyDelay = 0.5f;
    bool hasGreenPackage = false;
    bool hasBluePackage = false;
    bool hasRedPackage = false;

    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Ouch!");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BluePackage" && !hasBluePackage && !hasRedPackage && !hasGreenPackage)
        {
            Debug.Log("Blue Package picked up!");
            hasBluePackage = true;
            spriteRenderer.color = hasBluePackageColor;
            Destroy(collision.gameObject, destroyDelay);

        }

        if (collision.tag == "GreenPackage" && !hasGreenPackage && !hasBluePackage && !hasRedPackage)
        {
            Debug.Log("Green Package picked up!");
            hasGreenPackage = true;
            spriteRenderer.color = hasGreenPackageColor;
            Destroy(collision.gameObject, destroyDelay);

        }

        if (collision.tag == "RedPackage" && !hasRedPackage && !hasGreenPackage && !hasBluePackage)
        {
            Debug.Log("Red Package picked up!");
            hasRedPackage = true;
            spriteRenderer.color = hasRedPackageColor;
            Destroy(collision.gameObject, destroyDelay);

        }


        if (collision.tag == "BlueCustomer" && hasBluePackage )
        {
            Debug.Log("Package delivered!");
            hasBluePackage = false;
            spriteRenderer.color = noPackageColor;
        }

        if (collision.tag == "GreenCustomer" && hasGreenPackage )
        {
            Debug.Log("Package delivered!");
            hasGreenPackage = false;
            spriteRenderer.color = noPackageColor;
        }

        if (collision.tag == "RedCustomer" && hasRedPackage)
        {
            Debug.Log("Package delivered!");
            hasRedPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }
}
