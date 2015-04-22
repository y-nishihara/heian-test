using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//namespace HEIAN_Library.N_機械.N_印字装置.N_Nerva8100
namespace Mifare処理依頼
{
	public partial class C_Nerva8100ホスト
	{
		public partial class C_コントローラー
		{
			public class C_RFID操作
			{
				public C_RFID操作(Nerva8100.Nerva8100Controller AR_コントローラーライブラリー, int AV_ch)
				{
					this.R_コントローラーライブラリー = AR_コントローラーライブラリー;
					this.V_ch = AV_ch;
				}

				Nerva8100.Nerva8100Controller R_コントローラーライブラリー;
				int V_ch;
				byte[] V_key = C_マイフェア管理.C_マイフェアデータ.SR_KeyA;
				

				public C_マイフェア管理.C_マイフェアデータ.C_ブロック_システムファイルデータ F_システムファイルデータ取得()
				{
					C_マイフェア管理.C_マイフェアデータ.C_ブロック_システムファイルデータ LR_システムファイルデータブロック = new C_マイフェア管理.C_マイフェアデータ.C_ブロック_システムファイルデータ();
					int LV_UID=0;
					LR_システムファイルデータブロック.V_システムファイルデータブロック取得時UID = LV_UID;
					return LR_システムファイルデータブロック;
				}

				public List<byte[]> F_全データ取得(Action<float> AR_進捗報告動作)
				{
					List<byte[]> LR_データリスト= new List<byte[]>();

					byte[] LR_UID;
					int i = 1;
					for (int fe_セクターNo = 0; fe_セクターNo < 16; fe_セクターNo++)
					{
						for (int fe_ブロックNo = 0; fe_ブロックNo < 4; fe_ブロックNo++)
						{
							byte[] LR_データ;
							this.R_コントローラーライブラリー.ReadRfidData(this.V_ch,fe_セクターNo,fe_ブロックNo,V_key,out LR_データ,out LR_UID);
							LR_データリスト.Add(LR_データ);

							if (AR_進捗報告動作 != null)
							{
								int j = i;
								HEIAN_Library.N_システム.C_スレッドプール.SF_バックグラウンド処理(() =>
									{
										AR_進捗報告動作((float)j / (4 * 16));
									});
								i++;
							}
						}
					}

					return LR_データリスト;
				}

				public uint F_UID取得()
				{
					return 0;
				}

				public bool F_データ書込み(C_マイフェア管理.C_マイフェアデータ.B_ブロック AR_ブロック)
				{
					return true;
				}

				public bool F_データ照合(C_マイフェア管理.C_マイフェアデータ.B_ブロック AR_ブロック)
				{
					return true;
				}

				public bool F_システムファイルデータ書込み(C_マイフェア管理.C_マイフェアデータ.C_ブロック_システムファイルデータ AR_システムファイルデータブロック)
				{
					return true;
				}

				public bool F_初期化(C_マイフェア管理.C_マイフェアデータ AR_データ)
				{
					return true;
				}
			}
		}
	}
}
