using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class topKontrolu : MonoBehaviour
{
    public UnityEngine.UI.Button btn;
    private Rigidbody rgb;
    public float hız = (1.5f);
    public UnityEngine.UI.Text zaman, can, sonYazı;
    int cancounter =  5;
    float zamanCounter = 30;
    bool gameConti = true;
    bool gameDone = false;

    
    // Start is called before the first frame update
    void Start()
    {
        can.text = cancounter + "";
        rgb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameConti && !gameDone)
        {
            zamanCounter -= Time.deltaTime;
            zaman.text = (int)zamanCounter + "";
           
        }
        else if (!gameDone){
            sonYazı.text=("SORRY :(");
            rgb.velocity = Vector3.zero;
            if((zamanCounter==0)) { gameConti = false; }
            btn.gameObject.SetActive(true);
        }
        
    }

    private void FixedUpdate()
    {
        if (gameConti && !gameDone)
        {
            float dikey = Input.GetAxis("Horizontal");
            float yatay = Input.GetAxis("Vertical");
            Vector3 kuvvet = new Vector3(dikey, 0, yatay);
            rgb.AddForce(kuvvet * hız);
        }
        else { rgb.velocity = Vector3.zero; }
    }
    private void OnCollisionEnter(Collision cls)
    {
        string objIsmi = cls.gameObject.name;
        if (objIsmi.Equals("bitis"))
        {
            gameDone = true;
            sonYazı.text = ("WELL DONE!");
            rgb.velocity = Vector3.zero;
            btn.gameObject.SetActive(true);

        }
        else if (!objIsmi.Equals("zemin") && !objIsmi.Equals("anazemin"))
        {
            cancounter -= 1;
            can.text = cancounter+"";
            if (cancounter == 0)
            {
                gameConti = false;
                rgb.velocity = Vector3.zero;
            }

        }
    }

}
