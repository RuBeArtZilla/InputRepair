using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace InputRepair {
    public class HandleList : List<uint> { }

    public class KeyboardLayoutList : List<KeyboardLayout> {
        public const string DEFAULT_SAVE_FILE = "config.xml";

        [DllImport("user32.dll")]
        static extern uint GetKeyboardLayoutList(int nBuff, [Out] IntPtr[] lpList);


        public static KeyboardLayoutList GetCurrentLayoutList() { return new KeyboardLayoutList().LoadCurrent(); }
        public static KeyboardLayoutList CreateKyeboardLayoutList(HandleList hl, bool ignoreZero = false) { return new KeyboardLayoutList().LoadFromHandleList(hl, ignoreZero); }
        public static KeyboardLayoutList CreateKeyboardLayoutList(string filename = DEFAULT_SAVE_FILE, bool ignoreZero = false) { return new KeyboardLayoutList().LoadXML(filename, ignoreZero); }

        public bool SaveXML(string filename = DEFAULT_SAVE_FILE, bool ignoreZero = false) {
            try {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(HandleList));
                using (FileStream fs = new FileStream(filename, FileMode.Create)) {
                    xmlSerializer.Serialize(fs, GetHandleList(ignoreZero));
                }
            }
            catch (Exception) {
                return false;
            }
            return true;
        }
        public bool SaveXML(bool ignoreZero = false) { return SaveXML(DEFAULT_SAVE_FILE, ignoreZero); }

        public KeyboardLayoutList LoadCurrent() {
            Clear();
            uint nElements = GetKeyboardLayoutList(0, null);
            IntPtr[] ids = new IntPtr[nElements];
            GetKeyboardLayoutList(ids.Length, ids);
            foreach (uint handle in ids) {
                Add(new KeyboardLayout(handle));
            }
            return this;
        }

        public KeyboardLayoutList LoadXML(string filename = DEFAULT_SAVE_FILE, bool ignoreZero = false) {
            HandleList hl = new HandleList();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(HandleList));
            using (FileStream fs = new FileStream(filename, FileMode.Open)) {
                hl = (HandleList) xmlSerializer.Deserialize(fs);
            }
            LoadFromHandleList(hl, ignoreZero);
            return this;
        }

        public KeyboardLayoutList LoadXML(bool ignoreZero = false) { return LoadXML(DEFAULT_SAVE_FILE, ignoreZero); }

        public KeyboardLayoutList LoadFromHandleList(HandleList hl, bool ignoreZero = false) {
            Clear();
            foreach (uint handle in hl) {
                if (!ignoreZero || handle != 0)
                    Add(new KeyboardLayout(handle));
            }
            return this;
        }

        public HandleList GetHandleList(bool ignoreZero = false) {
            HandleList result = new HandleList();
            foreach (KeyboardLayout kl in this) {
                if (!ignoreZero || kl.Handle != 0)
                    result.Add(kl.Handle);
            }
            return result;
        }


    }
}
