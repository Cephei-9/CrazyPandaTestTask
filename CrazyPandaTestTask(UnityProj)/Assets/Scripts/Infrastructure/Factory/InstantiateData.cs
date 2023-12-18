using UnityEngine;

namespace CrazyPandaTestTask.Factory
{
	public struct InstantiateData
	{
		public Vector3 Position;
		public Quaternion Rotation;
		public Transform Parent;

		public InstantiateData(Vector3 position, Quaternion rotation, Transform parent)
		{
			Position = position;
			Rotation = rotation;
			Parent = parent;
		}
	}
}