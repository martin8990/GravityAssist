using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Domain;
using Infrastructure;
using Utility;

public class WorldGenControl : MonoBehaviour {

    public PlaneMeshGenerator planeMeshGenerator;
    public VonoroiGenerator vonoroiGenerator;
    public VonoroiMapper vonoroiMapper;

    public Heightmapper heightMapper;

    [Button]
    public void GenerateWorld()
    {
        planeMeshGenerator.GeneratePlanes();
        vonoroiGenerator.GenerateVoronoi();

        heightMapper.SampleVonoroi();
        vonoroiMapper.MapVoronoi();
    }
}
