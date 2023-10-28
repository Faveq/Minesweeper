using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using test.Commands;

namespace test
{
    public class ViewModel
    {
		private int selectedIndex;

		public int SelectedIndex
		{
			get { return selectedIndex; }
			set { selectedIndex = value; }
		}


		public ICommand ClickCommand { get; set; }


        public ViewModel()
        {
			ClickCommand = new ClickCommand(this);
        }

    }
}
