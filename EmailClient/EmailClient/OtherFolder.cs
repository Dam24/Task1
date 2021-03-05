using System;
using System.Collections.Generic;
using System.Text;

namespace EmailClient
{
	class OtherFolder: Folder
	{
        public OtherFolder(string Name) : base(Name)
        {

        }
        public void Rename(string Name)
        {
            this.Name = Name;
        }
    }
}
