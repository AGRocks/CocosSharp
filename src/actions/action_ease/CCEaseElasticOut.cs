using System;
using Microsoft.Xna.Framework;

namespace CocosSharp
{
	public class CCEaseElasticOut : CCEaseElastic
	{
		#region Constructors

        public CCEaseElasticOut (CCFiniteTimeAction pAction) : base (pAction, 0.3f)
		{
		}

        public CCEaseElasticOut (CCFiniteTimeAction pAction, float fPeriod) : base (pAction, fPeriod)
		{
		}

		#endregion Constructors


		protected internal override CCActionState StartAction(CCNode target)
		{
			return new CCEaseElasticOutState (this, target);
		}

		public override CCFiniteTimeAction Reverse ()
		{
            return new CCEaseElasticIn ((CCFiniteTimeAction)InnerAction.Reverse (), Period);
		}
	}


	#region Action state

	internal class CCEaseElasticOutState : CCEaseElasticState
	{
		public CCEaseElasticOutState (CCEaseElasticOut action, CCNode target) : base (action, target)
		{
		}

		public override void Update (float time)
		{
			InnerActionState.Update (CCEaseMath.ElasticOut (time, Period));
		}
	}

	#endregion Action state
}