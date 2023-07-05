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
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Bmpconversion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConvert2_Click(object sender, EventArgs e)
        {
            string bmpFilePath = text_path.Text;
            string hexContent = BmpToHex(bmpFilePath);
            string swappedHexContent = SwapHexContent(hexContent);

            byte[] hexBytes = Enumerable.Range(0, swappedHexContent.Length / 2)
                .Select(i => Convert.ToByte(swappedHexContent.Substring(i * 2, 2), 16))
                .ToArray();

            // Calculate CRC
            ushort crc = CalculateCRC(hexBytes);

            // Convert CRC to hex string
            string crcHexString = crc.ToString("X4");

            // Append CRC to hex content
            string hexContentWithCRC = swappedHexContent + crcHexString;

            // Convert hex content with CRC to bytes
            byte[] hexBytesWithCRC = Enumerable.Range(0, hexContentWithCRC.Length / 2)
                .Select(i => Convert.ToByte(hexContentWithCRC.Substring(i * 2, 2), 16))
                .ToArray();

            // 填充剩余的字节为0xFF
            int paddingSize = 108 * 1024 - hexBytesWithCRC.Length;
            byte[] paddingBytes = Enumerable.Repeat((byte)0xFF, paddingSize).ToArray();

            // Concatenate hex bytes with CRC and padding bytes
            byte[] finalHexBytes = hexBytesWithCRC.Concat(paddingBytes).ToArray();

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "BIN Files (*.bin)|*.bin";
            saveFileDialog.InitialDirectory = Path.GetDirectoryName(bmpFilePath);
            saveFileDialog.FileName = Path.GetFileNameWithoutExtension(bmpFilePath) + ".bin";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllBytes(saveFileDialog.FileName, finalHexBytes);
            }
        }

        private ushort CalculateCRC(byte[] data)
        {
            ushort crc = 0xFFFF;

            foreach (byte b in data)
            {
                crc ^= (ushort)(b << 8);

                for (int i = 0; i < 8; i++)
                {
                    if ((crc & 0x8000) != 0)
                    {
                        crc = (ushort)((crc << 1) ^ 0x1021);
                    }
                    else
                    {
                        crc <<= 1;
                    }
                }
            }

            return crc;
        }
        private void btnConvert_Click(object sender, EventArgs e)
        {

        }

        private void btnConvertc_Click(object sender, EventArgs e)
        {
            string bmpFilePath = text_path.Text;
            string hexContent = BmpToHex(bmpFilePath);
            string swappedHexContent = SwapHexContent(hexContent);

            string hexString = swappedHexContent;
            string formattedString = string.Join(",", Enumerable.Range(0, hexString.Length / 2)
                .Select(i => "0x" + hexString.Substring(i * 2, 2)));

            var formattedBuilder = new StringBuilder();
            for (int i = 0; i < formattedString.Length; i += 80)
            {
                formattedBuilder.AppendLine(formattedString.Substring(i, Math.Min(80, formattedString.Length - i)));
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "TXT Files (*.txt)|*.txt";
            saveFileDialog.InitialDirectory = Path.GetDirectoryName(bmpFilePath);
            saveFileDialog.FileName = Path.GetFileNameWithoutExtension(bmpFilePath) + ".txt";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, formattedBuilder.ToString());
            }
        }

        private string BmpToHex(string bmpFilePath)
        {
            using (var bmp = new Bitmap(bmpFilePath))
            {
                var bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, PixelFormat.Format16bppRgb565);
                var bmpBytes = new byte[bmpData.Stride * bmpData.Height];
                Marshal.Copy(bmpData.Scan0, bmpBytes, 0, bmpBytes.Length);
                bmp.UnlockBits(bmpData);

                // Convert byte array to HEX string
                var hexBuilder = new StringBuilder(bmpBytes.Length*2);
                foreach (byte b in bmpBytes)
                {
                    hexBuilder.AppendFormat("{0:X2}", b);
                }
                return hexBuilder.ToString();
            }
        }

        private string SwapHexContent(string hexContent)
        {
            var swappedBuilder = new StringBuilder(hexContent.Length);
            for (int i = 0; i < hexContent.Length; i += 4)
            {
                // Get the two bytes of the 16-bit segment
                var byte1 = hexContent[i];
                var byte2 = hexContent[i + 1];
                var byte3 = hexContent[i + 2];
                var byte4 = hexContent[i + 3];

                // Swap the high and low bytes
                swappedBuilder.Append(byte3);
                swappedBuilder.Append(byte4);
                swappedBuilder.Append(byte1);
                swappedBuilder.Append(byte2);
            }
            return swappedBuilder.ToString();
        }
        private byte[] ImageToByteArray(Image image)
    {
         using (var ms = new MemoryStream())
        {
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            return ms.ToArray();
        }
    }

        private void btn_choose_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "BMP Files (*.bmp)|*.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string bmpFilePath = openFileDialog.FileName;
                text_path.Text = bmpFilePath;
                pictureBox1.Load(bmpFilePath);
                using (var fs = new FileStream(bmpFilePath, FileMode.Open, FileAccess.Read))
                using (var br = new BinaryReader(fs))
                {
                    // Read BMP header
                    var header = new byte[14];
                    br.Read(header, 0, header.Length);

                    // Read DIB header
                    var dibHeader = new byte[40];
                    br.Read(dibHeader, 0, dibHeader.Length);

                    // Extract image width and height
                    var width = BitConverter.ToInt32(dibHeader, 4);
                    var height = BitConverter.ToInt32(dibHeader, 8);

                    // Extract bit depth
                    var bitDepth = BitConverter.ToInt16(dibHeader, 14);

                    // Extract file size
                    var fileSizeBytes = new FileInfo(bmpFilePath).Length;
                    var fileSizeKB = fileSizeBytes / 1024.0;

                    // Do something with bit depth and file size
                    log.AppendText("图片大小" + width + "x" + height + "\r\n位深" + bitDepth + "\r\n文件大小" + fileSizeKB.ToString("0.00") + "KB");
                }
            }
        }

        private void ConcatenateHexFiles(string directoryPath)
        {
            string[] hexFilePaths = Directory.GetFiles(directoryPath, "*.bin");

            Array.Sort(hexFilePaths);

            string concatenatedHexFilePath = Path.Combine(directoryPath, "concatenated.bin");

            using (var outputStream = new FileStream(concatenatedHexFilePath, FileMode.Create))
            {
                foreach (string hexFilePath in hexFilePaths)
                {
                    using (var inputStream = new FileStream(hexFilePath, FileMode.Open))
                    {
                        byte[] buffer = new byte[4096];
                        int bytesRead;

                        while ((bytesRead = inputStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            outputStream.Write(buffer, 0, bytesRead);
                        }
                    }
                }
            }

            MessageBox.Show("Hex files concatenated successfully.");
        }

        private void btnConcatenate_Click(object sender, EventArgs e)
        {
            string directoryPath = Path.GetDirectoryName(Application.ExecutablePath);
            ConcatenateHexFiles(directoryPath);
        }

        private void buttonhex_Click(object sender, EventArgs e)
        {
            string directoryPath = Path.GetDirectoryName(Application.ExecutablePath);
            string[] bmpFilePaths = Directory.GetFiles(directoryPath, "*.bmp");

            Array.Sort(bmpFilePaths);

            foreach (string bmpFilePath in bmpFilePaths)
            {
                string hexContent = BmpToHex(bmpFilePath);
                string swappedHexContent = SwapHexContent(hexContent);

                string hexFilePath = Path.Combine(directoryPath, Path.GetFileNameWithoutExtension(bmpFilePath) + ".bin");
                byte[] hexBytes = Enumerable.Range(0, swappedHexContent.Length / 2)
                    .Select(i => Convert.ToByte(swappedHexContent.Substring(i * 2, 2), 16))
                    .ToArray();

                // 填充剩余的字节为0xFF
                int paddingSize = 108 * 1024 - hexBytes.Length;
                byte[] paddingBytes = Enumerable.Repeat((byte)0xFF, paddingSize).ToArray();

                byte[] finalHexBytes = hexBytes.Concat(paddingBytes).ToArray();

                File.WriteAllBytes(hexFilePath, finalHexBytes);
            }

            MessageBox.Show("图片转换成功。");
        }
    }
}
