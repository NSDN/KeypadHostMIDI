using System;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Collections.Generic;

using Midi;

namespace KeypadHostMIDI
{
    public partial class MainForm : Form
    {
        SerializableDictionary<string, char> mappingData;
        InputDevice inputDevice;

        public MainForm()
        {
            InitializeComponent();

            mappingData = new SerializableDictionary<string, char>();
            inputDevice = null;
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
                mappingData = (SerializableDictionary<string, char>)serializer.Deserialize(stream);
                stream.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mappingData = new SerializableDictionary<string, char>();
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
                boxKey.Clear();
                boxKey.AppendText(e.KeyCode.ToString());
            }
        }

        public void noteOnHandler(NoteOnMessage msg)
        {
            string note = msg.Pitch.ToString();

            if (port.IsOpen && mappingData.ContainsKey(note))
                port.Write(new char[] { mappingData[note] }, 0, 1);

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

            if (port.IsOpen && mappingData.ContainsKey(note))
                port.Write(new byte[] { (byte) (mappingData[note] & 0x80) }, 0, 1);
        }

        public void doConnect()
        {
            int midi = boxMidi.SelectedIndex;
            int serial = boxSerial.SelectedIndex;

            if (midi < 0 || serial < 0) return;

            inputDevice = InputDevice.InstalledDevices[midi];
            if (inputDevice.IsOpen) inputDevice.Close();
            inputDevice.Open();
            inputDevice.NoteOn += new InputDevice.NoteOnHandler(noteOnHandler);
            inputDevice.NoteOff += new InputDevice.NoteOffHandler(noteOffHandler);
            inputDevice.StartReceiving(null);

            port.PortName = SerialPort.GetPortNames()[serial];
            if (port.IsOpen) port.Close();
            port.Open();

            btnConnect.Text = "Disconnect";
            showState.Checked = true;
        }

        public void doDisconnect()
        {
            if (inputDevice != null)
            {
                inputDevice.StopReceiving();
                if (inputDevice.IsOpen) inputDevice.Close();
            }

            if (port.IsOpen) port.Close();

            btnConnect.Text = "Connect";
            showState.Checked = false;
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string note = boxNote.Text;
            string key = boxKey.Text;

            if (note.Length == 0 || key.Length == 0) return;

            if (mappingData.ContainsKey(note))
                mappingData.Remove(note);

            mappingData.Add(note, key.ToCharArray()[0]);

            boxNote.Clear();
            boxKey.Clear();
        }
        
    }
}
