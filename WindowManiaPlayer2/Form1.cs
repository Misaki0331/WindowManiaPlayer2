using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using NAudio.Wave;
using WindowManiaPlayer.Model;
using NVorbis;

namespace WindowManiaPlayer
{
    public partial class Form1 : Form
    {
        const int windowcount = 2147483647;
        List<Notes> notewindow = new();
        List<NoteObject> notesObjects = new(); 
        List<TimingObject> timingObjects = new(); 
        WaveOutEvent outputDevice = new WaveOutEvent();
        AudioFileReader? afr;
        bool UsingOGG = false;
        NAudio.Vorbis.VorbisWaveReader? afr2;
        //WindowsMediaPlayer _mediaPlayer = new WindowsMediaPlayer();

        string SoundFile = "";
        int counts = 0;
        private void StopSound()
        {
            outputDevice.Stop();
        }

        private void PlaySound(int time)
        {
            try
            {
                afr = new(SoundFullPath);
                afr.CurrentTime = new((long)time*10000);
                outputDevice.Init(afr);
                UsingOGG = false;
            }
            catch
            {
                try
                {
                    afr2 = new NAudio.Vorbis.VorbisWaveReader(SoundFullPath);
                    outputDevice.Init(afr2);
                    UsingOGG = true;
                }
                catch
                {
                    throw;
                }
            }
            outputDevice.Play();
        }
        private int position
        {
            get
            {
                if (UsingOGG) return (int)afr2.CurrentTime.TotalMilliseconds;
                else return (int)afr.CurrentTime.TotalMilliseconds;
            }
            set
            {
                if (UsingOGG) afr2.CurrentTime = new((long)value * 10000);
                else afr.CurrentTime = new((long)value*10000);
            }
        }
        public Form1()
        {
            InitializeComponent();
        }
        int endtime=0;

