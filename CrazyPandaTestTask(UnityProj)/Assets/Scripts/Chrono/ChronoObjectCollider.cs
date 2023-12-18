using UnityEngine;

namespace Chrono
{
	// This class is just a view for the real implementation. This way bullets can use IChronoObject chains and configure
	// this in Bullet, and true implementations get to inherit from classes
	public class ChronoObjectCollider : MonoBehaviour, IChronoObject
	{
		public Vector2 Position => _originChronoObject.Position;

		public IChronoObject _originChronoObject;

		public void Init(IChronoObject originChronoObject)
		{
			_originChronoObject = originChronoObject;
		}

		public void EnterArea(ChronoAreaProvider areaProvider)
		{
			_originChronoObject.EnterArea(areaProvider);
		}

		public void ExitArea(ChronoAreaProvider areaProvider)
		{
			_originChronoObject.ExitArea(areaProvider);
		}
	}
}