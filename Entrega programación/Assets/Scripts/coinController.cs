﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinController : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        ScoreManager.scoreManager.RaiseScore(1);
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
