using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace NAntGui.Framework
{
    public class GenericFile : BuildScript
    {
        public GenericFile(FileInfo file) : base(file)
        {            
        }

        public override void Parse()
        {
            Name = _file.Name;
            Description = _file.FullName;
        }
    }
}
