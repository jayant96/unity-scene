using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterDetect : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f)) // 100f for how long does the ray goes
            {
                if (hit.transform != null)
                {
                    if (hit.transform.gameObject.name == "DetectCharacter")
                    {
                        PlayAnimation();
                    }
                }
            }
        }
    }

    public void PlayAnimation()
    {
        StartCoroutine("MyCoroutine");
    }
    public IEnumerator MyCoroutine()
    {
        GetComponent<Animator>().SetBool("isWaving", true); //Perform Wave Animation
        yield return new WaitForSeconds(1);

        GetComponent<Animator>().SetBool("isWaving", false); //Back to idle after 1 second delay
        yield break;
    }

}

