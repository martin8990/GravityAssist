namespace Infrastructure

open Utility
open UnityEngine

type SplineParticles() = 
    inherit MonoBehaviour()
    [<SerializeField>]
    let mutable SplineStorage = GameObject.FindObjectOfType<SplineStorage>().GetComponent<SplineStorage>()
    
    [<SerializeField>]
    let mutable Psys : ParticleSystem = null;

    [<SerializeField>]
    let mutable Positions = new ResizeArray<Vector3>();

    member this.Update() = 
        Debug.Log(Positions.Count)


    

