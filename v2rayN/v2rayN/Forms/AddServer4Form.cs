﻿using System;
using System.Windows.Forms;
using v2rayN.Handler;
using v2rayN.Mode;

namespace v2rayN.Forms
{
    public partial class AddServer4Form : BaseServerForm
    {

        public AddServer4Form()
        {
            InitializeComponent();
        }

        private void AddServer4Form_Load(object sender, EventArgs e)
        {
            if (vmessItem != null)
            {
                BindingServer();
            }
            else
            {
                vmessItem = new VmessItem();
                vmessItem.groupId = groupId;
                ClearServer();
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindingServer()
        {
            txtAddress.Text = vmessItem.address;
            txtPort.Text = vmessItem.port.ToString();
            txtId.Text = vmessItem.id;
            txtSecurity.Text = vmessItem.security;
            txtRemarks.Text = vmessItem.remarks;
        }


        /// <summary>
        /// 清除设置
        /// </summary>
        private void ClearServer()
        {
            txtAddress.Text = "";
            txtPort.Text = "";
            txtId.Text = "";
            txtSecurity.Text = "";
            txtRemarks.Text = "";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string address = txtAddress.Text;
            string port = txtPort.Text;
            string id = txtId.Text;
            string security = txtSecurity.Text;
            string remarks = txtRemarks.Text;

            if (Utils.IsNullOrEmpty(address))
            {
                UI.Show(UIRes.I18N("FillServerAddress"));
                return;
            }
            if (Utils.IsNullOrEmpty(port) || !Utils.IsNumberic(port))
            {
                UI.Show(UIRes.I18N("FillCorrectServerPort"));
                return;
            }

            vmessItem.address = address;
            vmessItem.port = Utils.ToInt(port);
            vmessItem.id = id;
            vmessItem.security = security;
            vmessItem.remarks = remarks;

            if (ConfigHandler.AddSocksServer(ref config, vmessItem) == 0)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                UI.ShowWarning(UIRes.I18N("OperationFailed"));
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }


    }
}
