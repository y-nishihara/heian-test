using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//namespace HEIAN_Library.N_機械.N_印字装置.N_Nerva8100
namespace Mifare処理依頼
{
	public partial class C_Nerva8100ホスト
	{
		public C_Nerva8100ホスト()
		{
		}


		public partial class C_コントローラー
		{
			public class C_カートリッジホルダー
			{
				public C_カートリッジホルダー()
				{
				}

				public Action<float> R_インク処理中 = null;

				public class C_カートリッジ情報 : C_マイフェア管理.C_マイフェアデータ.C_リードオンリーデータ
				{
					public C_カートリッジ情報()
					{
						this.V_データID = 1;
					}

					public byte P_カートリッジID
					{
						get
						{
							return this.R_ROデータ[0];
						}
						set
						{
							this.R_ROデータ[0] = value;
						}
					}
					public enum en_インク種別
					{
						不明 = 0, B01 = 1, B02 = 2, R01 = 11
					}
					public en_インク種別 P_インク種別
					{
						get
						{
							return (en_インク種別)Enum.ToObject(typeof(en_インク種別), this.R_ROデータ[1]);
						}
						set
						{
							this.R_ROデータ[1] = (byte)value;
						}
					}
					public short P_インク容量ml
					{
						get
						{
							return System.BitConverter.ToInt16(this.R_ROデータ, 2);
						}
						set
						{
							System.BitConverter.GetBytes(value).CopyTo(this.R_ROデータ, 2);
						}
					}
					public string P_インクカートリッジ型式名称
					{
						get
						{
							byte[] LR_value = new byte[12];
							Array.Copy(this.R_ROデータ, 4, LR_value, 0, LR_value.Length);
							return Encoding.GetEncoding("shift_jis").GetString(LR_value);
						}
						set
						{
							byte[] LR_value = Encoding.GetEncoding("shift_jis").GetBytes(value);
							int LR_長 = LR_value.Length > 12 ? 12 : LR_value.Length;
							Array.Copy(LR_value, 0, this.R_ROデータ, 4, LR_長);
						}
					}
				}

				public class C_カートリッジ作成情報 : C_マイフェア管理.C_マイフェアデータ.C_リードオンリーデータ
				{
					public C_カートリッジ作成情報()
					{
						this.V_データID = 2;
					}

					public DateTime P_インクデータ作成日時
					{
						get
						{
							return DateTime.FromBinary(BitConverter.ToInt64(this.R_ROデータ, 0));
						}
						set
						{
							BitConverter.GetBytes(value.ToBinary()).CopyTo(this.R_ROデータ, 0);
						}
					}

					public DateTime P_未使用インク使用期限
					{
						get
						{
							return DateTime.FromBinary(BitConverter.ToInt64(this.R_ROデータ, 8));
						}
						set
						{
							BitConverter.GetBytes(value.ToBinary()).CopyTo(this.R_ROデータ, 8);
						}
					}
				}

				public class C_インク使用開始情報 : C_マイフェア管理.C_マイフェアデータ.C_リードオンリーデータ
				{
					public C_インク使用開始情報()
					{
						this.V_データID = 3;
					}

					public DateTime P_インク初回使用日時
					{
						get
						{
							return DateTime.FromBinary(BitConverter.ToInt64(this.R_ROデータ, 0));
						}
						set
						{
							BitConverter.GetBytes(value.ToBinary()).CopyTo(this.R_ROデータ, 0);
						}
					}

					public DateTime P_インク使用期限
					{
						get
						{
							return DateTime.FromBinary(BitConverter.ToInt64(this.R_ROデータ, 8));
						}
						set
						{
							BitConverter.GetBytes(value.ToBinary()).CopyTo(this.R_ROデータ, 8);
						}
					}
				}

				public class C_インク初回使用から最終使用までの間隔 : C_マイフェア管理.C_マイフェアデータ.C_ウェアレベリングデータ
				{
					public C_インク初回使用から最終使用までの間隔()
					{
						this.V_データID = 11;
					}

					TimeSpan? V_インク初回使用から最終使用までの間隔 = null;

