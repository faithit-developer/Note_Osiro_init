using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Note_Osiro
{
    public partial class Form1 : Form
    {

        const int FILESIZE = 1024;
        //--------------------------------------------------------------------------
        //描画用
        //--------------------------------------------------------------------------
        Bitmap canvas_base;
        // ▼ ここに _displayCanvas の宣言を追加する
        private Bitmap _displayCanvas = null;
        Graphics g_base;
        //--------------------------------------------------------------------------
        //データローガ―
        //--------------------------------------------------------------------------
        int iXmax = FILESIZE;                       //データローガ―画面サイズ
        int iYmax = 400;                        //データローガ―画面サイズ

        int skipCount = 0;                      //時間軸調整用（間引き)
        //--------------------------------------------------------------------------
        //スレッド管理用
        //--------------------------------------------------------------------------
        Thread _thread_1;             //

        //--------------------------------------------------------------------------
        //シミュレーション用
        //--------------------------------------------------------------------------
        ArrayBuffer Grid_V = new ArrayBuffer();

        // クラスのフィールド宣言部分
        private bool _isPaused = false;
        private CancellationTokenSource _cts_1;
        double CarrierFreq = 1;
        double Mabiki = 1;                      //時間軸調整用（間引き)

        int ch1Yscale1 = 1;
        int ch2Yscale1 = 1;
        int ch3Yscale1 = 1;
        int ch4Yscale1 = 1;

        // ★ ここに位相（サイン波生成用）のフィールド変数が必要！
        double _phase = 0.0;

        //**************************************************************************
        // 【処理名】コンストラクタ
        // 【処理内容】フォームの初期化および多重起動チェックを行います
        //**************************************************************************
        public Form1()
        {
            InitializeComponent();
            #region 二重起動をチェックする
            if (System.Diagnostics.Process.GetProcessesByName(
                System.Diagnostics.Process.GetCurrentProcess().ProcessName).Length > 1)
            {
                Close();
            }
            #endregion 二重起動をチェックする
        }
        #region ■フォームイベント管理  FormMain_Load
        //**************************************************************************
        //【処 理 名】初期化処理
        //【処理内容】フォームが初めて表示される直前に発生します
        //**************************************************************************
        private void Form1_Load(object sender, EventArgs e)
        {

            textBoxCarrierFreq.Text = CarrierFreq.ToString();
            textBoxMabiki.Text = Mabiki.ToString();



            //---------------------------------------------------------
            //スレッド破棄
            //---------------------------------------------------------
            if (_thread_1 != null) { _thread_1.Abort(); }
            //---------------------------------------------------------
            //タイマー関連
            //---------------------------------------------------------
            timer1.Interval = 16;
            timer1.Enabled = true;

            //------------------------------------------------------------------
            // 描画先とするImageオブジェクトを作成する (初回のみ)
            //------------------------------------------------------------------

            canvas_base = new Bitmap(iXmax, iYmax);
            Graphics g_base = Graphics.FromImage(canvas_base);

            Pen p = new Pen(Color.FromArgb(255, 255, 255));
            SolidBrush b = new SolidBrush(Color.FromArgb(255, 0, 0, 0));

            // 背景の塗りつぶし
            g_base.FillRectangle(b, 0, 0, iXmax, iYmax);

            // X座標グリッド線の描画
            for (int i = 0; i < iXmax / 2; i += 20)
            {
                if (i == iXmax / 2 || i % 100 == 0) { p.DashStyle = DashStyle.Solid; p.Color = Color.FromArgb(128, 128, 128); }
                else { p.DashStyle = DashStyle.Dot; p.Color = Color.FromArgb(100, 100, 100); }
                g_base.DrawLine(p, iXmax / 2 + i, 0, iXmax / 2 + i, iYmax);
                g_base.DrawLine(p, iXmax / 2 - i, 0, iXmax / 2 - i, iYmax);
            }
            // Y座標グリッド線の描画
            for (int i = 0; i < iYmax / 2; i += 20)
            {
                if (i == iYmax / 2 || i % 100 == 0) { p.DashStyle = DashStyle.Solid; p.Color = Color.FromArgb(128, 128, 128); }
                else { p.DashStyle = DashStyle.Dot; p.Color = Color.FromArgb(100, 100, 100); }
                g_base.DrawLine(p, 0, iYmax / 2 + i, iXmax, iYmax / 2 + i);
                g_base.DrawLine(p, 0, iYmax / 2 - i, iXmax, iYmax / 2 - i);
            }

            // ★ 修正：グリッド線を描画した「後」に外枠を描画する（はみ出しをマスクする）
            // ※ Bitmapの端まで綺麗に枠線を描くため、サイズは (iXmax - 1, iYmax - 1) に調整します
            g_base.DrawRectangle(Pens.White, 0, 0, iXmax - 1, iYmax - 1);

            p.Dispose();
            b.Dispose();
            g_base.Dispose();


        }
        //**************************************************************************
        //【処 理 名】Form1_FormClosing
        //【処理内容】フォームが閉じる直前に実行され、動作中のスレッドの安全な停止処理を行います
        //**************************************************************************
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 1. キャンセル要求を送る
            if (_cts_1 != null)
            {
                _cts_1.Cancel();
            }

            // 2. スレッドが終了するのを待つ（UIがフリーズするのを防ぐため、必要に応じてタイムアウトを指定）
            if (_thread_1 != null && _thread_1.IsAlive)
            {
                // 例: 最大1秒間スレッドの終了を待機する
                _thread_1.Join(1000);
            }

            // 3. CancellationTokenSourceなどのリソース解放
            if (_cts_1 != null)
            {
                _cts_1.Dispose();
                _cts_1 = null;
            }
        }
 

        #endregion ■フォームイベント管理


        #region ■コントロールイベント管理
        //**************************************************************************
        //【処 理 名】btn_Task1_Click
        //【処理内容】シミュレーションタスクの開始および停止を切り替えます
        //**************************************************************************
        private void btn_Task1_Click(object sender, EventArgs e)
        {
            // --- 停止処理 ---
            // キャンセルソースが存在し、かつスレッドが稼働中の場合
            if (_cts_1 != null && !_cts_1.IsCancellationRequested)
            {
                // 1. キャンセル要求を送信
                _cts_1.Cancel();

                // 2. ボタンの状態を元に戻す
                btn_Task1.Text = "開始";
                btn_Task2.Text = "----";
                btn_Task2.Enabled = false;


                // 必要に応じてスレッドの終了を少し待つ（UIフリーズを防ぐため Join は注意が必要ですが、短時間なら可）
                // _thread_1?.Join(); 
                _thread_1 = null;
                _cts_1.Dispose();
                _cts_1 = null;
            }
            // --- 開始処理 ---
            else
            {
                _isPaused = false;
                Grid_V.CleaBuffer();
                // キャンセルソースを新しく作成
                _cts_1 = new CancellationTokenSource();

                btn_Task1.Text = "停止";
                btn_Task2.Enabled = true;
                btn_Task2.Text = "一時停止";

                // スレッドを作成し、トークンを渡して開始
                _thread_1 = new System.Threading.Thread(() => ThreadProc(_cts_1.Token));
                _thread_1.Start();
            }
        }

        //**************************************************************************
        //【処 理 名】btn_Task2_Click
        //【処理内容】シミュレーションの一時停止および再開を切り替えます
        //**************************************************************************
        private void btn_Task2_Click(object sender, EventArgs e)
        {
            if (!_isPaused)
            {
                // 一時停止にする
                _isPaused = true;
                btn_Task2.Text = "再開";
            }
            else
            {
                // 再開する
                _isPaused = false;
                btn_Task2.Text = "一時停止";
            }
        }
        //**************************************************************************
        //【処 理 名】buttonClose_Click
        //【処理内容】アプリケーション終了処理
        //**************************************************************************
        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        //**************************************************************************
        //【処 理 名】textBoxCarrierFreq_Validated
        //【処理内容】テキストボックスの値確定後に設定値をアプリケーション設定へ反映します
        //**************************************************************************
        private void double_Validated(object sender, EventArgs e)
        {
            TextBox oTb = (TextBox)sender;

            //キャリア周波数
            if (oTb.Name.Equals("textBoxCarrierFreq")) { CarrierFreq = double.Parse(oTb.Text); }
            if (oTb.Name.Equals("textBoxMabiki")) { Mabiki = double.Parse(oTb.Text); }

        }
 
        //**************************************************************************
        //【処 理 名】TextBoxDouble_Validating
        //【処理内容】テキストボックスに入力された数値の妥当性（範囲・型）を検証します
        //**************************************************************************
        private void double_Validating(object sender, CancelEventArgs e)
        {
            TextBox oTb = (TextBox)sender;

            double cancelValue = 0;
            double limitMin = 0;
            double limitMax = 999999;

            //キャリア周波数
            if (oTb.Name.Equals("textBoxCarrierFreq")) { limitMin = 0.001; limitMax = 90; cancelValue = CarrierFreq; }
            if (oTb.Name.Equals("textBoxMabiki"))       { limitMin = 0.001; limitMax = 1; cancelValue = Mabiki; }


            if (oTb.Text != null && oTb.Text != "")
            {
                if (double.TryParse(oTb.Text.ToString(), out double i))
                {
                    if ((i >= limitMin) && (i <= limitMax))
                    {
                        // 正常範囲内
                    }
                    else
                    {
                        MessageBox.Show("入力範囲エラー", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        // 範囲外の場合は元の値に戻す
                        oTb.Text = cancelValue.ToString();
                    }
                }
                else
                {
                    MessageBox.Show("入力範囲エラー", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // 変換エラーの場合は元の値に戻す
                    oTb.Text = cancelValue.ToString();
                }
            }
            else
            {
                MessageBox.Show("空白にすることはできません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // 空白エラーの場合は元の値に戻す
                oTb.Text = cancelValue.ToString();
            }
        }
 
        #endregion



        #region ■タイマー管理
        //**************************************************************************
        //【処 理 名】timer1_Tick
        //【処理内容】タイマ―処理によるデータローガー画面（波形）の定期更新
        //**************************************************************************
        private void timer1_Tick(object sender, EventArgs e)
        {
            int width = pictureBox1.Width;
            int height = pictureBox1.Height;
            if (width <= 0 || height <= 0) return;

            // 1. 表示用のBitmap管理
            if (_displayCanvas == null || _displayCanvas.Width != width || _displayCanvas.Height != height)
            {
                _displayCanvas?.Dispose();
                _displayCanvas = new Bitmap(width, height);
                pictureBox1.Image = _displayCanvas;
            }
           
            // 1. 【ここでデータを生成してバッファに書き込む】（スレッドがないのでタイマー内で実行）
            double val1 = Math.Sin(_phase) * 100.0;
            double val2 = Math.Sin(_phase + Math.PI / 2) * 100.0;
            double val3 = Math.Sin(_phase + Math.PI) * 50.0;
            double val4 = Math.Sin(_phase + Math.PI * 1.5) * 75.0;

            // ※ ここでArrayBufferに書き込むことで、初めてFIFOにデータが入る！
            Grid_V.Write(val1, val2, val3, val4);
            _phase += 0.12; // 位相を進める
            
 


            int drawCount = Math.Min(iXmax, width);
            drawCount = Math.Min(drawCount, FILESIZE);

            // 描画データを一時的に退避するローカル配列を用意
            double[] localY1 = new double[drawCount];
            double[] localY2 = new double[drawCount];
            double[] localY3 = new double[drawCount];
            double[] localY4 = new double[drawCount];

            // ==========================================================
            // ① 【重要】ロック時間は極限まで短くする（データの読み出しとポインタ更新だけ！）
            // ==========================================================
            //lock (Grid_V)
           // {
                int writePtr = Grid_V.GetWritePointer();

                for (int i = 0; i < drawCount; i++)
                {
                    int iAddress = (writePtr - drawCount + i + FILESIZE) % FILESIZE;
                    localY1[i] = Grid_V.Read1(iAddress);
                    localY2[i] = Grid_V.Read2(iAddress);
                    localY3[i] = Grid_V.Read3(iAddress);
                    localY4[i] = Grid_V.Read4(iAddress);
                }

                // リードポインタを進めて、書き込み側のオーバーフローを防ぐ
                int targetReadPtr = (writePtr - drawCount + FILESIZE) % FILESIZE;
                int currentReadPtr = Grid_V.GetReadPointer();
                int diff = (targetReadPtr - currentReadPtr + FILESIZE) % FILESIZE;

                for (int i = 0; i < diff; i++)
                {
                    Grid_V.ReadPointerAdd();
                }
           // } // ← ここですぐにロックを解放！計算スレッドを止めない

            // ==========================================================
            // ② 重い描画処理（Graphics）は「ロックの外」で安全に行う
            // ==========================================================
            using (Graphics g = Graphics.FromImage(_displayCanvas))
            {
                // 背景の格子を描画（画面全体をクリア）
                g.DrawImage(canvas_base, 0, 0);

                using (SolidBrush b = new SolidBrush(Color.FromArgb(255, 0, 0, 0)))
                {
                    double[] yArray_Range = new double[4];
                    yArray_Range[0] = (1.0 / double.Parse(this.cbCh1Yrange.Text));
                    yArray_Range[1] = (1.0 / double.Parse(this.cbCh2Yrange.Text));
                    yArray_Range[2] = (1.0 / double.Parse(this.cbCh3Yrange.Text));
                    yArray_Range[3] = (1.0 / double.Parse(this.cbCh4Yrange.Text));
                    // ★ 0ポイントとする画面上のY座標を定義（例：上から200ピクセルの位置を基準にする場合） 
                    //int zeroPointY = 200;
                    // ※もし「下から200ピクセル」を基準にしたい場合は以下のようにします
                     int zeroPointY = iYmax - 200;
                    for (int i = 0; i < drawCount; i++)
                    {
                        int y1 = (int)(localY1[i] * yArray_Range[0]);
                        int y2 = (int)(localY2[i] * yArray_Range[1]);
                        int y3 = (int)(localY3[i] * yArray_Range[2]);
                        int y4 = (int)(localY4[i] * yArray_Range[3]);

                        int x_zahyou = i;
                        if (x_zahyou >= width) break;

                        // ch1 (Green - 緑)
                        b.Color = Color.FromArgb(0, 255, 0);
                        g.FillRectangle(b, x_zahyou, zeroPointY - y1, 1, 1);

                        // ch2 (Orange - オレンジ)
                        b.Color = Color.FromArgb(255, 128, 0);
                        g.FillRectangle(b, x_zahyou, zeroPointY - y2, 1, 1);

                        // ch3 (Cyan - シアン)
                        b.Color = Color.FromArgb(0, 192, 192);
                        g.FillRectangle(b, x_zahyou, zeroPointY - y3, 1, 1);

                        // ch4 (Yellow - 黄色)
                        //b.Color = Color.FromArgb(255, 255, 128);
                        b.Color = Color.FromArgb(255, 0, 0);
                        g.FillRectangle(b, x_zahyou, zeroPointY - y4, 1, 1);
                    }
                }
            }

            // 3. PictureBoxに再描画を促す
            pictureBox1.Image = _displayCanvas;
            pictureBox1.Refresh();
        }

        #endregion ■タイマー管理





        //**************************************************************************
        //【処 理 名】ThreadProc
        //【処理内容】サイン波を生成してリングバッファへ定期書き込みを行うバックグラウンドスレッド
        //**************************************************************************
        private void ThreadProc(CancellationToken token)
        {
           
        }

        //=============================================================
        // ArrayBuffer クラス定義（リングバッファ管理）
        //=============================================================
        class ArrayBuffer
        {

            // メンバー変数の定義
            private int dReadPointer = FILESIZE - 1;
            private int dWritePointer = FILESIZE - 1;
            double[] dArray1 = new double[FILESIZE];
            double[] dArray2 = new double[FILESIZE];
            double[] dArray3 = new double[FILESIZE];
            double[] dArray4 = new double[FILESIZE];
            // メソッドの定義

            public bool WriteCheck()
            {
                if (((dWritePointer + 1) % FILESIZE) != dReadPointer)
                {
                    return true;
                }
                else
                {

                    return false;
                }

            }

            public void Write(double x1, double x2, double x3, double x4)
            {
                if (((dWritePointer + 1) % FILESIZE) != dReadPointer)
                {
                    dArray1[dWritePointer] = x1;
                    dArray2[dWritePointer] = x2;
                    dArray3[dWritePointer] = x3;
                    dArray4[dWritePointer] = x4;
                    dWritePointer = (dWritePointer + 1) % FILESIZE;

                }
            }
            public double Read1(int i)
            {
                return dArray1[i];
            }
            public double Read2(int i)
            {
                return dArray2[i];
            }
            public double Read3(int i)
            {
                return dArray3[i];
            }
            public double Read4(int i)
            {
                return dArray4[i];
            }
            public void ReadPointerAdd()
            {

                if (((dReadPointer + 1) % FILESIZE) != dWritePointer)
                {
                    dReadPointer = (dReadPointer + 1) % FILESIZE;
                }
            }
            public int GetReadPointer()
            {
                return dReadPointer;
            }
            public int GetWritePointer()
            {
                return dWritePointer;
            }

            public void ClearReadPointer()
            {
                dReadPointer = 0;
            }
            public void ClearWritePointer()
            {
                dWritePointer = 0;
            }
            public void CleaBuffer()
            {
                for (int i = 0; i < FILESIZE; i++)
                {
                    dArray1[i] = 0;
                    dArray2[i] = 0;
                    dArray3[i] = 0;
                    dArray4[i] = 0;

                }
                ClearReadPointer();
                ClearWritePointer();
            }
            // バッファが満杯（読み込みに追いつきそう）かどうかを判定する例
            public bool IsBufferOverflowSoon()
            {
                int nextWrite = (dWritePointer + 1) % FILESIZE;
                return (nextWrite == dReadPointer);
            }


        }
    }
}
