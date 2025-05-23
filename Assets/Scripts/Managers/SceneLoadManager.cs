using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoadManager : MonoBehaviour
{
    #region Singleton
    public static SceneLoadManager Instance;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    [Header("UI")]
    [SerializeField] private Image _backgroundImage;
    [SerializeField] private Image _loadBarBGImage;
    [SerializeField] private Image _loadBarFillImage;
    [SerializeField] private TextMeshProUGUI _loadProgressText;

    private bool _isLoading;

    private void Start()
    {
        _backgroundImage.enabled = false;
        _loadBarBGImage.enabled = false;
        _loadBarFillImage.enabled = false;
        _loadProgressText.enabled = false;
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(StartLoadingSequence(sceneName));
    }

    private IEnumerator StartLoadingSequence(string sceneName)
    {
        _isLoading = true;

        _backgroundImage.enabled = true;
        _loadBarBGImage.enabled = true;
        _loadBarFillImage.enabled = true;
        _loadProgressText.enabled = true;

        _loadBarFillImage.color = Color.red;

        float t = 0.0f;

        while(t < 1.0f)
        {
            t += Time.deltaTime;

            _backgroundImage.color = new Color(1.0f, 1.0f, 1.0f, Mathf.Lerp(0.0f, 1.0f, t));
            _loadBarBGImage.color = new Color(_loadBarBGImage.color.r, _loadBarBGImage.color.g, _loadBarBGImage.color.b, Mathf.Lerp(0.0f, 1.0f, t));
            _loadBarFillImage.color = new Color(_loadBarFillImage.color.r, _loadBarFillImage.color.g, _loadBarFillImage.color.b, Mathf.Lerp(0.0f, 1.0f, t));

            yield return null;
        }

        _backgroundImage.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        _loadBarBGImage.color = new Color(_loadBarBGImage.color.r, _loadBarBGImage.color.g, _loadBarBGImage.color.b, 1.0f);
        _loadBarFillImage.color = new Color(_loadBarFillImage.color.r, _loadBarFillImage.color.g, _loadBarFillImage.color.b, 1.0f);

        _loadProgressText.text = $"Loading...";

        AsyncOperation asyncOp = SceneManager.LoadSceneAsync(sceneName);

        asyncOp.allowSceneActivation = false;

        while(asyncOp.progress < 0.9f)
        {
            _loadBarFillImage.fillAmount = asyncOp.progress / 0.9f;

            yield return null;
        }

        _loadBarFillImage.fillAmount = 1.0f;

        _loadBarFillImage.color = Color.green;

        _loadProgressText.text = $"Press any key to continue.";

        while (!Input.anyKey)
        {
            yield return null;
        }

        asyncOp.allowSceneActivation = true;

        t = 0.0f;

        while (t < 1.0f)
        {
            t += Time.deltaTime;

            _backgroundImage.color = new Color(1.0f, 1.0f, 1.0f, Mathf.Lerp(1.0f, 0.0f, t));
            _loadBarBGImage.color = new Color(_loadBarBGImage.color.r, _loadBarBGImage.color.g, _loadBarBGImage.color.b, Mathf.Lerp(1.0f, 0.0f, t));
            _loadBarFillImage.color = new Color(_loadBarFillImage.color.r, _loadBarFillImage.color.g, _loadBarFillImage.color.b, Mathf.Lerp(1.0f, 0.0f, t));

            yield return null;
        }

        _backgroundImage.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        _loadBarBGImage.color = new Color(_loadBarBGImage.color.r, _loadBarBGImage.color.g, _loadBarBGImage.color.b, 0.0f);
        _loadBarFillImage.color = new Color(_loadBarFillImage.color.r, _loadBarFillImage.color.g, _loadBarFillImage.color.b, 0.0f);

        _backgroundImage.enabled = false;
        _loadBarBGImage.enabled = false;
        _loadBarFillImage.enabled = false;
        _loadProgressText.enabled = false;

        _isLoading = false;
    }
}
