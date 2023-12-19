using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashTst : MonoBehaviour
{
    public Animator anim;
    public List<Slash> slashes;
    private bool attacking;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && !attacking)
        {
            attacking = true;
            anim.SetTrigger("Attack1");
            StartCoroutine(SlashAttack1());
        }
        if (Input.GetKeyDown(KeyCode.E) && !attacking)
        {
            attacking = true;
            anim.SetTrigger("Attack2");
            StartCoroutine(SlashAttack2());
        }
    }

    IEnumerator SlashAttack1()
    {
        for(int i = 0; i<slashes.Count; i++)
        {
            
            yield return new WaitForSeconds(slashes[i].delay);
            CameraShaker.Invoke();
            slashes[i].slashObj.SetActive(true);
        }

        yield return new WaitForSeconds(1);
        DisableAttack();
        attacking = false;
    }

    IEnumerator SlashAttack2()
    {
        for (int i = 0; i < slashes.Count; i++)
        {
            yield return new WaitForSeconds(slashes[i].delay);
            slashes[i].slashObj.SetActive(true);
        }

        yield return new WaitForSeconds(1);
        DisableAttack();
        attacking = false;
    }


    void DisableAttack()
    {
        for(int i = 0; i < slashes.Count; i++)
        
            slashes[i].slashObj.SetActive(false);
        
    }
}
[System.Serializable]
public class Slash 
{
    public GameObject slashObj;
    public float delay;


}