					public TimeSpan P_インク初回使用から最終使用までの間隔
					{
						get
						{
							if (this.V_インク初回使用から最終使用までの間隔 == null)
							{
								this.V_インク初回使用から最終使用までの間隔 = new TimeSpan(0, 0, (BitConverter.ToInt32(this.R_RWデータ, 0)));
							}
							return this.V_インク初回使用から最終使用までの間隔.Value;
						}
						set
						{
							this.V_インク初回使用から最終使用までの間隔 = value;
							BitConverter.GetBytes((int)value.TotalSeconds).CopyTo(this.R_RWデータ, 0);
						}
					}
				}

				public class C_インク使用量 : C_マイフェア管理.C_マイフェアデータ.C_ウェアレベリングデータ
				{
					public C_インク使用量()
					{
						this.V_データID = 12;
					}

					long? V_インク使用量 = null;
					public long P_インク使用量pix
					{
						get
						{
							if (this.V_インク使用量 == null)
							{
								this.V_インク使用量 = System.BitConverter.ToUInt32(this.R_RWデータ, 0) * 10;
							}
							return this.V_インク使用量.Value;
						}
						set
						{
							this.V_インク使用量 = value;
							decimal dm = Math.Round(value / 10.0m);
							uint ui = dm < uint.MaxValue ? (uint)dm : uint.MaxValue;
							System.BitConverter.GetBytes(ui).CopyTo(this.R_RWデータ, 0);
						}
					}
				}

				public class C_パルスウォーミング累計時間 : C_マイフェア管理.C_マイフェアデータ.C_ウェアレベリングデータ
				{
					public C_パルスウォーミング累計時間()
					{
						this.V_データID = 13;
					}

					TimeSpan? V_パルスウォーミング累計時間 = null;
					public TimeSpan P_パルスウォーミング累計時間
					{
						get
						{
							if (this.V_パルスウォーミング累計時間 == null)
							{
								decimal dm = BitConverter.ToUInt32(this.R_RWデータ, 0) * 10.0m;
								int s = (int)(dm / 1000);
								int ms = (int)(dm % 1000);

								this.V_パルスウォーミング累計時間 = new TimeSpan(0, 0, 0, s, ms);
							}
							return this.V_パルスウォーミング累計時間.Value;
						}
						set
						{
							this.V_パルスウォーミング累計時間 = value;
							int s = (int)value.TotalSeconds;
							int ms = value.Milliseconds;

							decimal dm = (decimal)value.TotalMilliseconds / 10.0m;
							uint ui = dm < uint.MaxValue ? (uint)dm : uint.MaxValue;
							System.BitConverter.GetBytes(ui).CopyTo(this.R_RWデータ, 0);
						}
					}
				}

				public class C_インク無効日時 : C_マイフェア管理.C_マイフェアデータ.C_リードオンリーデータ
				{
					public C_インク無効日時()
					{
						this.V_データID = 4;
					}

					public DateTime P_インク無効日時
					{
						get
						{
							return DateTime.FromBinary(BitConverter.ToInt64(this.R_ROデータ, 0));
						}
						set
						{
							BitConverter.GetBytes(value.ToBinary()).CopyTo(this.R_ROデータ, 0);
						}
					}
				}


				public C_カートリッジ情報 R_カートリッジ情報 = new C_カートリッジ情報();
				public C_カートリッジ作成情報 R_カートリッジ作成情報 = new C_カートリッジ作成情報();
				public C_インク使用開始情報 R_インク使用開始情報 = new C_インク使用開始情報();
				public C_インク初回使用から最終使用までの間隔 R_インク初回使用から最終使用までの間隔 = new C_インク初回使用から最終使用までの間隔();
				public C_インク使用量 R_インク使用量 = new C_インク使用量();
				public C_パルスウォーミング累計時間 R_パルスウォーミング累計時間 = new C_パルスウォーミング累計時間();
				public C_インク無効日時 R_インク無効日時 = new C_インク無効日時();

				public C_マイフェア管理 R_マイフェア管理 = new C_マイフェア管理("NERVA".ToCharArray());


			}

			public C_コントローラー()
			{
				this.R_RFID操作 = new C_RFID操作(this.R_コントローラーライブラリー);
			}

