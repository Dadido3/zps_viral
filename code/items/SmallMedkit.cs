﻿using Sandbox;
namespace ZPS2
{
	[Library( "zps2_painkillers", Title = "Painkillers" )]
	[Hammer.EntityTool( "Painkillers", "Health", "Pills to recover small amounts of health" )]
	[Hammer.EditorModel( "models/medkit.vmdl" )]
	partial class SmallMedkit : ItemBase
	{
		public override Type ItemType => Type.Health;
		public virtual string WorldModelPath => "models/medkit.vmdl";

		public override string PickupSound => "medkit_pickup";

		public override void Spawn()
		{
			base.Spawn();

			SetModel( WorldModelPath );
		}

		public override void OnCarryStart( Entity carrier )
		{
			var ply = carrier as ZPS2Player;

			if ( ply.Health >= 100 )
				return;

			base.OnCarryStart( carrier );

			if ( PickupTrigger.IsValid() )
			{
				PickupTrigger.EnableTouch = false;

				ply.Health += 25;

				if ( ply.Health > 100 )
					ply.Health = 100;
			}
		}
	}
}
