using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatJumpPoint : MonoBehaviour
{

    public GameObject jumpDestination;

    [Range(0,1)]
    public float jumpProbability = 0.5f;
}
