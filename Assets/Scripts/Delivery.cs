using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Delivery : MonoBehaviour
{


    [SerializeField] Color32 hasBluePackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 hasRedPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 hasGreenPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] TextMeshProUGUI blueCount;
    [SerializeField] TextMeshProUGUI redCount;
    [SerializeField] TextMeshProUGUI greenCount;
    [SerializeField] float destroyDelay = 0.5f;

    bool hasGreenPackage = false;
    bool hasBluePackage = false;
    bool hasRedPackage = false;
    private bool allBoxesDelivered = false;


    public int RedCrate = 3;
    public int BlueCrate = 3;
    public int GreenCrate = 3;

    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateUI();
    }

    void UpdateUI()
    {
        blueCount.text = "X " + BlueCrate.ToString();
        redCount.text = "X " + RedCrate.ToString();
        greenCount.text = "X " + GreenCrate.ToString();
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

        if (collision.tag == "BlueCustomer" && hasBluePackage)
        {
            Debug.Log("Blue Package delivered!");
            hasBluePackage = false;
            spriteRenderer.color = noPackageColor;
            BlueCrate--;
            UpdateUI();
        }

        if (collision.tag == "GreenCustomer" && hasGreenPackage)
        {
            Debug.Log("Green Package delivered!");
            hasGreenPackage = false;
            spriteRenderer.color = noPackageColor;
            GreenCrate--;
            UpdateUI();
        }

        if (collision.tag == "RedCustomer" && hasRedPackage)
        {
            Debug.Log("Red Package delivered!");
            hasRedPackage = false;
            spriteRenderer.color = noPackageColor;
            RedCrate--;
            UpdateUI();
        }

        if (BlueCrate <= 0 && RedCrate <= 0 && GreenCrate <= 0)
        {
            allBoxesDelivered = true;
            PauseTime();
        }

        void PauseTime()
        {
            Time.timeScale = 0; // Pausa o tempo
        }
    }
}
