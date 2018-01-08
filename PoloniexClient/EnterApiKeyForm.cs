﻿using CryptoMarketClient.Bittrex;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoMarketClient {
    public partial class EnterApiKeyForm : XtraForm {
        public EnterApiKeyForm() {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e) {
            base.OnShown(e);
            List<ApiKeyInfo> list = new List<ApiKeyInfo>();
            foreach(Exchange exchange in Exchange.Registered)
                list.Add(new ApiKeyInfo() { Exchange = exchange, Market = exchange.Name, ApiKey = exchange.ApiKey, Secret = exchange.ApiSecret });
            this.apiKeyInfoBindingSource.DataSource = list;
            Keys = list;
        }

        protected List<ApiKeyInfo> Keys { get; set; }
        private void simpleButton2_Click(object sender, EventArgs e) {
            Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e) {
            foreach(ApiKeyInfo info in Keys) {
                info.Exchange.ApiKey = string.IsNullOrEmpty(info.ApiKey) ? "": info.ApiKey.Trim();
                info.Exchange.ApiSecret = string.IsNullOrEmpty(info.Secret)? "": info.Secret.Trim();
                info.Exchange.Save();
            }
            Close();
        }
    }
}