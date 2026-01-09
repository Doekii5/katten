using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class progressBar : MonoBehaviour
{
    public Levelloaderscript levelloaderscript;
    public Animator bar;
    public GameObject wool;
    public GameObject heart;
    public Shop shop;
    public Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void walkChange(float timeswalked)
    {
        if (timeswalked == 0)
        {
            bar.SetTrigger("progress1");
            heart.SetActive(true);
            wool.SetActive(true);
        }
        if (timeswalked == 1)
        {
            bar.SetTrigger("progress2");
        }
        if (timeswalked == 2)
        {
            bar.SetTrigger("progress3");
            heart.SetActive(false);
        }
        if (timeswalked == 3)
        {
            bar.SetTrigger("progress4");
            wool.SetActive(false);
            shop.wolbought = true;
            shop.wol.image.color = Color.gray;
            //inventory.backwool.color = inventory.backwoolcolor;
            shop.wol.interactable = false;
        }
    }
}
