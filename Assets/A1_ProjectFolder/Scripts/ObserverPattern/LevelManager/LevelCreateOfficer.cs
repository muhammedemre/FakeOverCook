using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreateOfficer : MonoBehaviour
{
    [SerializeField] private GameObject menuToIngameSceneTransition;
    [SerializeField] private float transitionDuration;
    [SerializeField] private GameObject levelPrefab, levelContainer;
    public GameObject currentLevel;
    public IEnumerator SceneTransitionProcess()
    {
        StartCoroutine(menuToIngameSceneTransition.GetComponent<MenuToInGameSceneTransitionActor>().TransitionStart(transitionDuration));
        yield return new WaitForSeconds(transitionDuration/4);
        GameManager.instance.gameManagerObserverOfficer.Publish(ObserverSubjects.LevelInstantiate);
        UIManager.instance.menu.gameObject.SetActive(false);
    }

    public void CreateTheLevel()
    {
        GameObject tempLevel = Instantiate(levelPrefab, levelContainer.transform.position, Quaternion.identity, levelContainer.transform);
        currentLevel = tempLevel;

    }
}
