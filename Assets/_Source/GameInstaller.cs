using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] Points _points;

    public override void InstallBindings()
    {
        Container.Bind<Grid>().FromNew().AsSingle();
        Container.BindInstance(_points);
    }


}
