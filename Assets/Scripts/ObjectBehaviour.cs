
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ObjectBehaviour : MonoBehaviour
{

    public int itemSelected;  
    public bool B;   //A boolean to check and stop once cash register is selected from user
    public Vector3 pos; //To set the position for object to spawn on counter
    public float X, Y, Z; //To set the value of above variable pos 
    public int finalAmountToPay, amountOfEachObject; 
    List<GameObject> itemsSelectedList; //A list to store items which user selects 
    public Text displayText; 


    private void Start()
    {
        itemSelected = 0;
        B = true;
        X = -1.37f;
        Y = 1.620f;
        Z = -5.117f;
        finalAmountToPay = 0;
        amountOfEachObject = 0;
        itemsSelectedList = new List<GameObject>();
        displayText.text = "";
        
     }

    private void Update()
    {
        pos = new Vector3(X, Y, Z);

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f)) // 100f for how long does the ray goes
            {
                if (hit.transform != null)
                {
                    if (itemSelected < 5 && hit.transform.gameObject.name != "CashRegister" && B == true && hit.transform.gameObject.name != "DetectCharacter")
                    {
                        copyToCounter(hit.transform.gameObject, pos);
                        X = X + (-0.70f);
                        itemSelected++;
                        amountOfEachObject = int.Parse(hit.transform.gameObject.tag);
                        finalAmountToPay = finalAmountToPay + amountOfEachObject;

                        itemsSelectedList.Add(hit.transform.gameObject);
                    }

                    if (hit.transform.gameObject.name == "CashRegister" && B == true)
                    {
                        B = false;


                        
                        if (itemSelected == 0)
                        {
                            displayText.text = "Hello, you have not selected anything from the shelf";
                        }
                        else
                        {
                            displayText.text = "Hello, you selected: \n";
                            foreach (GameObject go in itemsSelectedList)
                            {
                                displayText.text = displayText.text + go.name + " -  " + go.tag + "€ \n";
                            }
                            displayText.text = displayText.text + "Total amount to pay = " + finalAmountToPay + "€";
                        }
                        
                    }
                }
            }
        }
    }

    private void copyToCounter(GameObject go, Vector3 pos1)
    {
        if (go.name != "CashRegister")
        {
            Instantiate(Resources.Load(go.name), pos1, transform.rotation * Quaternion.Euler(0f, 90f, 0f));
        }

    }

}
