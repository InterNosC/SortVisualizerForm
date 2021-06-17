using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortVisualizerForm
{
    /// <summary>
    /// We are using pattern stretegy, so we 
    /// implement interface for our algoritms.
    /// </summary>
    public interface ISortEngine
    {
        void Process();
    }
}
