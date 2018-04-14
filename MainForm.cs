using System;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using Midi;

namespace KeypadHostMIDI
{
    public partial class MainForm : Form
    {

        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        public const int KEYEVENTF_EXTENDEDKEY = 0x0001;
        public const int KEYEVENTF_KEYUP = 0x0002;

        SerializableDictionary<string, byte> mappingData;
        InputDevice inputDevice;
        Stack<byte> tmpKey;

        public MainForm()
        {
            InitializeComponent();

            mappingData = new SerializableDictionary<string, byte>();
            inputDevice = null;
            tmpKey = new Stack<byte>();
        }

        private const string _path = "config.xml";

        private void MainForm_Load(object sender, EventArgs e)
        {
            btnMidi_Click(null, null);
            btnSerial_Click(null, null);

            if (!File.Exists(_path)) return;

            try
            {
                FileStream stream = new FileStream(_path, FileMode.Open);
                XmlSerializer serializer = new XmlSerializer(mappingData.GetType());
                mappingData = (SerializableDictionary<string, byte>)serializer.Deserialize(stream);
                stream.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mappingData = new SerializableDictionary<string, byte>();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mappingData.Count == 0) return;

            try
            {
                FileStream stream = new FileStream(_path, FileMode.OpenOrCreate);
                XmlSerializer serializer = new XmlSerializer(mappingData.GetType());
                serializer.Serialize(stream, mappingData);
                stream.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Save error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void boxKey_KeyDown(object sender, KeyEventArgs e)
        {
            if (boxKey.Focused)
            {
                Keys key = e.KeyCode;

                if (modeBox.Checked)
                {
                    switch (key)
                    {
                        case Keys.Space: tmpKey.Push(0x20); break;
                        case Keys.Up: tmpKey.Push(0xDA); break;
                        case Keys.Down: tmpKey.Push(0xD9); break;
                        case Keys.Left: tmpKey.Push(0xD8); break;
                        case Keys.Right: tmpKey.Push(0xD7); break;
                        case Keys.Escape: tmpKey.Push(0xB1); break;
                        default: tmpKey.Push((byte)((byte)key & 0x7F)); break;
                    }
                }
                else
                {
                    tmpKey.Push((byte)key);
                }

                boxKey.Clear();
                boxKey.AppendText(key.ToString());
            }
        }

        public void noteOnHandler(NoteOnMessage msg)
        {
            string note = msg.Pitch.ToString();

            try
            {
                if (modeBox.Checked)
                {
                    if (port.IsOpen && mappingData.ContainsKey(note))
                        port.Write(new byte[] { 0xFF, mappingData[note] }, 0, 2);
                }
                else
                {
                    if (mappingData.ContainsKey(note))
                        keybd_event(mappingData[note], 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Serial error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            boxNote.Invoke(new MethodInvoker(() => {
                if (boxNote.Focused)
                {
                    boxNote.Clear();
                    boxNote.AppendText(note);
                }
            }));
        }

        public void noteOffHandler(NoteOffMessage msg)
        {
            string note = msg.Pitch.ToString();

            try
            {
                if (modeBox.Checked)
                {
                    if (port.IsOpen && mappingData.ContainsKey(note))
                        port.Write(new byte[] { 0x00, mappingData[note] }, 0, 2);
                }
                else
                {
                    if (mappingData.ContainsKey(note))
                        keybd_event(mappingData[note], 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Serial error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string note = boxNote.Text;

            if (note.Length == 0 || tmpKey.Count == 0) return;

            if (mappingData.ContainsKey(note))
                mappingData.Remove(note);

            mappingData.Add(note, tmpKey.Pop());

            boxNote.Clear();
            boxKey.Clear();
            tmpKey.Clear();
        }

        public void doConnect()
        {
            int midi = boxMidi.SelectedIndex;
            int serial = boxSerial.SelectedIndex;

            if (midi < 0 || (serial < 0 && modeBox.Checked)) return;

            inputDevice = InputDevice.InstalledDevices[midi];
            if (inputDevice.IsOpen) inputDevice.Close();
            inputDevice.Open();
            inputDevice.NoteOn += new InputDevice.NoteOnHandler(noteOnHandler);
            inputDevice.NoteOff += new InputDevice.NoteOffHandler(noteOffHandler);
            inputDevice.StartReceiving(null);

            if (modeBox.Checked)
            {
                port.PortName = SerialPort.GetPortNames()[serial];
                if (port.IsOpen) port.Close();
                port.Open();
            }

            btnConnect.Text = "Disconnect";
            showState.Checked = true;
            modeBox.Enabled = false;
        }

        public void doDisconnect()
        {
            if (inputDevice != null)
            {
                inputDevice.StopReceiving();
                if (inputDevice.IsOpen) inputDevice.Close();
            }

            if (modeBox.Checked)
            {
                if (port.IsOpen) port.Close();
            }

            btnConnect.Text = "Connect";
            showState.Checked = false;
            modeBox.Enabled = true;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (!showState.Checked)
                doConnect();
            else
                doDisconnect();
        }

        private void btnMidi_Click(object sender, EventArgs e)
        {
            boxMidi.Items.Clear();
            foreach (InputDevice i in InputDevice.InstalledDevices)
                boxMidi.Items.Add(i.Name);
        }

        private void btnSerial_Click(object sender, EventArgs e)
        {
            boxSerial.Items.Clear();
            foreach (string i in SerialPort.GetPortNames())
                boxSerial.Items.Add(i);
        }

        private void modeBox_CheckedChanged(object sender, EventArgs e)
        {
            if (modeBox.Checked)
            {
                boxSerial.Enabled = true;
                btnSerial.Enabled = true;
            }
            else
            {
                boxSerial.Enabled = false;
                btnSerial.Enabled = false;
            }
        }
    }
}
