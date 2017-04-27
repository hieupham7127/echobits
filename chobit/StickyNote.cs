using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Xml;

namespace eChobits {
    public class StickyNote {

        public static List<StickyNoteForm> list;
        Logging file;

        public StickyNote() {   
            file = new Logging(Logging.NOTE_LOG);
        }
     
        /*
        StickyNoteInfo class to save data from StickyNoteForm
        Window Forms class is not serializable, data binding is necessary
        Requirements for Serialization:
        1. Must declare parameterless constructor
        2. Must declare as public classES
        3. Aware of non-serializable objects: Color, Windows Forms, etc.
        */
        public class StickyNoteInfo {
            public Point location;
            public Size size;
            public int color;
            public String content;

            public StickyNoteInfo() { }

            public StickyNoteInfo(Point location, Size size, Color color, String content) {
                this.location = location;
                this.size = size;
                this.color = color.ToArgb();
                this.content = content;
            }
            /*
            No need to set private varible
            public Point GetLocation() { return this.location; }
            public Size GetSize() { return this.size; }
            public Color GetColor() { return this.color; }
            public String GetContent() { return this.content; }
            */
        }


        private void Fetch() {
            list = new List<StickyNoteForm>();
            try {
                List<StickyNoteInfo> infos = Serialization.Deserialize<List<StickyNoteInfo>>(StickyNoteForm.PATH);
                if (infos != null)
                    foreach (StickyNoteInfo info in infos) {
                        StickyNoteForm note = new StickyNoteForm(info.location, info.size, Color.FromArgb(info.color), info.content);
                        list.Add(note);
                    }
            }
            finally {
                if (list.Capacity == 0) {
                    StickyNoteForm note = new StickyNoteForm();
                    list.Add(note);
                }
            }
        }

        public void Save() {
            List<StickyNoteInfo> info = new List<StickyNoteInfo>();
            if (list == null) return;
            foreach (StickyNoteForm note in list)
                info.Add(new StickyNoteInfo(note.Location, note.Size, note.GetBackColor(), note.GetContent()));
            try {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(Serialization.Serialize<List<StickyNoteInfo>>(info));
                doc.Save(StickyNoteForm.PATH);
            }
            catch (Exception e) {
                file.LOG(e.Message);
                file.Close();
            }
        }

        public void ShowAll() {
            Fetch();
            foreach (StickyNoteForm note in list)
                note.Show();
        }

        public void HideAll() {
            foreach (StickyNoteForm note in list) {
                note.Hide();
            }
        }

    }
}
