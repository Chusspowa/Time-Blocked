﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReiniciaBola : MonoBehaviour
{
    GameObject barra;
    public static bool activo = false;
    SpriteRenderer sr;
    public static bool lanza = false;
    public static bool cogeMejora = false;
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
            transform.position = transform.position + new Vector3(0, 0, -1f);

        }
        else
        {
            transform.position = transform.position - new Vector3(0, 0, -1f);

        }
         
         if (lanza && activo==true)
         {
             activo = false;
             Movimiento.profundidad = 1;
             lanza = false;
             Time.timeScale = 1f;
             Movimiento.rbBola.AddForce(Vector2.up * Movimiento.velocidadSalida);
             Destroy(gameObject);
         }
      
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            sr.enabled = false;
            barra = col.gameObject;
            Movimiento.rbBola.velocity = Vector2.zero;
            activo = true;
            cogeMejora = true;
        }
    }
}
