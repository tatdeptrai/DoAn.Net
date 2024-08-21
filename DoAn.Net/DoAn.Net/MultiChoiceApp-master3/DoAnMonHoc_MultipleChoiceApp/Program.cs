using DoAnMonHoc_MultipleChoiceApp.Forms;
using System.Windows.Forms;

namespace DoAnMonHoc_MultipleChoiceApp
{
	internal static class Program
	{
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new DangNhap());
		}
	}
}