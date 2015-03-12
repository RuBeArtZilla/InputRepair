using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace InputRepair {
    public partial class MainForm : Form {

        KeyboardLayoutList klCurrent = new KeyboardLayoutList();
        KeyboardLayoutList klLoaded = new KeyboardLayoutList();

        public void UpdateCheckedListBoxCurrent() {
            klCurrent.LoadCurrent();
            cbLayoutList.Items.Clear();
            foreach (KeyboardLayout kl in klCurrent) {
                if (kl.Name.Length != 0) cbLayoutList.Items.Add(kl.Name, false);
            }
        }

        public void UpdateCheckedListBoxLoaded() {
            klLoaded.LoadXML(true);
            cbLoadedLayout.Items.Clear();
            foreach (KeyboardLayout kl in klLoaded) {
                if (kl.Name.Length != 0) cbLoadedLayout.Items.Add(kl.Name, false);
            }
        }

        public void RepairCurrentLayoutList() {
            klCurrent.LoadCurrent();

            foreach (KeyboardLayout klc in klCurrent) {
                bool unload = true;
                foreach (KeyboardLayout kll in klLoaded) {
                    if (klc.Handle == kll.Handle)
                        unload = false;
                }
                if (unload)
                    klc.Unload();
            }
        }

        public void EnableServerMode(bool enable = true) {
            Visible = !enable;
            ShowInTaskbar = !enable;
            if (enable) cbActivateAutoDel.Checked = true;
        }

        public MainForm() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            UpdateCheckedListBoxCurrent();
            UpdateCheckedListBoxLoaded();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            if (Properties.Settings.Default.CheckInterval > 1000)
                timerCheck.Interval = Properties.Settings.Default.CheckInterval;
            timerCheck.Enabled = Properties.Settings.Default.CheckKLL;

            klCurrent.LoadCurrent();
            klLoaded.LoadXML(true);

            String[] arguments = Environment.GetCommandLineArgs();

            foreach (string item in arguments) {
                if (item.Equals(Properties.Settings.Default.ServerMode))
                    EnableServerMode(true);
            }

            UpdateCheckedListBoxCurrent();
            UpdateCheckedListBoxLoaded();
        }

        private void btnDeleteSelected_Click(object sender, EventArgs e) {
            foreach (object itemChecked in cbLayoutList.CheckedItems) {
                foreach (KeyboardLayout kl in klCurrent) {
                    if (kl.Name.Equals(itemChecked.ToString()))
                        kl.Unload();
                }
            }

            UpdateCheckedListBoxCurrent();
            UpdateCheckedListBoxLoaded();
        }

        private void btnSaveToXML_Click(object sender, EventArgs e) {
            KeyboardLayoutList klList = new KeyboardLayoutList();
            foreach (object item in cbLayoutList.CheckedItems) {
                foreach (KeyboardLayout kl in klCurrent) {
                    if (kl.Name.Equals(item.ToString()))
                        klList.Add(kl);
                }
            }
            klLoaded = klList;
            klLoaded.SaveXML(true);

            UpdateCheckedListBoxLoaded();
        }

        private void cbActivateAutoDel_CheckedChanged(object sender, EventArgs e) {
            timerCheck.Enabled = cbActivateAutoDel.Checked;
            Properties.Settings.Default.CheckKLL = cbActivateAutoDel.Checked;
            Properties.Settings.Default.Save();
        }

        private void timerCheck_Tick(object sender, EventArgs e) {
            RepairCurrentLayoutList();

            UpdateCheckedListBoxCurrent();
            UpdateCheckedListBoxLoaded();
        }
    }
}
