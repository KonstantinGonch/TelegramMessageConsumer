using Microsoft.Web.WebView2.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TelegramMessageConsumer.Middleware;
using TelegramMessageConsumer.Models;

namespace TelegramMessageConsumer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeAsync();
        }

        async void InitializeAsync()
        {
            await webView.EnsureCoreWebView2Async(null);
            string text = File.ReadAllText("Js/digestMessage.js");
            await webView.CoreWebView2.ExecuteScriptAsync(text);
        }

        private async void webView_WebMessageReceived(object sender, CoreWebView2WebMessageReceivedEventArgs e)
        {
            var poolMessageRequest = JsonConvert.DeserializeObject<PoolMessageRequest>(e.WebMessageAsJson);
            var poolUnit = new MessagePoolUnit { TlgMessageId = poolMessageRequest.TlgMessageId };
            using (var dbContext = new AppDbContext())
            {
                if (!dbContext.MessagePoolUnits.Any(mp => mp.TlgMessageId == poolUnit.TlgMessageId) && 
                    !dbContext.Messages.Any(m => m.TlgId == poolUnit.TlgMessageId))
                {
                    dbContext.MessagePoolUnits.Add(poolUnit);
                    await dbContext.SaveChangesAsync();
                    LogHelper.AddLogMessage("Сообщение с id = " + poolUnit.TlgMessageId + " сохранено в пул");
                }
                else
                {
                    LogHelper.AddLogMessage("Не удалось сохранить в пул сообщение с id = " + poolUnit.TlgMessageId + ". Элемент с таким id уже существует");
                }
            }
        }
    }
}
