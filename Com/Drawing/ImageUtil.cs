using System;
using System.Drawing;
namespace Com.Drawing
{
	/// <summary>
	/// ImageUtil ��ժҪ˵����
	/// </summary>
	public class ImageUtil
	{
		public ImageUtil()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		/// <summary>
		/// ��������ͼ
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
		/// ��ͼƬ�ϴ�ӡ����
		/// </summary>
		/// <param name="Original">ͼƬ</param>
		/// <param name="AddText">����</param>
		/// <param name="X">LEFT</param>
		/// <param name="Y">TOP</param>
		/// <returns></returns>
		public static Image MarkText(Image Original, string AddText,float X,float Y)
		{
			//������ˮӡ��ע�⣬����Ĵ�������¼�ͼƬˮӡ�Ĵ��벻�ܹ���
			Image image = Original;
			try
			{
				Graphics g = Graphics.FromImage(image);
				g.DrawImage(image, 0, 0, image.Width, image.Height);
				Font f = new Font("���Ĳ���", 16);
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
		/// �������ϴ�ӡLOGO
		/// </summary>
		/// <param name="Original">ͼƬ</param>
		/// <param name="LOGO">LOGOͼƬ</param>
		/// <param name="X">LEFT</param>
		/// <param name="Y">TOP</param>
		/// <returns></returns>
		public static Image MarkImage(Image Original, Image LOGO,float X,float Y)
		{
			//��ͼƬˮӡ
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
		/// �������ͼƬ
		/// </summary>
		/// <param name="inputtext">����</param>
		/// <param name="fontname">��������</param>
		/// <param name="fontzize">�����С</param>
		/// <param name="bold">�Ƿ����</param>
		/// <param name="italic">�Ƿ�б��</param>
		/// <param name="color">��ɫ</param>
		/// <param name="bgcolor">������ɫ</param>
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
		/// ��������������HTML
		/// </summary>
		/// <param name="Number">����</param>
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
