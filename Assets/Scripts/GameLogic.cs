using System.Collections;
using UnityEngine;
using DG.Tweening;


public class GameLogic : MonoBehaviour
{
    [SerializeField] private GameObject prefabCube;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private Transform endPosition;
    void Start()
    {
        StartCoroutine(SpawnCubeCoroutine());
    }

    private IEnumerator SpawnCubeCoroutine()
    {
        for (;;)
        {
            GameObject cube = Instantiate(prefabCube);
            cube.transform.DOMove(endPosition.position, uiManager.SpeedSlider.value, false);

            StartCoroutine(LifeDurationCubeCorutine(cube));
            yield return new WaitForSeconds(uiManager.frequencySlider.value);
        }
    }

    private IEnumerator LifeDurationCubeCorutine(GameObject cube)
    {
        yield return new WaitForSeconds(uiManager.durationSlider.value);
        Destroy(cube);
    }
}
