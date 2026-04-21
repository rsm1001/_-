using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _客户端
{
    public partial class Form1 : Form
    {
        // TCP客户端对象
        private TcpClient tcpClient;
        // 网络流对象，用于收发数据
        private NetworkStream networkStream;
        // 线程取消令牌源
        private CancellationTokenSource cts;
        // 同步上下文，用于跨线程更新UI
        private SynchronizationContext syncContext;
        // 本地客户端标识（IP:端口）
        private string clientKey;

        public Form1()
        {
            InitializeComponent();
            // 获取当前UI线程的同步上下文
            syncContext = SynchronizationContext.Current;
            // 使用服务端IP地址
            txtIP.Text = "192.168.172.1";
        }

        /// <summary>
        /// 设置服务端IP地址（可由外部调用）
        /// </summary>
        public void SetServerIP(string ip)
        {
            txtIP.Text = ip;
        }

        /// <summary>
        /// 连接按钮点击事件
        /// </summary>
        private void btnConnect_Click(object sender, EventArgs e)
        {
            // 如果已经连接，则断开
            if (tcpClient != null && tcpClient.Connected)
            {
                Disconnect();
                return;
            }

            try
            {
                // 获取用户输入的服务端IP和端口
                string serverIP = txtIP.Text.Trim();
                int serverPort = int.Parse(txtPort.Text.Trim());

                // 创建TCP客户端并连接
                tcpClient = new TcpClient();
                tcpClient.Connect(serverIP, serverPort);

                // 获取网络流
                networkStream = tcpClient.GetStream();

                // 获取本地终结点信息（IP:端口）
                clientKey = tcpClient.Client.LocalEndPoint.ToString();

                // 在第一个大区域显示连接成功
                AppendToRecvShow("连接成功");

                // 创建取消令牌源
                cts = new CancellationTokenSource();
                // 启动后台线程接收服务端消息
                _ = Task.Run(() => ReceiveMessagesAsync(cts.Token));

                // 修改按钮文本为"断开"
                btnConnect.Text = "断开";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"连接失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 异步接收服务端消息
        /// </summary>
        private async Task ReceiveMessagesAsync(CancellationToken token)
        {
            // 缓冲区大小
            byte[] buffer = new byte[4096];

            try
            {
                while (!token.IsCancellationRequested && tcpClient.Connected)
                {
                    // 异步读取数据
                    int bytesRead = await networkStream.ReadAsync(buffer, 0, buffer.Length, token);

                    // 如果读取到0字节，表示连接断开
                    if (bytesRead == 0)
                    {
                        break;
                    }

                    // 将字节数组转换为字符串
                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    // 使用同步上下文更新UI，在第一个大区域显示收到的消息
                    syncContext.Post(_ =>
                    {
                        AppendToRecvShow(message);
                    }, null);
                }
            }
            catch (Exception ex)
            {
                if (!token.IsCancellationRequested)
                {
                    syncContext.Post(_ => AppendToRecvShow($"接收消息异常：{ex.Message}"), null);
                }
            }
            finally
            {
                // 连接断开，清理资源
                syncContext.Post(_ =>
                {
                    AppendToRecvShow("与服务端断开连接");
                    btnConnect.Text = "连接";
                }, null);
                Disconnect();
            }
        }

        /// <summary>
        /// 发送按钮点击事件
        /// </summary>
        private void btnSend_Click(object sender, EventArgs e)
        {
            // 检查是否已连接
            if (tcpClient == null || !tcpClient.Connected)
            {
                MessageBox.Show("请先连接服务端", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 获取第二个大区域输入的消息
            string message = txtSendInput.Text.Trim();
            if (string.IsNullOrEmpty(message))
            {
                MessageBox.Show("请输入要发送的消息", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // 将消息转换为字节数组
                byte[] data = Encoding.UTF8.GetBytes(message);
                // 发送消息
                networkStream.Write(data, 0, data.Length);

                // 清空输入框
                txtSendInput.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"发送失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 断开连接
        /// </summary>
        private void Disconnect()
        {
            try
            {
                // 取消接收线程
                cts?.Cancel();
                // 关闭网络流
                networkStream?.Close();
                // 关闭TCP客户端
                tcpClient?.Close();
            }
            catch { }
            finally
            {
                networkStream = null;
                tcpClient = null;
                cts = null;
            }

            // 在UI线程更新按钮文本
            if (btnConnect.InvokeRequired)
            {
                btnConnect.Invoke(new Action(() => btnConnect.Text = "连接"));
            }
            else
            {
                btnConnect.Text = "连接";
            }
        }

        /// <summary>
        /// 向接收显示区域（第一个大区域）追加文本
        /// </summary>
        private void AppendToRecvShow(string text)
        {
            // 追加文本并换行
            txtRecvShow.AppendText($"[{DateTime.Now:HH:mm:ss}] {text}{Environment.NewLine}");
            // 自动滚动到底部
            txtRecvShow.ScrollToCaret();
        }

        /// <summary>
        /// 窗体关闭时清理资源
        /// </summary>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            Disconnect();
        }
    }
}
