using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Box_A : MonoBehaviour
{
    public string dialogue;
    private DialogManage rat;
    public Image black;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rat = FindObjectOfType<DialogManage>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator fade()
    {
        anim.SetBool("New Bool", true);
        yield return new WaitUntil(() => black.color.a == 1);
        Application.Quit();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "player")
        {
            if (Input.GetKeyUp(KeyCode.F))
            {
                rat.ShowBox(dialogue);
                FleaCount.count = FleaCount.count + 30;
                StartCoroutine(fade());
            }
        }
    }
}
