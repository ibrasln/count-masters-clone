using UnityEngine;
using UnityEngine.UI;

public class Gate : MonoBehaviour
{
    public GateOperation gateOperation;

    [SerializeField] private Transform humanPool;
    [SerializeField] private Text _text;
    [SerializeField] private int count;
    private bool isTriggered;

    private void Start()
    {
        if (gateOperation == GateOperation.SUM) _text.text = "+" + count.ToString();
        else _text.text = "x" + count.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isTriggered)
        {
            isTriggered = true;
            if (gateOperation == GateOperation.SUM)
            {
                ObjectPool.instance.GetPooledObject(0, count);
            }
            else
            {
                int childrenNum = 0;
                for (int i = 0; i < humanPool.childCount; i++)
                {
                    if (humanPool.GetChild(i).gameObject.activeInHierarchy) childrenNum++;
                    else continue;
                }

                ObjectPool.instance.GetPooledObject(0, childrenNum * count);
            }
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
}
