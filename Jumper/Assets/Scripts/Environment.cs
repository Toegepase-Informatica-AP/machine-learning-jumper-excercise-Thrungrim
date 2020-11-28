using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Environment : MonoBehaviour
{
    public Cop cop;
    private TextMeshPro scoreBoard;
    // Start is called before the first frame update
    public void OnEnable()
    {
        scoreBoard = transform.GetComponentInChildren<TextMeshPro>();
    }
    
    public void FixedUpdate()
    {
        scoreBoard.text = cop.GetCumulativeReward().ToString("f2");
    }
}
