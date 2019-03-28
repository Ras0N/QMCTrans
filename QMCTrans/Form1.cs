using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;


namespace QMCTrans
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static bool isThreadRun = false;

        private static int[] UKey = {
        0x77, 0x48, 0x32, 0x73, 0xDE, 0xF2, 0xC0, 0xC8, 0x95, 0xEC, 0x30, 0xB2,
        0x51, 0xC3, 0xE1, 0xA0, 0x9E, 0xE6, 0x9D, 0xCF, 0xFA, 0x7F, 0x14, 0xD1,
        0xCE, 0xB8, 0xDC, 0xC3, 0x4A, 0x67, 0x93, 0xD6, 0x28, 0xC2, 0x91, 0x70,
        0xCA, 0x8D, 0xA2, 0xA4, 0xF0, 0x08, 0x61, 0x90, 0x7E, 0x6F, 0xA2, 0xE0,
        0xEB, 0xAE, 0x3E, 0xB6, 0x67, 0xC7, 0x92, 0xF4, 0x91, 0xB5, 0xF6, 0x6C,
        0x5E, 0x84, 0x40, 0xF7, 0xF3, 0x1B, 0x02, 0x7F, 0xD5, 0xAB, 0x41, 0x89,
        0x28, 0xF4, 0x25, 0xCC, 0x52, 0x11, 0xAD, 0x43, 0x68, 0xA6, 0x41, 0x8B,
        0x84, 0xB5, 0xFF, 0x2C, 0x92, 0x4A, 0x26, 0xD8, 0x47, 0x6A, 0x7C, 0x95,
        0x61, 0xCC, 0xE6, 0xCB, 0xBB, 0x3F, 0x47, 0x58, 0x89, 0x75, 0xC3, 0x75,
        0xA1, 0xD9, 0xAF, 0xCC, 0x08, 0x73, 0x17, 0xDC, 0xAA, 0x9A, 0xA2, 0x16,
        0x41, 0xD8, 0xA2, 0x06, 0xC6, 0x8B, 0xFC, 0x66, 0x34, 0x9F, 0xCF, 0x18,
        0x23, 0xA0, 0x0A, 0x74, 0xE7, 0x2B, 0x27, 0x70, 0x92, 0xE9, 0xAF, 0x37,
        0xE6, 0x8C, 0xA7, 0xBC, 0x62, 0x65, 0x9C, 0xC2, 0x08, 0xC9, 0x88, 0xB3,
        0xF3, 0x43, 0xAC, 0x74, 0x2C, 0x0F, 0xD4, 0xAF, 0xA1, 0xC3, 0x01, 0x64,
        0x95, 0x4E, 0x48, 0x9F, 0xF4, 0x35, 0x78, 0x95, 0x7A, 0x39, 0xD6, 0x6A,
        0xA0, 0x6D, 0x40, 0xE8, 0x4F, 0xA8, 0xEF, 0x11, 0x1D, 0xF3, 0x1B, 0x3F,
        0x3F, 0x07, 0xDD, 0x6F, 0x5B, 0x19, 0x30, 0x19, 0xFB, 0xEF, 0x0E, 0x37,
        0xF0, 0x0E, 0xCD, 0x16, 0x49, 0xFE, 0x53, 0x47, 0x13, 0x1A, 0xBD, 0xA4,
        0xF1, 0x40, 0x19, 0x60, 0x0E, 0xED, 0x68, 0x09, 0x06, 0x5F, 0x4D, 0xCF,
        0x3D, 0x1A, 0xFE, 0x20, 0x77, 0xE4, 0xD9, 0xDA, 0xF9, 0xA4, 0x2B, 0x76,
        0x1C, 0x71, 0xDB, 0x00, 0xBC, 0xFD, 0xC,  0x6C, 0xA5, 0x47, 0xF7, 0xF6,
        0x00, 0x79, 0x4A, 0x11};

        private byte Key(int v)
        {
            if (v >= 0)
            {
                if (v > 0x7fff)
                    v %= 0x7fff;
            }
            else
                v = 0;
            return Convert.ToByte(UKey[(v * v + 80923) % 256]);
        }
        private void onAddButtonClick(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "QQ音乐加密文件|*.qmcflac;*.qmc0;*.qmc3|所有文件|*.*";
            ofd.Title = "打开文件";
            ofd.RestoreDirectory = true;
            ofd.Multiselect = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FileList.BeginUpdate();
                for (int i = 0; i < ofd.FileNames.Length; i++)
                {
                    var foundItem = FileList.FindItemWithText(ofd.FileNames[i]);
                    if (foundItem != null)
                        continue;
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = ofd.FileNames[i];
                    string ext = System.IO.Path.GetExtension(ofd.FileNames[i]).ToLower();
                    switch (ext)
                    {
                        case ".qmcflac":
                            lvi.SubItems.Add("flac");
                            break;
                        default:
                            lvi.SubItems.Add("mp3");
                            break;
                    }
                    lvi.SubItems.Add("Ready！");
                    FileList.Items.Add(lvi);
                }
                FileList.EndUpdate();
            }
        }

        private void OnFolderClick(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "选择一个文件夹";
            fbd.ShowNewFolderButton = false;
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                DirectoryInfo DIFolder = new DirectoryInfo(fbd.SelectedPath);
                FileSystemInfo[] files = DIFolder.GetFiles();
                FileList.BeginUpdate();
                foreach (var fFile in files) {
                    var foundItem = FileList.FindItemWithText(fFile.FullName);
                    if (foundItem != null)
                        continue;
                    switch (fFile.Extension.ToLower())
                    {
                        case ".qmcflac":
                            var lvi = new ListViewItem();
                            lvi.Text = fFile.FullName;
                            lvi.SubItems.Add("flac");
                            lvi.SubItems.Add("Ready!");
                            FileList.Items.Add(lvi);
                            break;
                        case ".qmc0":
                        case ".qmc3":
                            var qlvi = new ListViewItem();
                            qlvi.Text = fFile.FullName;
                            qlvi.SubItems.Add("mp3");
                            qlvi.SubItems.Add("Ready!");
                            FileList.Items.Add(qlvi);
                            break;
                        default:
                            break;
                    }
                }
                FileList.EndUpdate();
            }
        }

        private void OnDeleteClick(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in FileList.SelectedItems)
                FileList.Items.RemoveAt(lvi.Index);
        }

        private void OnTransStart(object sender, EventArgs e)
        {
            if (FileList.Items.Count == 0)
                return;
            if (isThreadRun == true)
                return;
            Thread workThread = new Thread(new ThreadStart(EncryptThread));
            workThread.Start();
        }

        delegate string[] GetFileList();
        private string[] GetListFromFileList()
        {
            if (FileList.InvokeRequired)
            {
                GetFileList GFL = new GetFileList(GetListFromFileList);
                return (string[])this.Invoke(GFL);
            }
            else
            {
                string[] lists = new string[FileList.Items.Count];
                int i = 0;
                foreach(ListViewItem lvi in FileList.Items)
                {
                    lists[i++] = lvi.Text;
                }
                return lists;
            }
        }

        delegate string[] GetFileExt();
        private string[] GetFileExtFromList()
        {
            if (FileList.InvokeRequired)
            {
                GetFileExt GFE = new GetFileExt(GetFileExtFromList);
                return (string[])this.Invoke(GFE);
            }
            else
            {
                string[] exts = new string[FileList.Items.Count];
                int i = 0;
                foreach(ListViewItem lvi in FileList.Items)
                {
                    exts[i++] = lvi.SubItems[1].Text; 
                }
                return exts;
            }
        }

        delegate void updateStatue(string str,int num);
        private void updateStatueToFileList(string str, int num)
        {
            if (FileList.InvokeRequired)
            {
                updateStatue uS = new updateStatue(updateStatueToFileList);
                this.Invoke(uS, str, num);
            }
            else
            {
                FileList.BeginUpdate();
                int i = 0;
                foreach(ListViewItem lvi in FileList.Items)
                {
                    if (i != num)
                    {
                        i++;
                        continue;
                    }
                    else
                    {
                        lvi.SubItems[2].Text = str;
                    }
                }
                FileList.EndUpdate();
            }
        }
        private void EncryptThread()
        {
            isThreadRun = true;
            string[] lists = GetListFromFileList();
            string[] exts = GetFileExtFromList();
            int N = 0;
            foreach (var stfile in lists)
            {
                string writeFile = Path.GetDirectoryName(stfile) + '\\' + Path.GetFileNameWithoutExtension(stfile) + '.' + exts[N];
                if (File.Exists(writeFile) == true)
                {
                    updateStatueToFileList("完成", N);
                    continue;
                }
                FileStream fsreadFile = new FileStream(stfile, FileMode.Open);
                FileStream fswriteFile = new FileStream(writeFile, FileMode.CreateNew);
                BinaryReader bsreadFile = new BinaryReader(fsreadFile);
                BinaryWriter bswriteFile = new BinaryWriter(fswriteFile);
                updateStatueToFileList("转换中", N);
                byte[] buffer = new byte[8192];
                int readSize = 0;
                int offset = 0;
                do
                {
                    readSize = bsreadFile.Read(buffer, 0, 8192);
                    for (int i = 0; i < 8192; i++) {
                        buffer[i] ^= Key(offset + i);
                    }
                    offset += readSize;
                    bswriteFile.Write(buffer);
                } while (readSize > 0);
                bswriteFile.Close();
                bsreadFile.Close();
                fswriteFile.Close();
                fsreadFile.Close();
                updateStatueToFileList("完成", N);
                N++;
            }
            isThreadRun = false;
            return;
        }

        private void About_Click(object sender, EventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.Show();
        }
    }
}
