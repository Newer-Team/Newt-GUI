using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newt.ObjectClasses
{
    public class JSONClass
    {
        public int[][] randomization_groups { get; set; }
        public object[][] tiles { get; set; }
        public int[] texture_formats { get; set; }
        public string[] textures { get; set; }
        public string[] object_names { get; set; }
        public int version { get; set; }
    }
}
