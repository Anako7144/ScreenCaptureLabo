using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Threading;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
namespace myCapture
{
    class capture
    {
        private const int SRCCOPY = 13369376;

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }
        [DllImport("user32.dll")]
        private static extern IntPtr GetDC(IntPtr hwnd);

        [DllImport("gdi32.dll")]
        private static extern int BitBlt(IntPtr hDestDC,
            int x,
            int y,
            int nWidth,
            int nHeight,
            IntPtr hSrcDC,
            int xSrc,
            int ySrc,
            int dwRop);

        [DllImport("user32.dll")]
        private static extern IntPtr ReleaseDC(IntPtr hwnd, IntPtr hdc);

        [DllImport("user32.dll")]
        private static extern int GetWindowRect(IntPtr hwnd,
            ref  RECT lpRect);
        [DllImport("user32.dll")]
        private static extern int GetClientRect(IntPtr hwnd,
            ref  RECT lpRect);
        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowDC(IntPtr hwnd);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
        public static Bitmap CaptureActiveWindow()
        {
            return CaptureActiveWindow(null);
        }
        public static Bitmap CaptureActiveWindow(Bitmap ptn)
        {
            //アクティブなウィンドウのデバイスコンテキストを取得
            IntPtr hWnd = GetForegroundWindow();
            while (hWnd == IntPtr.Zero)
            {
                Thread.Sleep(40);
                hWnd = GetForegroundWindow();
            }
            IntPtr winDC = GetWindowDC(hWnd);
            winDC = GetDC(hWnd);
            //ウィンドウの大きさを取得
            RECT winRect = new RECT();
            GetClientRect(hWnd, ref winRect);
            //Bitmapの作成
            Bitmap bmp = new Bitmap(winRect.right - winRect.left,
                winRect.bottom - winRect.top);

            //Graphicsの作成
            Graphics g = Graphics.FromImage(bmp);
            //Graphicsのデバイスコンテキストを取得
            IntPtr hDC = g.GetHdc();
            //Bitmapに画像をコピーする
            BitBlt(hDC, 0, 0, bmp.Width, bmp.Height,
                winDC, 0, 0, SRCCOPY);
            //解放
            g.ReleaseHdc(hDC);
            g.Dispose();
            ReleaseDC(hWnd, winDC);
            if (ptn != null && isImagesSame(bmp, ptn))
            {
                return null;
            }
            return bmp;
        }
        public static bool isImagesSame(Bitmap src,Bitmap ptn)
        {
            //高さが違えばfalse
            if (src.Width != ptn.Width || src.Height != ptn.Height) return false;
            BitmapData srcBitData = src.LockBits(new Rectangle(0, 0, src.Width, src.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            BitmapData ptnBitData = ptn.LockBits(new Rectangle(0, 0, ptn.Width, ptn.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            //スキャン幅が違う場合はfalse
            if (srcBitData.Stride != ptnBitData.Stride)
            {
                src.UnlockBits(srcBitData);
                ptn.UnlockBits(ptnBitData);
                return false;
            }
            int bsize = srcBitData.Stride * src.Height;
            byte[] byte1 = new byte[bsize];
            byte[] byte2 = new byte[bsize];
            //バイト配列にコピー
            Marshal.Copy(srcBitData.Scan0, byte1, 0, bsize);
            Marshal.Copy(ptnBitData.Scan0, byte2, 0, bsize);
            src.UnlockBits(srcBitData);
            ptn.UnlockBits(ptnBitData);
            //MD5ハッシュを取る
            System.Security.Cryptography.MD5CryptoServiceProvider md5 =
                new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] hash1 = md5.ComputeHash(byte1);
            byte[] hash2 = md5.ComputeHash(byte2);

            return hash1.SequenceEqual(hash2);
        }
    }

}
