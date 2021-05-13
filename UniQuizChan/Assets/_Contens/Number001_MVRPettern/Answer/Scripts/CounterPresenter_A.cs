using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class CounterPresenter_A : MonoBehaviour
{
    private CounterModel_A model;
    private CounterView_A  view;
    // Start is called before the first frame update
    void Start()
    {
        model = new CounterModel_A();
        if (null == view) FindObjectOfType<CounterView_A>();

        // Browse to the view. 
        view
            // When fired AddObservable.
            .AddObservable()
            // Subscribe and notify the model of the AddCount.
            .Subscribe(_ => model.AddCount())
            .AddTo(this);
        
        // Browse to the view.
        view
            // When fired ReduceObservable.
            .ReduceObservable()
            // Subscribe and notify the model of the ReduceCount.
            .Subscribe(_ => model.ReduceCount())
            .AddTo(this);

        // Browse to the model.
        model
            // When change in the count value.
            .Counter
            // Notify the view of numerical changes. 
            .Subscribe(_ => view.DisplayCount(1))
            .AddTo(this);
    }

}
