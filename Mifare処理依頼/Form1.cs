using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HEIAN_Library.N_システム;

namespace Mifare処理依頼
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			this.groupBox_操作クラス.Enabled = false;
			this.comboBox_管理_データ種別.SelectedIndex = 0;
			this.comboBox_操作_Ch.SelectedIndex = 0;
		}

		C_Nerva8100ホスト R_Nerva8100ホスト = new C_Nerva8100ホスト();
		C_マイフェア管理 R_マイフェア管理 = new C_マイフェア管理("Nerva".ToCharArray());
	}
}
