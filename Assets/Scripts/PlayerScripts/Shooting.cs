using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    private Camera cam;
    private Vector3 mousePos;
    public GameObject projectile;
    public Transform projectileTransform;
    public float timer;
    private bool hasSpell;

    //public GameObject projectileCreate = Instantiate(projectile, projectileTransform.position, Quaternion.identity);



    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //Aim (moving the shooting transform)
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0 , rotZ);

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }

        hasSpell = PlayerStats.Instance.fireball;

        //shoot
        if (Input.GetButtonDown("Fireball") && timer <=0)
        {
            //Instantiate(projectile, projectileTransform.position, Quaternion.identity);
            if (hasSpell == true)
            {
                GameObject projectileCreate = Instantiate(projectile, projectileTransform.position, Quaternion.identity);

                //για να δώσω τιμή στο sorting layer
                var MyScript = projectileCreate.GetComponent<SpriteRenderer>();
                MyScript.sortingOrder = 15;

                timer = PlayerStats.Instance.fireballCD;
            }
        }



    }
}
