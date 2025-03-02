using System.Collections;
using UnityEngine;

public class TransitionManager : MonoBehaviour
{
    [SerializeField] private GameObject _startingSceneTransition;
    [SerializeField] private GameObject _endingSceneTransition;
    [SerializeField] private float startTransitionDuration = 5f;
    [SerializeField] private float endTransitionDuration = 1.5f;

    private bool isTransitioning = false;

    private void Start()
    {
        Debug.Log("Start() dipanggil!");

        if (_startingSceneTransition != null)
        {
            Debug.Log("Memulai Starting Scene Transition...");
            _startingSceneTransition.SetActive(true);
            StartCoroutine(DisableAfterTime(_startingSceneTransition, startTransitionDuration));
        }
        else
        {
            Debug.LogError("Starting Scene Transition belum diassign di Inspector!");
        }
    }

    public void StartSceneTransition(string nextScene)
    {
        if (isTransitioning)
        {
            Debug.LogWarning("Transisi sudah berjalan, abaikan input!");
            return;
        }

        isTransitioning = true;
        Debug.Log("StartSceneTransition() dipanggil!");

        if (_endingSceneTransition != null)
        {
            Debug.Log("Memulai Ending Scene Transition...");
            _endingSceneTransition.SetActive(true);
            StartCoroutine(LoadSceneAfterDelay(nextScene, endTransitionDuration));
        }
        else
        {
            Debug.LogError("Ending Scene Transition belum diassign di Inspector!");
        }
    }

    private IEnumerator DisableAfterTime(GameObject obj, float delay)
    {
        Debug.Log($"Menunggu {delay} detik untuk menonaktifkan {obj.name}");
        yield return new WaitForSeconds(delay);

        if (obj != null)
        {
            obj.SetActive(false);
            Debug.Log(obj.name + " telah dinonaktifkan.");
        }
        else
        {
            Debug.LogError("Objek sudah tidak ada sebelum dinonaktifkan!");
        }
    }

    private IEnumerator LoadSceneAfterDelay(string sceneName, float delay)
    {
        Debug.Log($"Menunggu {delay} detik sebelum memuat scene {sceneName}");
        yield return new WaitForSeconds(delay);
        
        Debug.Log("Memuat Scene: " + sceneName);

        SceneLoader sceneLoader = FindObjectOfType<SceneLoader>();
        if (sceneLoader != null)
        {
            sceneLoader.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("SceneLoader tidak ditemukan dalam scene!");
        }
    }
}
