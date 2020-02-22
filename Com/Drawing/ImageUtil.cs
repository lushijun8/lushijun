using System;
using System.Drawing;
namespace Com.Drawing
{
	/// <summary>
	/// ImageUtil 的摘要说明。
	/// </summary>
	public class ImageUtil
	{
		public ImageUtil()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// 生成缩略图
		/// </summary>
		/// <param name="Original"></param>
		/// <param name="percentage"></param>
		/// <returns></returns>
		public static Image GenerateThumbnail(Image Original, int percentage)
		{
			if(percentage<1)
				percentage=1;
			//throw new Exception("Thumbnail size must be aat least 1% of the Original size");
			Image image = Original;
			Bitmap tn=new Bitmap((int)(image.Width*0.01f*percentage),(int)(image.Height*0.01f*percentage));
			Graphics g=Graphics.FromImage(tn);
			g.InterpolationMode=System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear; //experiment with this...
			g.DrawImage(image, new Rectangle(0,0,tn.Width,tn.Height),0,0,image.Width,image.Height,GraphicsUnit.Pixel);
			g.Dispose();
			return (Image)tn;
		}
		/// <summary>
		/// 在图片上打印文字
		/// </summary>
		/// <param name="Original">图片</param>
		/// <param name="AddText">文字</param>
		/// <param name="X">LEFT</param>
		/// <param name="Y">TOP</param>
		/// <returns></returns>
		public static Image MarkText(Image Original, string AddText,float X,float Y)
		{
			//加文字水印，注意，这里的代码和以下加图片水印的代码不能共存
			Image image = Original;
			try
			{
				Graphics g = Graphics.FromImage(image);
				g.DrawImage(image, 0, 0, image.Width, image.Height);
				Font f = new Font("华文彩云", 16);
				Brush b = new SolidBrush(Color.Black);
				g.DrawString(AddText, f, b,X,Y);
				g.Dispose();
			}
			catch
			{
			}
			return image;
		}
		/// <summary>
		/// 在文字上打印LOGO
		/// </summary>
		/// <param name="Original">图片</param>
		/// <param name="LOGO">LOGO图片</param>
		/// <param name="X">LEFT</param>
		/// <param name="Y">TOP</param>
		/// <returns></returns>
		public static Image MarkImage(Image Original, Image LOGO,float X,float Y)
		{
			//加图片水印
			Image image= Original;
			try
			{
				Graphics g = Graphics.FromImage(image);
				g.DrawImage(LOGO, new Rectangle(image.Width-LOGO.Width, image.Height-LOGO.Height, LOGO.Width, LOGO.Height), 0, 0, LOGO.Width, LOGO.Height, GraphicsUnit.Pixel);
				g.Dispose();
			}
			catch
			{
			}
			return image;
		}
		/// <summary>
		/// 输出文字图片
		/// </summary>
		/// <param name="inputtext">文字</param>
		/// <param name="fontname">字体名称</param>
		/// <param name="fontzize">字体大小</param>
		/// <param name="bold">是否粗体</param>
		/// <param name="italic">是否斜体</param>
		/// <param name="color">颜色</param>
		/// <param name="bgcolor">背景颜色</param>
		/// <returns></returns>
		public static Bitmap TextImage(string inputtext,string fontname,int fontzize,bool bold,bool italic,Color color,Color bgcolor)
		{
			Bitmap Value;
			Value=new Bitmap(fontzize*(inputtext.Length+3),fontzize);

			Brush b = new SolidBrush(color);
			System.Drawing.FontStyle  fs=System.Drawing.FontStyle.Bold;
			Font f = new Font(fontname,fontzize,fs);
			Brush p=new SolidBrush(bgcolor);

			Graphics g =Graphics.FromImage(Value);
			//g.InterpolationMode=System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
			g.FillRectangle(p,0,0,Value.Width,Value.Height);
			g.DrawString(inputtext,f,b,0,0);
			g.Dispose();
			return Value;
		}
		/// <summary>
		/// 获得数字条形码的HTML
		/// </summary>
		/// <param name="Number">数字</param>
		/// <returns></returns>
		public static string GetBarCode(string Number)
		{
			string Value="";
			string Numeric="0123456789";
			string vRoot=Com.Config.ConfigUtil.GetValueFromWebConfig("vRoot");
			for(int i=0;i<Number.Length;i++)
			{
				if(Numeric.IndexOf(Number.Substring(i,1))!=-1)
					Value+="<img src="+vRoot+"/images/"+Number.Substring(i,1)+".gif border=0>";
				else
					Value+=Number.Substring(i,1);
			}
			return Value;
		}
	}
}
