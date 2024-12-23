using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
namespace RemoteLanManager
{
	public partial class ImageBox : Control
	{
		public ImageBox()
		{
			InitializeComponent();
		}
		Image img;
		CompositingQuality quality = CompositingQuality.HighQuality; 
		public CompositingQuality CompositingQuality { get { return quality; } set { quality = value; } }
		InterpolationMode intmode;
		InterpolationMode InterpolationMode { get { return intmode; } set { } }
		protected override void OnPaint(PaintEventArgs pe)
		{
			
			
			base.OnPaint(pe);
		}
	}
}