			public bool F_接続(string AR_IPアドレス)
			{
				try
				{
					this.R_コントローラーライブラリー.Open(System.Net.IPAddress.Parse(AR_IPアドレス));
				}
				catch (Exception)
				{
				}
				return this.R_コントローラーライブラリー.IsOpend;
			}
			public void F_切断()
			{
				this.R_コントローラーライブラリー.Close();
			}


			public void F_システムファイル照合()
			{
				for (int i = 0; i < this.R_カートリッジホルダーリスト.Length; i++)
				{
					if (this.R_カートリッジホルダーリスト[i].R_マイフェア管理.F_システムファイル読込み(this.R_RFID操作.F_システムファイルデータ取得()) == false)
					{
						if (this.F_マージ(i,this.R_カートリッジホルダーリスト[i].R_インク処理中) == false)
						{
							continue;
						}
					}
					this.R_カートリッジホルダーリスト[i].R_マイフェア管理.F_データ読込み(new List<C_マイフェア管理.C_マイフェアデータ.B_データ>() 
					{
						this.R_カートリッジホルダーリスト[i].R_カートリッジ情報,
						this.R_カートリッジホルダーリスト[i].R_カートリッジ作成情報, 
						this.R_カートリッジホルダーリスト[i].R_インク使用開始情報, 
						this.R_カートリッジホルダーリスト[i].R_インク初回使用から最終使用までの間隔, 
						this.R_カートリッジホルダーリスト[i].R_インク使用量, 
						this.R_カートリッジホルダーリスト[i].R_パルスウォーミング累計時間, 
						this.R_カートリッジホルダーリスト[i].R_インク無効日時
					});
				}
			}

			public bool F_マージ(int AV_ch,Action<float> AR_途中経過処理)
			{
				return this.R_カートリッジホルダーリスト[AV_ch].R_マイフェア管理.F_再構築(this.R_RFID操作.F_全データ取得(AV_ch, AR_途中経過処理)) == false;
			}

			public void F_UID確認()
			{
				for (int i = 0; i < this.R_カートリッジホルダーリスト.Length; i++)
				{
					if (this.R_カートリッジホルダーリスト[i].R_マイフェア管理.F_UID取得() == this.R_RFID操作.F_UID取得(i)==false)
					{
						this.F_マージ(i, this.R_カートリッジホルダーリスト[i].R_インク処理中);
					}
				}
			}

			public void F_システムファイル更新()
			{
				for (int i = 0; i < this.R_カートリッジホルダーリスト.Length; i++)
				{
					this.R_RFID操作.F_システムファイルデータ書込み(i,this.R_カートリッジホルダーリスト[i].R_マイフェア管理.F_システムファイル保存());
				}
			}

			public void F_インク消費(int[] AV_インク使用量)
			{
				for (int i = 0; i < this.R_カートリッジホルダーリスト.Length; i++)
				{
					this.R_カートリッジホルダーリスト[i].R_インク使用量.P_インク使用量pix += AV_インク使用量[i];
					if (this.R_カートリッジホルダーリスト[i].R_インク使用開始情報.V_書込み済み == true)
					{
						this.R_カートリッジホルダーリスト[i].R_インク初回使用から最終使用までの間隔.P_インク初回使用から最終使用までの間隔 = DateTime.Now - this.R_カートリッジホルダーリスト[i].R_インク使用開始情報.P_インク初回使用日時;
					}
				}
			}

			public void F_パルスウォーミング時間追加(int AV_パルスウォーミング時間ms)
			{
				for (int i = 0; i < this.R_カートリッジホルダーリスト.Length; i++)
				{
					this.R_カートリッジホルダーリスト[i].R_パルスウォーミング累計時間.P_パルスウォーミング累計時間= this.R_カートリッジホルダーリスト[i].R_パルスウォーミング累計時間.P_パルスウォーミング累計時間.Add(new TimeSpan(0, 0, 0,0, AV_パルスウォーミング時間ms));
				}
			}

