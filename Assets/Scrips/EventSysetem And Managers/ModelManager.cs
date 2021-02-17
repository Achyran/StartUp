using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelManager : MonoBehaviour
{
    public List<GameObject> models;
    public GameObject StartModel;
    private GameObject _currentModel;
    // Start is called before the first frame update
    void Start()
    {
        GameMaster.current.event_PlayerChange += ChangeModel;
        SpawnInstance(StartModel);
    }

    private void ChangeModel(GameMaster.Animal pAnimal)
    {
        SpawnInstance(models[(int)pAnimal]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDestroy()
    {
        GameMaster.current.event_PlayerChange -= ChangeModel;
    }

    private void SpawnInstance(GameObject pGameobject)
    {
        if (_currentModel != null) Destroy(_currentModel);
        _currentModel = Instantiate(pGameobject, this.transform);
        _currentModel.transform.localPosition = new Vector3(0, 0, 0);
    }
}
