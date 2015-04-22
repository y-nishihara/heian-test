using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//namespace HEIAN_Library.N_機械.N_印字装置.N_Nerva8100
namespace Mifare処理依頼
{
	public partial class C_Nerva8100ホスト
	{
		public class C_カートリッジホルダー
		{
			public class C_カートリッジ情報 : C_マイフェア管理.C_マイフェアデータ.C_リードオンリーデータ
			{
				public C_カートリッジ情報()
				{
					this.V_データID = 1;
				}

				byte V_カートリッジID;
				byte V_インク種別;
				short V_インク容量ml;
				string R_カートリッジ型式;

				public byte P_カートリッジID
				{
					get
					{
						return this.R_ROデータ[0];
					}
				}
				public byte P_インク種別
				{
					get
					{
						return this.R_ROデータ[1];
					}
				}
				public short P_インク容量
				{
					get
					{
						return System.BitConverter.ToInt16(this.R_ROデータ, 2);
					}
				}
				public string P_カートリッジ型式
				{
					get
					{
						string s = "";
						for (int i = 4; i < 8; i++)
						{
							char c = System.BitConverter.ToChar(this.R_ROデータ, i);
							if (c != '\0')
							{
								s += c;
							}
						}
						return s;
					}
				}

			}

			public class C_インク使用量 : C_マイフェア管理.C_マイフェアデータ.C_ウェアレベリングデータ
			{
				public C_インク使用量()
				{
					this.V_データID = 11;
				}

				public long P_インク使用量
				{
					set
					{
						decimal m = Math.Round(value / 10.0m);
						uint i = m < uint.MaxValue ? (uint)m : uint.MaxValue;
						this.R_RWデータ = System.BitConverter.GetBytes(i);
					}
					get
					{
						return System.BitConverter.ToUInt32(this.R_RWデータ, 0);
					}
				}
			}

			C_カートリッジ情報 R_カートリッジ情報;
			C_インク使用量 R_インク使用量;
			public C_マイフェア管理 R_RFID = new C_マイフェア管理("NERVA".ToCharArray());
		}

		public partial class C_コントローラー
		{
			public bool F_接続(string AR_IPアドレス)
			{
				try
				{
					this.R_コントローラーライブラリー.Open(System.Net.IPAddress.Parse(AR_IPアドレス));
					this.R_コントローラーライブラリー.OpenSerialPort();
				}
				catch (Exception)
				{
					return false;
				}
				return true;
			}
			Nerva8100.Nerva8100Controller R_コントローラーライブラリー = new Nerva8100.Nerva8100Controller();
		}

		public C_コントローラー R_コントローラー = new C_コントローラー();
		
	}
}