        string SoundFullPath = "";
        DebugWindow dw = new();
        void load()
        {
            notesObjects.Clear();
            timingObjects.Clear();
            endtime = 0;
            StreamReader sr = new StreamReader(
                textBox1.Text, Encoding.UTF8);

            string text = sr.ReadToEnd();

            sr.Close();
            string[] strs = text.Split('\n');
            int hitobjectstart = 0;
            int timingobjectstart = 0;

            for (int i = 0; i < strs.Length; i++)
            {
                if (strs[i].Contains("[HitObjects]"))
                {
                    hitobjectstart = i + 1;
                    break;

                }
                if (strs[i].Contains("[TimingPoints]"))
                {
                    timingobjectstart = i + 1;

                }
                if (strs[i].StartsWith("AudioFilename"))
                {
                    SoundFile = strs[i];
                    while (!SoundFile.StartsWith(":"))
                    {
                        SoundFile = SoundFile.Remove(0, 1);
                    }
                    SoundFile = SoundFile.Remove(0, 1);
                    SoundFile = SoundFile.TrimStart();
                    SoundFile = SoundFile.TrimEnd();
                }
            }
            for (int count = timingobjectstart; count < hitobjectstart - 1; count++)
            {
                try
                {
                    var data = new Model.TimingObject();
                    string[] lens = strs[count].Split(',');
                    data.Time = (int)double.Parse(lens[0]);
                    data.Value = double.Parse(lens[1]);
                    data.IsBPM = lens[6] == "1";
                    if (!data.IsBPM) data.Value = -100/data.Value;
                    timingObjects.Add(data);
                }
                catch(Exception ex) {

                    Trace.WriteLine(ex);
                }
            }
            for (int count = hitobjectstart; count < strs.Length; count++)
            {
                var data = new Model.NoteObject();
                string[] lens = strs[count].Split(',');
                string[] detaillens;
                try
                {
                    detaillens = lens[5].Split(':');
                }
                catch
                {
                    continue;
                }
                data.Position = int.Parse(lens[0]);

                data.Time = (int)double.Parse(lens[2]);
                if (int.Parse(lens[3]) == 128) data.LongNote = int.Parse(detaillens[0]) - data.Time;
                if (endtime < data.Time + data.LongNote) endtime = data.Time + data.LongNote;
                if (data.LongNote < 0)
                {
                    data.Time -= data.LongNote; 
                    data.LongNote = 0;
                }
                notesObjects.Add(data);
                counts = count;
            }
            if (hitobjectstart == 0) throw new ArgumentException(paramName: nameof(hitobjectstart),
                message: "ファイル内に\"[HitObjects]\"が存在しませんでした。");
            notesObjects.Sort((a, b) => a.Time - b.Time);
            timingObjects.Sort((a, b) => a.Time - b.Time);
            double x = 1;
            double defbpm = 0;
            double bpm = 0;
            var def = timingObjects.Find(a => a.IsBPM);
            if (def == null) throw new ArgumentException(paramName: nameof(def), message: "BPM設置されてません。");
            defbpm = def.Value;
            bpm = defbpm;
            int offset = 0;
            double scrolloffset = 0;
            double userspeed = (double)numericUpDown3.Value;
            for (int i = 0; i < timingObjects.Count; i++)
            {
                double speed = x * (defbpm / bpm);
                if (speed > 10000) speed = 10000;
                else if (speed < -10000) speed = -10000;
                double move = (timingObjects[i].Time - offset) * speed * userspeed;
                if (timingObjects[i].IsBPM)
                    bpm = timingObjects[i].Value;
                else x = timingObjects[i].Value;
                speed = x * (defbpm / bpm);
                offset = (int)timingObjects[i].Time;
                scrolloffset += move;
                timingObjects[i].ScrollPosition = scrolloffset;
                timingObjects[i].ScrollSpeed = speed * userspeed;
            }
            int toff = 0;
            offset = 0;
            scrolloffset = 0;
            double scrollspeed = 1;
            for (int i = 0; i < notesObjects.Count; i++)
            {
                while (toff < timingObjects.Count && timingObjects[toff].Time <= notesObjects[i].Time)
                {
                    offset = (int)timingObjects[toff].Time;
                    scrolloffset =timingObjects[toff].ScrollPosition;
                    scrollspeed = timingObjects[toff].ScrollSpeed;
                    toff++;
                }
                notesObjects[i].ScrollTime = ((double)scrolloffset + (notesObjects[i].Time - offset) * scrollspeed);
                int t2off = toff;
                int offset2 = offset;
                double scrolloffset2 = scrolloffset;
                double scrollspeed2 = scrollspeed;
                while (t2off < timingObjects.Count && timingObjects[t2off].Time <= notesObjects[i].Time + notesObjects[i].LongNote)
                {
                    offset2 = (int)timingObjects[t2off].Time;
                    scrolloffset2 = timingObjects[t2off].ScrollPosition;
                    scrollspeed2 = timingObjects[t2off].ScrollSpeed;
                    t2off++;
                }
                notesObjects[i].LongScrollTime = ((double)scrolloffset2 + (notesObjects[i].Time + notesObjects[i].LongNote - offset2) * scrollspeed2) - notesObjects[i].ScrollTime;
            }

            notesObjects.Sort((a, b) => Math.Sign(a.ScrollTime - b.ScrollTime));
        }
        private void playerplay_Click(object sender, EventArgs e)
        {
            try
            {
                StopSound();
            }
            catch{}
            load();
            int faster = 0;
            for (int i = 0; i < notesObjects.Count; i++)
            {
                int cnt = notesObjects.FindAll(a => a.ScrollTime - notesObjects[i].ScrollTime < 500 && a.ScrollTime - notesObjects[i].ScrollTime > -500).Count;
                if (cnt > faster) faster = cnt;
            }
            if (faster > 100)
            {
                if(MessageBox.Show($"この譜面は描画処理が極端重くなる可能性があります。\nスクロール速度1秒に表示される想定数は {faster} 個です。\nそれでも実行しますか？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    return;
                }
            }
            var screen = System.Windows.Forms.Screen.PrimaryScreen;
            int width = screen.Bounds.Width;
            int height = screen.Bounds.Height;
            if (textBox1.Text == string.Empty) return;
            SoundFullPath = $"{Path.GetDirectoryName(textBox1.Text)}\\{SoundFile}";
            bool isdebug = IsDebugMode.Checked;
            if (isdebug)
            {
                dw.WantClose = false;
                dw.Show();
                dw.Location = new Point(10, 10);
            }
            Hide();
            Stopwatch timer = new Stopwatch();
            int lps = 0;
            int[] tmplp = new int[50] ;
            int[] tmplpt = new int[50];
            int notecount = 0;
            bool started = false;
            int tempsec = 0;
            int shortsize = (int)numericUpDown2.Value;
            int notecounts = 0;

            timer.Reset();
            timer.Start();

            int offset = 0;
            double scrolloffset = 0;
            double scrollspeed = 1;
            int toff = 0;
            double bpm = 0;
            while (timer.ElapsedMilliseconds - 3000 < endtime || notewindow.Find(a => a.NoteNumber != -1) != null)
            {
                if(isdebug)tmplp[timer.ElapsedMilliseconds / 20 % 50]++;
                int now = (int)timer.ElapsedMilliseconds - 3000;
                if (!started && now > numericUpDown1.Value)
                {
                    PlaySound(now);
                    started = true;
                }
                while (toff < timingObjects.Count && timingObjects[toff].Time <= now)
                {
                    offset = (int)timingObjects[toff].Time;
                    scrolloffset = timingObjects[toff].ScrollPosition;
                    scrollspeed = timingObjects[toff].ScrollSpeed;
                    if (timingObjects[toff].IsBPM) bpm = timingObjects[toff].Value;
                    toff++;
                }
                double scrollTime = ((double)scrolloffset + (now - offset) * scrollspeed);
                Application.DoEvents();
                try
                {
                    int notewillshow = 0;
                    if (notecount < notesObjects.Count) while (notesObjects[notecount].ScrollTime - scrollTime < height / 2)
                        {
                            if (notesObjects[notecount].Time + notesObjects[notecount].LongNote >= now)
                            {
                                var empty = notewindow.Find(a => a.NoteNumber == -1 || a.WillHide);
                                bool isEmpty = false;
                                if (notewindow.Count < windowcount)
                                {
                                    if (empty == null && notewindow.Count < windowcount)
                                    {
                                        empty = new();
                                        isEmpty = true;
                                    }
                                    if (empty != null)
                                    {
                                        empty.WillHide = false;
                                        empty.Show();
                                        empty.NoteNumber = notecount;
                                        empty.Location = new Point((width - 512) / 2 + notesObjects[notecount].Position * 2 - 75, -10000);
                                        empty.Opacity = 1;
                                        if (notesObjects[notecount].LongScrollTime != 0)
                                            empty.ClientSize = new(150, (int)((double)notesObjects[notecount].LongScrollTime * 2 + shortsize));
                                        else empty.ClientSize = new(150, shortsize);
                                        if (isEmpty) notewindow.Add(empty);
                                    }

                                }
                                notewillshow++;
                            }
                            notecount++;
                            if (notewillshow > 10) break;
                        }
                }
                catch
                {

                }
                foreach (var win in notewindow)
                {
                    if (win.NoteNumber != -1)
                    {
                        if (notesObjects[win.NoteNumber].LongScrollTime == 0||win.WillHide)
                        {
                            if (notesObjects[win.NoteNumber].Time - now < 0)
                            {
                                if (!win.WillHide) notecounts++;
                                win.WillHide = true;
                            }
                                win.Location = new Point(((width - 512*2) / 2 + notesObjects[win.NoteNumber].Position * 2 - 75),(int)(height - (notesObjects[win.NoteNumber].ScrollTime - scrollTime) * 2 - shortsize));
                        }
                        else
                        {
                            if (notesObjects[win.NoteNumber].Time + notesObjects[win.NoteNumber].LongNote - now < 0)
                            {
                                if(!win.WillHide) notecounts++;
                                win.WillHide = true;
                            }
                            if (notesObjects[win.NoteNumber].LongScrollTime >= (height - shortsize) / 2)
                            {
                                if (scrollTime >= notesObjects[win.NoteNumber].ScrollTime && scrollTime < notesObjects[win.NoteNumber].ScrollTime + notesObjects[win.NoteNumber].LongScrollTime - (height - shortsize) / 2)
                                {
                                    win.Location = new Point((width - 512 * 2) / 2 + notesObjects[win.NoteNumber].Position * 2 - 75, 0);
                                }
                                else
                                {
                                    int x = (width - 512 * 2) / 2 + notesObjects[win.NoteNumber].Position * 2 - 75;
                                    if (scrollTime > notesObjects[win.NoteNumber].ScrollTime)
                                    {
                                        int y = (int)(height - (notesObjects[win.NoteNumber].ScrollTime + notesObjects[win.NoteNumber].LongScrollTime - scrollTime) * 2 - shortsize);
                                        if (win.Location.X != x || (win.Location.Y >= -height && win.Location.Y <= height) || (y >= -height && y <= height)) win.Location = new Point(x, y);
                                    }
                                    else
                                    {
                                        int y = (int)(height - (notesObjects[win.NoteNumber].ScrollTime + (height - shortsize) / 2 - scrollTime) * 2 - 50);
                                        if (win.Location.X != x || (win.Location.Y >= -height && win.Location.Y <= height) || (y >= -height && y <= height)) win.Location = new Point(x, y);
                                    }
                                }

                            }
                            else
                            {
                                int x = (width - 512 * 2) / 2 + notesObjects[win.NoteNumber].Position * 2 - 75;
                                int y = (int)(height - (notesObjects[win.NoteNumber].ScrollTime + notesObjects[win.NoteNumber].LongScrollTime - scrollTime) * 2 - shortsize);
                                if (win.Location.X != x || (win.Location.Y >= -height && win.Location.Y <= height) || (y >= -height && y <= height)) win.Location = new Point(x, y);
                            }
                            
                        }
                    }
                }
                int t = 0;
                if (isdebug)
                {
                    lps = 0;
                    for (int i = 0; i < 50; i++)
                    {
                        if (tmplpt[i] != (timer.ElapsedMilliseconds - i * 20) / 1000)
                        {
                            tmplp[i] = 0;
                            tmplpt[i] = (int)(timer.ElapsedMilliseconds - i * 20) / 1000;
                        }
                        else
                        {
                            lps += tmplp[i];
                        }
                    }
                    t = (int)timer.ElapsedMilliseconds - tempsec;
                    dw.displaytext.Text = $"Window : {notewindow.FindAll(a=>a.NoteNumber!=-1).Count:000}/{notewindow.Count:000}\n" +
                        $"FPS : {lps:#,##0}\n" +
                        $"Update : {t:#,##0}\n" +
                        $"{now / 1000 / 60}:{(now / 1000 % 60).ToString().PadLeft(2, '0')}/{endtime/1000/60}:{(endtime/1000%60).ToString().PadLeft(2,'0')}\n" +
                        $"{notecounts}/{notesObjects.Count}\n" +
                        $"{scrollTime:#,##0}\n" +
                        $"x{scrollspeed:0.000}\n" +
                        $"BPM:{(60000.0/bpm):#,##0}";
                    tempsec = (int)timer.ElapsedMilliseconds;
                }
                for (int i = 0; i < notewindow.FindAll(a => a.WillHide).Count/5+1; i++)
                {
                    var h = notewindow.Find(a => a.WillHide);
                    if (h != null)
                    {
                        h.WillHide = false;
                        h.NoteNumber = -1;
                        h.ClientSize = new(150, shortsize);
                        h.Hide();
                    }
                    else break;
                }
                int cnt = 0;
                if (notewindow.Count > 100) foreach (var empty in notewindow.FindAll(a => a.NoteNumber == -1))
                {
                    empty.Release();
                    notewindow.Remove(empty);
                    cnt++;
                    if (cnt >= 3) break;
                    }
                if (dw.WantClose)
                {
                    StopSound();
                    break;
                }
            }
            foreach(var win in notewindow)
            {
                win.Release();
            }
            notewindow.Clear();
            Show();
            if (IsDebugMode.Checked)
            {
                dw.Hide();
            }
        }
        private void beatmap_Click(object sender, EventArgs e)
        {
            filedialog.Filter = "譜面ファイル (*.osu)|*.osu";
            filedialog.ShowDialog();
           
        }

        private void link_github_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                UseShellExecute = true,
                FileName = "https://misaki-chan.world/",
            });
        }

        private void link_twitter_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                UseShellExecute = true,
                FileName = "https://misskey.io/@ms",
            });

        }

        private void link_repository_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                UseShellExecute = true,
                FileName = "https://github.com/Misaki0331/WindowManiaPlayer2",
            });
        }

        private void filedialog_FileOk(object sender, CancelEventArgs e)
        {
            textBox1.Text = filedialog.FileName;

        }
    }
}
