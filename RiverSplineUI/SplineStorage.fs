namespace Infrastructure
open UnityEngine
type SplineStorage() = 
    inherit MonoBehaviour()

    [<SerializeField>]
    let mutable splinePoints = ResizeArray<Vector3>()
    member this.add (point : Vector3)  = 
        splinePoints.Add(point) 

    