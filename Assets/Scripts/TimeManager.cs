using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public bool gamefinished = false;
    [SerializeField] private float levelfinishTime = 5f;
    public bool gameOver = false;
    [SerializeField] private Text timeText;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;
    [SerializeField]private List<GameObject> destroyAfterGame=new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        if (gamefinished == false && gameOver == false)
        {
            UpdateTheTimer();
        }
        
        if (Time.timeSinceLevelLoad >= levelfinishTime && gameOver == false)
        {
            gamefinished = true;
            winPanel.gameObject.SetActive(true);//objenin açýk veya kapalý olmasýna bakar
            losePanel.gameObject.SetActive(false);
            UpdateObjectsList("Enemy");
            UpdateObjectsList("Objects");
            foreach (GameObject allobjects in destroyAfterGame)
            {
                Destroy(allobjects);
            }
        }
        if (gameOver == true)
        {
            losePanel.gameObject.SetActive(true);
            winPanel.gameObject.SetActive(false);
            UpdateObjectsList("Enemy");
            UpdateObjectsList("Objects");
            foreach (GameObject allobjects in destroyAfterGame)
            {
                Destroy(allobjects);
            }
        }
    }
    private void UpdateObjectsList(string tag)
    {
        destroyAfterGame.AddRange(GameObject.FindGameObjectsWithTag(tag));//birden fazla olduðu için range kullandýk.Tek obje olsatdý Add kullanýlýrdý.
        

    } 
    private void UpdateTheTimer()
    {
        timeText.text = "Time: " + ((int)Time.timeSinceLevelLoad);
    }
}
