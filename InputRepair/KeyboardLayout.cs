using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;


namespace InputRepair {
    public class KeyboardLayout {
        [DllImport("user32")]
        private static extern int UnloadKeyboardLayout(int handle);

        private const string REGPATH_KEYBOARD_LAYOUT_NAME = "HKEY_LOCAL_MACHINE\\System\\CurrentControlSet\\Control\\keyboard layouts\\";
        private const string REGVAL_KEYBOARD_LAYOUT_NAME = "Layout Text";

        private bool p_updated = false; // Reserved

        private uint p_handle = 0;
        private uint p_id = 0;
        private string p_name = "";

        private uint Handle2Reg(uint handle) { return ((handle >> 16 ^ handle & 0x0000ffff) == 0) ? handle & 0x0000ffff : handle; }

        private string GetNameFromId(uint id) { return id==0?"":Registry.GetValue(REGPATH_KEYBOARD_LAYOUT_NAME + p_id.ToString("X8"), REGVAL_KEYBOARD_LAYOUT_NAME, "").ToString(); }

        public KeyboardLayout(uint _handle = 0) { Handle = _handle; }

        public bool Unload() {
            bool result = UnloadKeyboardLayout((int)Handle) != 0;
            if (result) Handle = 0;
            return result;
        }

        public uint Handle {
            get {
                return p_handle;
            }
            set {
                p_handle = value;
                p_id = Handle2Reg(value);
                p_name = GetNameFromId(p_id);
                p_updated = p_handle != 0;
            }
        }

        public uint Id {
            get {
                return p_id;
            }
            private set {
                p_id = value;
            }
        }

        public string Name {
            get {
                return p_name;
            }
            private set {
                p_name = value;
            }
        }
    }
}
