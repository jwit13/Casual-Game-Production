using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PopulateSelected : MonoBehaviour
{

    public Image selectedSharkImage;
    public Text selectedSharkName;
    public Text bioText;
    public List<GameObject> likedTraits;
    public List<GameObject> dislikedTraits;

    public ScriptableObject selectedClient;
    public GameObject clientSelectPanel;
    public void SelectedMe()
    {
        LobbyManager.Instance.selectedClient = selectedClient;
        gameObject.SetActive(false);
        clientSelectPanel.SetActive(false);
        SceneManager.LoadScene(2);

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
