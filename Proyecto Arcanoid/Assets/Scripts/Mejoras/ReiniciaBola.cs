﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReiniciaBola : MonoBehaviour
{
    GameObject barra;
    bool activo = false;
    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
         if(activo == true)
         {
            ScriptBola.trBola.position = Vector2.MoveTowards(ScriptBola.trBola.position, barra.transform.position + new Vector3(0, 1, 0), 15f * Time.deltaTime);
         }
         
         if (Input.GetButtonDown("Jump") && activo==true)
         {
             activo = false;
             Time.timeScale = 1f;
             ScriptBola.rbBola.AddForce(Vector2.up * ScriptBola.velocidadSalida);
             Destroy(gameObject);
         }
      
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            sr.enabled = false;
            barra = col.gameObject;
            ScriptBola.rbBola.velocity = Vector2.zero;
            activo = true;
        }
    }
}
