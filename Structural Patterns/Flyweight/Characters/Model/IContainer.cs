using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Characters.Model
{
    public interface IContainer
    {
        int Margin { get; }
        int Padding { get; }
        int Width { get; }
        int Height { get; }
    }
}
