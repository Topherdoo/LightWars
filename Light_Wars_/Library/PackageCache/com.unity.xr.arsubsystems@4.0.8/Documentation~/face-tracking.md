# XR face subsystem

The face subsystem detects and tracks human faces in the environment.

The face subsystem is a type of [tracking subsystem](index.html#tracking-subsystems). Its trackable is [`XRFace`](../api/UnityEngine.XR.ARSubsystems.XRFace.html).

## Face mesh

In addition to a pose, the face subsystem can supply a mesh representing each tracked face. Vertices, indices, normals, and texture coordinates are all optional. To determine runtime capabilities, check the [`XRFaceSubsystemDescriptor`](../api/UnityEngine.XR.ARSubsystems.XRFaceSubsystemDescriptor.html).
