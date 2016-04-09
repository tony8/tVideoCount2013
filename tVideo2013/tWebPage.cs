using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Runtime.InteropServices;
using System.Drawing;


namespace tVideo2013
{
    class tWebPage
    {
        public bool webOpenFlag;
        

        //构造函数
        public tWebPage() 
        {
            webOpenFlag = false;

        }
         
       // [DllImport("user32.dll", EntryPoint = "GetDesktopWindow", CharSet = CharSet.Auto, SetLastError = true)]
            
        //登陆到实时监控网页
        public bool LoginWebSite()
        {        
            webOpenFlag = false;
            if ( OpenWeb() )                 //打开首页
            {
                Thread.Sleep( constData.timeWait );
                if (  maxWebPage() )         //最大化首页
                {
                    Thread.Sleep(constData.timeWait );
                    //获取当前界面的图片，
                   //static extern InPtr GetDesktopWindow();

                   int a =  SystemInformation.WorkingArea.Size.Width;
                    if( inputPassword(constData.img_web1,constData.Box_logIn) )                //定位，输入密码
                    {
                        Thread.Sleep( constData.timeWait );
                        if (  nextPageRealTimeMonitor() ) //进入实时监控界面 
                        {
                            Thread.Sleep(constData.timeWait );
                            webOpenFlag = true;
                        }                       
                    }
                }
            }
            return webOpenFlag;
        }
        /// <summary>
        /// 关闭网页
        /// </summary>
        /// <returns></returns>

       
        private bool closeWebPage()
        {//找到关闭按钮，将其关闭

            //找到关闭按钮
            //tImgProcess.
            return true;
        }
        
        /// <summary>
        /// 打开网页
        /// </summary>
        /// <returns></returns>
        private bool OpenWeb()
        {//打开第一个页面，找不到url则返回找不到url 
            //string path = @"E:\Project\5.练手项目\TvideoCount\TvideoCount\bin\Debug\";
            string website =  constData.webName;
            string strpath = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;

            if (!File.Exists( website ))
            {
                MessageBox.Show("文件不完整，请检查文件完整性", "错误", MessageBoxButtons.OK);
                return false;
            }
            System.Diagnostics.Process.Start(website);         
            return true;
        }
 
        //将网页最大化
        private bool maxWebPage()
        {
            return true;
        }
        /// <summary>
        /// 输入：图片截图img1,局部图片box，输出是否成功输入密码
        /// </summary>
        /// <param name="img1"></param>
        /// <param name="box"></param>
        /// <returns></returns>
        private bool inputPassword(string img1 ,string box)
        {
            //对屏幕进行截图，匹配找到输入密码的位置
          //  Image<Gray, Byte> modelImage, 
          //Image<Gray, byte> observedImage,
          //out long matchTime, 
          //out VectorOfKeyPoint modelKeyPoints, 
          //out VectorOfKeyPoint observedKeyPoints, 
          //out Matrix<int> indices, 
          //out Matrix<byte> mask, 
          //out HomographyMatrix homography)
            DrawMatches.FindMatch();

            //输入密码
            long matchTime;
            using (Image<Gray, Byte> modelImage = new Image<Gray, byte>("box.png"))
            using (Image<Gray, Byte> observedImage = new Image<Gray, byte>("box_in_scene.png"))
            {
                Image<Bgr, byte> result = DrawMatches.Draw(modelImage, observedImage, out matchTime);
                //ImageViewer.Show(result, String.Format("Matched using {0} in {1} milliseconds", GpuInvoke.HasCuda ? "GPU" : "CPU", matchTime));
            }

            return true;
        }
        private bool nextPageRealTimeMonitor()
        {//进入实时监控
            if(true)//没进入第二页     
                closeWebPage();

            throw new Exception("The method or operation is not implemented.");
            return true;
        }
    }
}
