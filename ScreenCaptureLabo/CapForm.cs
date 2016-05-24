using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using myCapture;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace CapMaster
{
    public partial class CapForm : Form
    {
        

        /// <summary>
        /// 撮影タイマ
        /// </summary>
        private System.Windows.Forms.Timer tm;
        /// <summary>
        /// 画像フォーム
        /// </summary>
        private PicForm imgFrm;
        /// <summary>
        /// 画像パス
        /// </summary>
        private string path;
        /// <summary>
        /// エクセルファイル名
        /// </summary>
        private string excelFileName;
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CapForm()
        {
            InitializeComponent();
            ToolTip tip = new ToolTip();
            tip.ToolTipTitle = "画像リストTIPS";

            tip.AutoPopDelay = 12000;
            tip.SetToolTip(this.ImageListBox, 
                "選択した画像が表示され、クリップボードにコピーされます。\r\n"+
                "Deleteキー\t：画像削除\r\n"+
                "Spaceキー\t：Excelに貼付け(項番付与)\r\n" +
                "数字1キー\t：Excelに貼付け");

            tm = new System.Windows.Forms.Timer();
            tm.Interval = 4000;
            tm.Tick += (sender, e) => CapAndSave();
            imgFrm = new PicForm();
            path = "cap";
            excelFileName = "";
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            reloadCapList();
            
        }
        /// <summary>
        /// 画像リストリロード
        /// </summary>
        private void reloadCapList()
        {
            this.ImageListBox.Items.Clear();

            this.ImageListBox.Items.AddRange(Directory.GetFiles(path, "*.png").OrderByDescending(o => o).ToArray());
        }
        /// <summary>
        /// キャプチャ実行
        /// </summary>
        private void CapAndSave()
        {
            if (!this.timerCheckBox.Checked) this.WindowState = FormWindowState.Minimized;
            Bitmap ptn = null;
            reloadCapList();
            if(this.ImageListBox.Items.Count > 0){
                using (FileStream fs = File.OpenRead((string)this.ImageListBox.Items[0]))
                {
                    ptn = new Bitmap(fs);
                }
            }
            Bitmap myCap = capture.CaptureActiveWindow(ptn);
            if (myCap != null)
            {
                string hoge = Path.Combine(path, DateTime.Now.ToString("MMdd_HHmmss") + ".png");
                myCap.Save(hoge, System.Drawing.Imaging.ImageFormat.Png);
                
            }
            reloadCapList();
            if (!this.timerCheckBox.Checked) this.WindowState = FormWindowState.Normal;
        }

        /// <summary>
        /// キャプチャボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void capButton_Click(object sender, EventArgs e)
        {
            CapAndSave();
        }

        /// <summary>
        /// 画像リスト選択
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!File.Exists(this.ImageListBox.Text))
            {
                reloadCapList();
                return;
            }
            if (this.ImageListBox.SelectedIndex > -1)
            {
                if (!imgFrm.Visible) imgFrm.Show();
                imgFrm.SetPicture(this.ImageListBox.Text);
                imgFrm.Activate();
                this.Activate();
            }
            else
            {
                if (imgFrm.Visible) imgFrm.Hide();
            }
        }
        /// <summary>
        /// 定期キャプチャタイマオンオフ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.timerCheckBox.BackColor = this.timerCheckBox.Checked ? Color.FromArgb(255, 128, 128) : Color.FromArgb(128, 255, 128);
            if (this.timerCheckBox.Checked)
            {
                tm.Interval = (int)this.timerIntervalNum.Value * 1000;
                tm.Start();
            }
            else
                tm.Stop();
        }
        /// <summary>
        /// イメージリストのキーダウンイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Space)
            {
                AddScreenShotToExcel(AddScreenShotToExcelWithPage);
            }
            else if (e.KeyValue == (int)Keys.D1)
            {
                AddScreenShotToExcel(AddScreenShotToExcel);

            }
            else if (e.KeyValue == (int)Keys.Delete)
            {
                imgFrm.ClearPicture();
                File.Delete((string)((ListBox)sender).SelectedItem);
                int index = this.ImageListBox.SelectedIndex;
                this.ImageListBox.Items.RemoveAt(index);
                if (index > 0)
                    this.ImageListBox.SelectedIndex = index-1;
                else
                    this.ImageListBox.SelectedIndex = 0;
            }
        }

        delegate void ExcelWorkMethod(Excel.Application excel, Excel.Workbook wb);

        private void AddScreenShotToExcel(ExcelWorkMethod work)
        {
            Excel.Application excel = null;
            Excel.Workbook wb;

            excel = (Excel.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application");
            if (!excel.Workbooks.Cast<Excel.Workbook>().Any(nwb => nwb.Name == excelFileName + ".xlsx"))
            {
                wb = excel.Workbooks.Add();
                ((Excel.Range)(((Excel.Worksheet)wb.ActiveSheet).Cells[1, 1])).Select();
            }
            else
            {
                wb = excel.Workbooks[excelFileName + ".xlsx"];
            }

            work(excel, wb);

            //excel.Application.DisplayAlerts = false;
            //wb.SaveAs(excelFileName);
            //excel.Application.DisplayAlerts = true;
        }

        private void AddScreenShotToExcel(Excel.Application excel, Excel.Workbook wb)
        {
            int currentRow = excel.ActiveCell.Row;
            int currentColumn = excel.ActiveCell.Column;
            ((Excel.Worksheet)wb.ActiveSheet).Paste();
            int rowHeightPixcel = 18;
            int rowDownCnt = Clipboard.GetImage().Height / rowHeightPixcel + 3;
            ((Excel.Range)(((Excel.Worksheet)wb.ActiveSheet).Cells[currentRow + rowDownCnt, currentColumn])).Select();
        }

        private void AddScreenShotToExcelWithPage(Excel.Application excel, Excel.Workbook wb)
        {
            int iStart;
            if (!int.TryParse(this.StartTextBox.Text, out iStart))
                MessageBox.Show("開始入力値異常");
            else
            {
                int currentRow = excel.ActiveCell.Row;
                int currentColumn = excel.ActiveCell.Column;
                excel.Selection.NumberFormatLocal = "@";
                excel.Selection.Font.Size = 12;
                excel.Selection.Font.Bold = true;
                excel.Selection.Font.Color = 255;
                if (iStart.ToString() != this.EndTextBox.Text)
                {
                    ((Excel.Range)(((Excel.Worksheet)wb.ActiveSheet).Cells[currentRow, currentColumn]))
                        .Value = iStart.ToString() + "-" + this.EndTextBox.Text;
                }
                else
                {
                    ((Excel.Range)(((Excel.Worksheet)wb.ActiveSheet).Cells[currentRow, currentColumn]))
                        .Value = iStart;
                }
                ((Excel.Range)(((Excel.Worksheet)wb.ActiveSheet).Cells[currentRow + 1, currentColumn])).Select();
                AddScreenShotToExcel(excel, wb);

                this.StartTextBox.Text = (iStart + 1).ToString();
                this.EndTextBox.Text = (iStart + 1).ToString();
            }
        }
        /// <summary>
        /// 画像フォルダオープン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenCapDirButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Path.GetDirectoryName(Application.ExecutablePath));
        }
    }
}
