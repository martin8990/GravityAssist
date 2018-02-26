using UnityEngine;
public static class TransFormer
{
    public static Matrix4x4 GetTransform(Vector3 position, Vector3 scale, Vector3 rotations)
    {
        var v1 = new Vector4(1, 0, 0, 0);
        var v2 = new Vector4(0, 1, 0, 0);
        var v3 = new Vector4(0, 0, 1, 0);
        var v4 = new Vector4(position.x, position.y, position.z, 1);

        var T = new Matrix4x4(v1, v2, v3, v4);

        var sx = Mathf.Sin(rotations.x);
        var sy = Mathf.Sin(rotations.y);
        var sz = Mathf.Sin(rotations.z);

        var cx = Mathf.Cos(rotations.x);
        var cy = Mathf.Cos(rotations.y);
        var cz = Mathf.Cos(rotations.z);

        v1 = new Vector4(
            cy * cz,
            -cy * sz,
            sy,
            0);
        v2 = new Vector4(
            sx * sy * cz + cx * sz
            , -sx * sy * sz + cx * cz,
            -sx * cy,
            0);
        v3 = new Vector4(
            -cx * sy * cz + sx * sz,
            cx * sy * sz + sx * cz,
            cx * cy,
            0);
        v4 = new Vector4(0, 0, 0, 1);

        var R = new Matrix4x4(v1, v2, v3, v4);

        v1 = new Vector4(scale.x, 0, 0, 0);
        v2 = new Vector4(0, scale.y, 0, 0);
        v3 = new Vector4(0, 0, scale.z, 0);
        v4 = new Vector4(0, 0, 0, 1);

        var S = new Matrix4x4(v1, v2, v3, v4);

        var WM = T * R * S;
        return WM;


    }


}