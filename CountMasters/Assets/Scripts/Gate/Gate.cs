using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public GateOperation gateOperation;

    private void Start()
    {
        int operationNum = Random.Range(0, 2);

        if (operationNum == 0) gateOperation = GateOperation.SUM;
        else gateOperation = GateOperation.MULTIPLICATION;
    }
}