			public void F_インク消費書込み()
			{
				for (int i = 0; i < this.R_カートリッジホルダーリスト.Length; i++)
				{
					List<C_マイフェア管理.C_マイフェアデータ.B_データ> LR_書込みデータリスト = new List<C_マイフェア管理.C_マイフェアデータ.B_データ>();

					LR_書込みデータリスト.Add(this.R_カートリッジホルダーリスト[i].R_インク使用量);
					LR_書込みデータリスト.Add(this.R_カートリッジホルダーリスト[i].R_パルスウォーミング累計時間);
					if (this.R_カートリッジホルダーリスト[i].R_インク使用開始情報.V_書込み済み == false)
					{
						this.R_カートリッジホルダーリスト[i].R_インク使用開始情報.P_インク初回使用日時 = DateTime.Now;
						this.R_カートリッジホルダーリスト[i].R_インク使用開始情報.P_インク使用期限 = DateTime.Now.AddYears(1);
						LR_書込みデータリスト.Add(this.R_カートリッジホルダーリスト[i].R_インク使用開始情報);
					}
					this.R_RFID操作.F_データ書込み(i,this.R_カートリッジホルダーリスト[i].R_マイフェア管理.F_データ書込み(LR_書込みデータリスト));
				}
			}

			public void F_終了時操作()
			{
				for (int i = 0; i < this.R_カートリッジホルダーリスト.Length; i++)
				{
					List<C_マイフェア管理.C_マイフェアデータ.B_データ> LR_書込みデータリスト = new List<C_マイフェア管理.C_マイフェアデータ.B_データ>();
					LR_書込みデータリスト.Add(this.R_カートリッジホルダーリスト[i].R_インク初回使用から最終使用までの間隔);
					this.R_RFID操作.F_データ書込み(i,this.R_カートリッジホルダーリスト[i].R_マイフェア管理.F_データ書込み(LR_書込みデータリスト));
					this.F_システムファイル更新();
				}
			}

			public void F_インク作成()
			{
				for (int i = 0; i < this.R_カートリッジホルダーリスト.Length; i++)
				{
					List<C_マイフェア管理.C_マイフェアデータ.B_データ> LR_書込みデータリスト = new List<C_マイフェア管理.C_マイフェアデータ.B_データ>();

					this.R_カートリッジホルダーリスト[i].R_カートリッジ情報.P_インクカートリッジ型式名称 = "CI-B02L";
					this.R_カートリッジホルダーリスト[i].R_カートリッジ情報.P_インク種別 =　C_カートリッジホルダー.C_カートリッジ情報.en_インク種別.B02;
					this.R_カートリッジホルダーリスト[i].R_カートリッジ情報.P_インク容量ml = 370;
					this.R_カートリッジホルダーリスト[i].R_カートリッジ情報.P_カートリッジID = 255;
					LR_書込みデータリスト.Add(this.R_カートリッジホルダーリスト[i].R_カートリッジ情報);

					this.R_カートリッジホルダーリスト[i].R_カートリッジ作成情報.P_インクデータ作成日時 = DateTime.Now;
					this.R_カートリッジホルダーリスト[i].R_カートリッジ作成情報.P_未使用インク使用期限 = DateTime.Now.AddYears(3);
					LR_書込みデータリスト.Add(this.R_カートリッジホルダーリスト[i].R_カートリッジ作成情報);

					this.R_RFID操作.F_データ書込み(i,this.R_カートリッジホルダーリスト[i].R_マイフェア管理.F_データ書込み(LR_書込みデータリスト));
				}
			}

			Nerva8100.Nerva8100Controller R_コントローラーライブラリー = new Nerva8100.Nerva8100Controller();
			public C_コントローラー.C_RFID操作 R_RFID操作 = null;
			public C_カートリッジホルダー[] R_カートリッジホルダーリスト = new C_カートリッジホルダー[8]
		{
			new C_カートリッジホルダー(),
			new C_カートリッジホルダー(),
			new C_カートリッジホルダー(),
			new C_カートリッジホルダー(),
			new C_カートリッジホルダー(),
			new C_カートリッジホルダー(),
			new C_カートリッジホルダー(),
			new C_カートリッジホルダー()
		};
		}

		public C_コントローラー R_コントローラー = new C_コントローラー();



	}
}
