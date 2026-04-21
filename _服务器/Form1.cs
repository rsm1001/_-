using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _服务器
{
    public partial class Form1 : Form
    {
        // 服务端监听对象
        private TcpListener tcpListener;
        // 已连接的客户端字典：key为客户端标识，value为TcpClient
        private Dictionary<string, TcpClient> connectedClients = new Dictionary<string, TcpClient>();
        // 线程取消令牌源，用于停止监听线程
        private CancellationTokenSource cts;
        // 同步上下文，用于跨线程更新UI
        private SynchronizationContext syncContext;
        // 监听的端口号
        private int listenPort;
        // 服务端真实IP地址
        private string serverIP;

        public Form1()
        {
            InitializeComponent();
            // 获取当前UI线程的同步上下文
            syncContext = SynchronizationContext.Current;
            // 默认IP地址
            serverIP = "192.168.172.1";
            // 输入框显示默认IP
            txt_IP.Text = serverIP;
        }

        /// <summary>
        /// 获取服务端IP地址
        /// </summary>
        private string GetRealIPAddress()
        {
            return "192.168.172.1";
        }

        /// <summary>
        /// 获取所有本机IPv4地址
        /// </summary>
        private List<string> GetAllLocalIPAddresses()
        {
            List<string> ipList = new List<string>();
            try
            {
                // 获取所有网络接口
                var host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (var ip in host.AddressList)
                {
                    // 收集所有IPv4地址
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        ipList.Add(ip.ToString());
                    }
                }
            }
            catch { }
            return ipList;
        }

        /// <summary>
        /// 开始监听按钮点击事件
        /// </summary>
        private void btn_StartListen_Click(object sender, EventArgs e)
        {
            try
            {
                // 获取用户输入的IP地址和端口
                serverIP = txt_IP.Text.Trim();
                listenPort = int.Parse(txt_Port.Text.Trim());

                // 创建TCP监听器，绑定到指定IP
                IPAddress ipAddress = IPAddress.Parse(serverIP);
                tcpListener = new TcpListener(ipAddress, listenPort);
                // 开始监听
                tcpListener.Start();

                // 在接收消息区域显示监听成功
                AppendToRecvMsg("监听成功");
                // 将实际监听的端口号更新到输入框
                txt_Port.Text = listenPort.ToString();

                // 创建取消令牌源
                cts = new CancellationTokenSource();
                // 启动后台线程等待客户端连接
                Task.Run(() => AcceptClientsAsync(cts.Token));
            }
            catch (Exception ex)
            {
                MessageBox.Show("启动监听失败：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 异步接受客户端连接
        /// </summary>
        private async Task AcceptClientsAsync(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                try
                {
                    // 异步等待客户端连接
                    TcpClient client = await tcpListener.AcceptTcpClientAsync();
                    // 获取客户端的远程终结点（IP:端口）
                    string clientKey = client.Client.RemoteEndPoint.ToString();

                    // 使用同步上下文更新UI
                    syncContext.Post(_ =>
                    {
                        // 在接收消息区域显示客户端连接成功
                        AppendToRecvMsg($"{clientKey} 连接成功！");
                        // 将客户端添加到字典
                        if (!connectedClients.ContainsKey(clientKey))
                        {
                            connectedClients.Add(clientKey, client);
                            cbx_ClientSelect.Items.Add(clientKey);
                        }
                    }, null);

                    // 为每个客户端启动独立的接收消息任务
                    _ = Task.Run(() => ReceiveMessagesAsync(client, clientKey, token));
                }
                catch (Exception ex)
                {
                    if (!token.IsCancellationRequested)
                    {
                        syncContext.Post(_ => AppendToRecvMsg($"接受连接异常：{ex.Message}"), null);
                    }
                    break;
                }
            }
        }

        /// <summary>
        /// 异步接收客户端消息
        /// </summary>
        private async Task ReceiveMessagesAsync(TcpClient client, string clientKey, CancellationToken token)
        {
            // 获取网络流用于读写数据
            NetworkStream stream = client.GetStream();
            // 缓冲区大小
            byte[] buffer = new byte[4096];

            try
            {
                while (!token.IsCancellationRequested && client.Connected)
                {
                    // 异步读取数据
                    int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length, token);

                    // 如果读取到0字节，表示客户端断开连接
                    if (bytesRead == 0)
                    {
                        break;
                    }

                    // 将字节数组转换为字符串
                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    // 使用同步上下文更新UI，显示收到的消息
                    syncContext.Post(_ =>
                    {
                        // 格式：IP:端口：消息内容
                        AppendToRecvMsg($"{clientKey}：{message}");
                    }, null);

                    // 广播消息给所有客户端（包括发送者自己）
                    BroadcastMessage(clientKey, message);
                }
            }
            catch (Exception ex)
            {
                syncContext.Post(_ => AppendToRecvMsg($"接收消息异常：{ex.Message}"), null);
            }
            finally
            {
                // 客户端断开，清理资源
                syncContext.Post(_ =>
                {
                    AppendToRecvMsg($"{clientKey} 断开连接");
                    connectedClients.Remove(clientKey);
                    cbx_ClientSelect.Items.Remove(clientKey);
                }, null);
                client.Close();
            }
        }

        /// <summary>
        /// 广播消息给所有已连接的客户端（客户端发送的消息）
        /// </summary>
        private void BroadcastMessage(string senderKey, string message)
        {
            // 构造完整消息格式：发送者IP:端口：消息内容
            string fullMessage = $"{senderKey}：{message}";
            byte[] data = Encoding.UTF8.GetBytes(fullMessage);

            // 遍历所有连接的客户端
            foreach (var kvp in connectedClients.ToList())
            {
                try
                {
                    if (kvp.Value.Connected)
                    {
                        NetworkStream stream = kvp.Value.GetStream();
                        stream.Write(data, 0, data.Length);
                    }
                }
                catch (Exception ex)
                {
                    syncContext.Post(_ => AppendToRecvMsg($"发送消息给 {kvp.Key} 失败：{ex.Message}"), null);
                }
            }
        }

        /// <summary>
        /// 广播服务端发送的消息给所有客户端
        /// </summary>
        private void BroadcastServerMessage(string message)
        {
            // 构造完整消息格式：服务端IP:端口：消息内容
            string fullMessage = $"{serverIP}:{listenPort}：{message}";
            byte[] data = Encoding.UTF8.GetBytes(fullMessage);

            // 遍历所有连接的客户端
            foreach (var kvp in connectedClients.ToList())
            {
                try
                {
                    if (kvp.Value.Connected)
                    {
                        NetworkStream stream = kvp.Value.GetStream();
                        stream.Write(data, 0, data.Length);
                    }
                }
                catch (Exception ex)
                {
                    syncContext.Post(_ => AppendToRecvMsg($"发送消息给 {kvp.Key} 失败：{ex.Message}"), null);
                }
            }
        }

        /// <summary>
        /// 发送消息按钮点击事件
        /// </summary>
        private void btn_SendMsg_Click(object sender, EventArgs e)
        {
            string message = txt_InputMsg.Text.Trim();
            if (string.IsNullOrEmpty(message))
            {
                MessageBox.Show("请输入要发送的消息", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 获取选中的客户端
            string selectedClient = cbx_ClientSelect.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedClient))
            {
                MessageBox.Show("请选择要发送的客户端", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 广播服务端消息给所有客户端
            BroadcastServerMessage(message);
            // 在消息区域显示
            AppendToRecvMsg($"{serverIP}:{listenPort}：{message}");
            txt_InputMsg.Clear();
        }

        /// <summary>
        /// 向接收消息区域追加文本
        /// </summary>
        private void AppendToRecvMsg(string text)
        {
            // 追加文本并换行
            txt_RecvMsg.AppendText($"[{DateTime.Now:HH:mm:ss}] {text}{Environment.NewLine}");
            // 自动滚动到底部
            txt_RecvMsg.ScrollToCaret();
        }

        /// <summary>
        /// 窗体关闭时清理资源
        /// </summary>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            // 取消监听
            cts?.Cancel();
            // 停止TCP监听器
            tcpListener?.Stop();
            // 关闭所有客户端连接
            foreach (var client in connectedClients.Values)
            {
                client?.Close();
            }
            connectedClients.Clear();
        }
    }
}
