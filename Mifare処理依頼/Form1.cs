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
        //ynyn    
        ////C_Nerva8100ホスト R_Nerva8100ホスト = new C_Nerva8100ホスト();

        #region フォームイベント処理(管理クラス)

        private void button_接続_Click(object sender, EventArgs e)
        {
            bool b_ret = false;
            b_ret = R_Nerva8100ホスト.R_コントローラー.F_接続(textBox_IPアドレス.Text);
        }

        //private void button_切断_Click(object sender, EventArgs e)
        //{
        //    bool b_ret = false;
        //    b_ret = R_Nerva8100ホスト.R_コントローラー.F_切断(textBox_IPアドレス.Text);
        //}

        private void button_管理_UID取得_Click(object sender, EventArgs e)
        {
            button_管理_UID取得.Text = R_マイフェア管理.F_UID取得().ToString();
        }

        private void button_管理_システムファイル読込み_Click(object sender, EventArgs e)
        {
            bool b_ret = false;
            C_マイフェア管理.C_マイフェアデータ.C_ブロック_システムファイルデータ V_ブロック_システムファイルデータ = new C_マイフェア管理.C_マイフェアデータ.C_ブロック_システムファイルデータ();

            b_ret = R_マイフェア管理.F_システムファイル読込み(V_ブロック_システムファイルデータ);
            textBox_管理_CheckMD5.Text = V_ブロック_システムファイルデータ.V_Check_MD5.ToString();
        }

        private void button_管理_システムファイル保存_Click(object sender, EventArgs e)
        {
            C_マイフェア管理.C_マイフェアデータ.C_ブロック_システムファイルデータ V_ブロック_システムファイルデータ = new C_マイフェア管理.C_マイフェアデータ.C_ブロック_システムファイルデータ();

            R_マイフェア管理.F_システムファイル保存();
        }

        private void button_管理_初期化_Click(object sender, EventArgs e)
        {
            int V_総セクター数;
            int V_ウェアレベリングセクター数;

            try
            {
                V_総セクター数 = int.Parse(textBox_管理_総セクター数.Text);
                V_ウェアレベリングセクター数 = int.Parse(textBox_管理_ウェアレベリングセクター数.Text);
                R_マイフェア管理.F_初期化(V_総セクター数, V_ウェアレベリングセクター数);
            }
            catch (System.Exception ex)
            {
                // 失敗したとき
                System.Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
            }
        }

        private void button_管理_再構築_Click(object sender, EventArgs e)
        {
            //ynyn
            List<byte[]> R_全Mifareタグデータ = new List<byte[]>();
            R_マイフェア管理.F_再構築(R_全Mifareタグデータ);
        }

        #endregion フォームイベント処理(管理クラス)

        #region フォームイベント処理(操作クラス)

        private void button_操作_UID取得_Click(object sender, EventArgs e)
        {
            //button_操作_UID取得.Text = R_Nerva8100ホスト.R_コントローラー.C_RFID操作.F_UID取得().ToString();
        }

        private void button_操作_システムファイルデータ取得_Click(object sender, EventArgs e)
        {
            //？？？
        }

        private void button_操作_システムファイルデータ書込み_Click(object sender, EventArgs e)
        {
            //F_システムファイルデータ書込み
        }

        private void button_操作_データ書込み_Click(object sender, EventArgs e)
        {
            //??
            //C_マイフェア管理.C_マイフェアデータ.B_ブロック V_ブロック = new C_マイフェア管理.C_マイフェアデータ.B_ブロック();

            //V_ブロック.C_RFID操作.F_データ書込み();

        }

        private void button_操作_データ照合_Click(object sender, EventArgs e)
        {
            //F_データ照合

        }

        private void button_操作_初期化_Click(object sender, EventArgs e)
        {
            //F_初期化
        }

        private void button_操作_全データ取得_Click(object sender, EventArgs e)
        {
            // List<byte[]> F_全データ取得(Action<float> AR_進捗報告動作)
        }

        #endregion フォームイベント処理(操作クラス)

    }
}
