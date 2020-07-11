using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotlight
{
    //Im not storing just name but a FileObject which would contains its name , its location and its rank based on recently modified activity.
    //So this is our most atmoic unit of data/file .
    public class FileObj
    {
        public String name
        {
            get; 
            set;
        }
        public String location
        {
            get;
            set;
        }

        public int rank
        {
            get;
            set;
        }

        public FileObj()
        {

        }
        public FileObj(String name, String location, int rank)
        {
            this.name = name;
            this.location = location;
            this.rank = rank;
        }
    }
}
