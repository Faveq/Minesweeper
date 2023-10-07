using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.ViewModels
{
    public class GameConfigurationViewModel : ViewModelBase
    {
		private int mapSize;

		public int MapSize
		{
			get { return mapSize; }
			set { mapSize = value; }
		}

		private int minesCount;

		public int MinesCount
		{
			get { return minesCount; }
			set { minesCount = value; }
		}



	}
}
