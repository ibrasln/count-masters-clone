using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private Transform player;
    [SerializeField] private List<Transform> enemyPools = new();
    public bool isGameStarted;

    private bool noActiveChild;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        isGameStarted = false;

        foreach (Transform enemyPool in enemyPools)
        {
            foreach (Transform enemy in enemyPool)
            {
                enemy.gameObject.SetActive(true);
            }
        }

        StartCoroutine(CheckIsGameOveredRoutine());
    }

    private void Update()
    {
        if (!isGameStarted && Input.GetKeyDown(KeyCode.Space))
        {
            isGameStarted = true;
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private IEnumerator CheckIsGameOveredRoutine()
    {
        yield return new WaitForSeconds(3f);
        Debug.Log("CheckIsGameOvered");
        noActiveChild = true;
        for (int i = 0; i < player.childCount; i++)
        {
            if (player.GetChild(i).gameObject.activeInHierarchy)
            {
                noActiveChild = false;
                break;
            }
            yield return null;
        }
        if (noActiveChild)
        {
            Restart();
        }

        yield return new WaitForSeconds(1.5f);
        yield return StartCoroutine(CheckIsGameOveredRoutine());
    }
}
