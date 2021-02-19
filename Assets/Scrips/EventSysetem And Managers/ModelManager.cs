using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelManager : MonoBehaviour
{
    private GameObject _currentModel;
    public MovementManager movement;
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        GameMaster.current.event_PlayerChange += ChangeModel;
        SpawnInstance(GameMaster.current.AnimalModels[ (int)GameMaster.current.currentAnimal]);
        _animator = _currentModel.GetComponent<Animator>();
    }

    private void Update()
    {
        if(_animator != null)
        {
            movement.Animation(_animator);
        }
    }

    private void ChangeModel(GameMaster.Animal pAnimal)
    {
        SpawnInstance(GameMaster.current.AnimalModels[(int)pAnimal]);
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
        _animator = _currentModel.GetComponent<Animator>();
    }

   
}
