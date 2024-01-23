using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] Points _points;
    [SerializeField] GameInput _input;

    public override void InstallBindings()
    {
        Container.Bind<GridHandler>().FromNew().AsSingle();
        Container.BindInstance(_points);
        Container.BindInstance(_input);
    }
}
